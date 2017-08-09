using EveryDay.Calc.Calculation;
using EveryDay.Calc.Calculation.Interfaces;
using EveryDay.Calc.Calculation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SConsole = System.Console;

namespace EveryDay.Calc.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // поиск операций
            var calc = new Calculator(LoadOperations());
            
            // поиск информации
            //printInformation(calc);
            while (true)
            {
                // список операций
                printInformation(calc);
                SConsole.WriteLine();
                SConsole.WriteLine("Введите выбранную операцию:");
                var oper = SConsole.ReadLine().ToLower();
                if (oper == "exit") break;
                SConsole.WriteLine("Введите данные:");
                string[] s = SConsole.ReadLine().Split(' ');
                var numbers = new double[s.Count()];
                int i = 0;
                foreach (var item in s)
                {
                    numbers[i] = Str2Db(s[i]);
                    i++;
                }
                var result = calc.Calc(oper, numbers);
                if (result == null)
                {
                    SConsole.WriteLine("Операция не найдена или произошла ошибка. Введите данные заново");
                    SConsole.WriteLine();
                    continue;
                }
                SConsole.WriteLine("Результат: ", result.ToString());
                SConsole.WriteLine();
            }
            SConsole.ReadKey();
           
        }

        private static IEnumerable<IOperation> LoadOperations()
        {
            var opers = new List<IOperation>();

            var typeOperation = typeof(IOperation);

            // найти все dll, которые находятся рядом с нашим exe
            var dlls = Directory.GetFiles(Environment.CurrentDirectory, "*.dll");

            // перебираем
            foreach (var dll in dlls)
            {
                // загружаем сборку из файла
                var assembly = Assembly.LoadFrom(dll);
                // получаем типы/классы/интерфейсы из сброрки
                var types = assembly.GetTypes();

                // перебираем типы
                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces();
                    // если тип реализует наш интерфейс 
                    if (interfaces.Contains(typeOperation))
                    {
                        // пытаемся создать экземпляр
                        var instance = Activator.CreateInstance(type) as IOperation;
                        if (instance != null)
                        {
                            // добавляем в список операций
                            opers.Add(instance);
                        }
                    }
                }
            }

            return opers;
        }


        private static double Str2Db(string str)
        {
            double y;
            if (!double.TryParse(str, out y))
            {
                SConsole.WriteLine("Не удалось преобразовать \"{0}\" в число", str);
                SConsole.WriteLine("Введите это число заново:");
                return Str2Db(SConsole.ReadLine());
            }
            return y;
        }


        private static void printInformation(Calculator opers)
        {
            SConsole.WriteLine("Доступные действия в формате \"(операция) (входные_данные) - описание\":");
            var namesOper = opers.infoAboutOper();
            foreach (var nameOper in namesOper)
            {
                SConsole.WriteLine(nameOper);
            }
            SConsole.WriteLine("\"exit\" - выход из программы");
        }

    }
}

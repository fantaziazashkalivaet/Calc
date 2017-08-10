using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EveryDay.Calc.Calculation.Interfaces;

namespace EveryDay.Calc.AppCalc
{
    class Helper
    {
        public static IEnumerable<IOperation> LoadOperations()
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
                        if (type.IsAbstract)
                        {
                            continue;
                        }
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

        public static double Str2Db(string str)
        {
            double result;

            double.TryParse(str, out result);

            return result;
        }
    }
}

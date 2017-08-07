using EveryDay.Calc.Calculation;
using System;
using SConsole = System.Console;

namespace EveryDay.Calc.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            printInformation();
            string s;
            s = SConsole.ReadLine();
            args = s.Split(' ');
            var oper = args[0];
           
            var calc = new Calculator();

            //Определение арифметической операции и вывод результата из соответствующей функции
            if (String.Equals(oper, "sum", StringComparison.CurrentCultureIgnoreCase))
            {
                SConsole.WriteLine(calc.Sum(args[1], args[2]));
            }
            else if (String.Equals(oper, "div", StringComparison.CurrentCultureIgnoreCase))
            {
                SConsole.WriteLine(calc.Div(args[1], args[2]));
            }
            else if (String.Equals(oper, "sqr", StringComparison.CurrentCultureIgnoreCase))
            {
                SConsole.WriteLine(calc.Sqr(args[1]));
            }
            else if (String.Equals(oper, "sqrt", StringComparison.CurrentCultureIgnoreCase))
            {
                double solve = calc.Sqrt(args[1]);
                if (solve > 0)
                    SConsole.WriteLine("{0}, {1}", solve, -solve);
                else if (solve == 0)
                    SConsole.WriteLine(solve);
                else
                    SConsole.WriteLine("{0}*i, {1}*i, где i^2 = -1", solve, -solve);
            }
            else if (String.Equals(oper, "mult", StringComparison.CurrentCultureIgnoreCase))
            {
                SConsole.WriteLine(calc.Mult(args));
            }
            else if ((String.Equals(oper, "percof", StringComparison.CurrentCultureIgnoreCase)))
            {
                SConsole.WriteLine(calc.PercOf(args[1], args[2]));
            }
            else
            {
                SConsole.WriteLine("Нет такой операции");
            }

            SConsole.ReadKey();
        }

        private static void printInformation()
        {
            SConsole.WriteLine("Введите входные данные в формате: \"операция операнды\"");
            SConsole.WriteLine();
            SConsole.WriteLine("Возможные перации и операнды:");
            SConsole.WriteLine("\"sum слагаемое1 слагаемое2\" - складывает слагаемое1 и слагаемое2");
            SConsole.WriteLine("\"div делимое делитель\" - делит делимое на делитель");
            SConsole.WriteLine("\"sqr число\" - возводит число в квадрат");
            SConsole.WriteLine("\"sqrt число\" - извлекает квадратный корень из числа");
            SConsole.WriteLine("\"mult множитель1 множитель2 ... множительN\" - перемножает все множители");
            SConsole.WriteLine("\"percof число процент\" - вычисляет процент от числа");
            SConsole.WriteLine();
        }
    }
}

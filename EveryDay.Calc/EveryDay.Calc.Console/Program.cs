using EveryDay.Calc.Calculation;
using SConsole = System.Console;

namespace EveryDay.Calc.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //SConsole.WriteLine("test");

            var oper = args[0];
            var x = Str2Int(args[1]);
            var y = Str2Int(args[2]);

            var calc = new Calculator();
            int result = 0;

            if (oper == "sum")
            {
                result = calc.Sum(x, y);
            }
            else if (oper == "div")
            {
                result = calc.Div(x, y);
            }
            else
            {
                SConsole.WriteLine("Нет такой операции");
            }

            SConsole.WriteLine(result.ToString());

            SConsole.ReadKey();
        }

        private static int Str2Int(string str)
        {
            var x = int.Parse(str);
            int y;
            if (!int.TryParse(str, out y))
            {
                SConsole.WriteLine("Не удалось преобразовать \"{0}\" в число", str);
            }

            return y;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.Calc.Calculation
{
    public class Calculator
    {
        public double Sum(string x, string y)
        {
            return Str2Int(x) + Str2Int(y);
        }
        public double Div(string x, string y)
        {
            double newY = Str2Int(y);
            return newY == 0 ? 0 : (double)Str2Int(x) / (double)newY;
        }

        public double Sqr(string x)
        {
            return Str2Int(x) * Str2Int(x);
        }

        public double Sqrt(string x)
        {
            double newX = Str2Int(x);
            return newX < 0 ? -Math.Sqrt(-Str2Int(x)) : Math.Sqrt(Str2Int(x));
        }

        public double Mult(string[] multipliers)
        {
            double count = 1;
            for (var i = 1; i < multipliers.Count(); i++)
            {
                count *= Str2Int(multipliers[i]);
            }
            return count;
        }

        public double PercOf(string x, string y)
        {
            return Str2Int(x) * Str2Int(y) / 100;
        }

        private double Str2Int(string str)
        {
            double y;
            if (!double.TryParse(str, out y))
            {
                Console.WriteLine("Не удалось преобразовать \"{0}\" в число", str);
                Console.WriteLine("Введите это число заново:");
                return Str2Int(Console.ReadLine());
            }
            return y;
        }
    }
}

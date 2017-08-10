using EveryDay.Calc.Calculation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.Calc.Calculation.Models
{
    public class PercOperation : IOperation
    {
        public string Name
        {
            get { return "Perc"; }
        }

        public double[] Input
        {
            get;
            set;
        }

        public Nullable<double> GetResult()
        {
            if (Input.Count() != 2)
            {
                Console.WriteLine("Введено неверное количество операндов.");
                Console.WriteLine("Введите данные заново.");
                Console.WriteLine();
                return null;
            }
            return Input[0] * Input[1] / 100;
        }

        public string infoForUser
        {
            get { return "\"perc число процент\" - вычисляет процент от числа"; }
        }
    }
}

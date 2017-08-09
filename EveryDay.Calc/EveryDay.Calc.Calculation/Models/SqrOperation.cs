using EveryDay.Calc.Calculation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.Calc.Calculation.Models
{
    public class SqrOperation : IOperation
    {


        public string Name
        {
            get { return "Sqr"; }
        }

        public double[] Input
        {
            get;
            set;
        }

        public Nullable<double> GetResult()
        {
            if (Input.Count() > 1)
            {
                Console.WriteLine("Введено неверное количество операндов.");
                Console.WriteLine("Введите данные заново.");
                Console.WriteLine();
                return null;
            }
            return Input[0] * Input[0];
        }

        public string infoForUser
        {
            get { return "\"sqr число\" - возводит число в квадрат"; }
        }
    }
}

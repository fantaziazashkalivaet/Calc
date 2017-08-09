using EveryDay.Calc.Calculation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.Calc.Calculation.Models
{
    public class SumOperation : IOperation
    {
        public double[] Input { get; set; }
        public string Name
        {
            get { return "Sum"; }
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
            return Input.Sum();
        }


        public string infoForUser
        {
            get { return "\"Sum слагаемое1 слагаемое2\" - выполняет сложение двух чисел"; }
        }
    }
}

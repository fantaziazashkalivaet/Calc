using EveryDay.Calc.Calculation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.Calc.Calculation.Models
{
    public class MultOperation : IOperation
    {


        public string Name
        {
            get { return "Mult"; }
        }

        public double[] Input
        {
            get;
            set;
        }

        public Nullable<double> GetResult()
        {
            if (Input[0] < 2)
            {
                Console.WriteLine("Введено неверное количество операндов.");
                Console.WriteLine("Введите данные заново.");
                Console.WriteLine();
                return null;
            }
            double result = 1;
            foreach (var item in Input)
            {
                result *= item;
            }
            return result;
        }

        public string infoForUser
        {
            get { return "\"mult множитель1 множитель2 ... множительN\" - перемножает множители (не меньше двух)"; }
        }
    }
}

using EveryDay.Calc.Calculation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.Calc.Calculation.Models
{
    public class DivOperation : IOperation
    {
        public string Name
        {
            get { return "Div"; }
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
            if (Input[1] == 0)
            {
                Console.WriteLine("Деление на ноль невозможно.");
                Console.WriteLine();
                return null;
            }
            return Input[0] / Input[1];
        }

        public string infoForUser
        {
            get { return "\"Div делимое делитель\" - выполняет деление"; }
        }
    }
}

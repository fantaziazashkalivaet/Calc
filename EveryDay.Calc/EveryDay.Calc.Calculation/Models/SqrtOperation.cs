using EveryDay.Calc.Calculation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.Calc.Calculation.Models
{
    public class SqrtOperation : IOperation
    {
        public string Name
        {
            get { return "Sqrt"; }
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
                return null;
            }
            if (Input[0] < 0) return null;
            return Math.Sqrt(Input[0]);
        }

        public string infoForUser
        {
            get { return "\"sqrt число\" - извлекает квадратный корень из числа"; }
        }
    }
}

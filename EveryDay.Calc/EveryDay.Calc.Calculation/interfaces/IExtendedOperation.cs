using EveryDay.Calc.Calculation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.Calc.Calculation.interfaces
{
    public interface IExtendedOperation : IOperation
    {
        string Description { get; }

        string Error { get; set; }
    }
}

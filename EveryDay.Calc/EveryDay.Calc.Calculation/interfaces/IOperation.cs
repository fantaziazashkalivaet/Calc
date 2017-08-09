using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.Calc.Calculation.Interfaces
{
    public interface IOperation
    {
        /// <summary>
        /// Наименование
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Информация об операции для пользователя
        /// </summary>
        string infoForUser { get; }

        /// <summary>
        /// Входные параметры
        /// </summary>
        double[] Input { get; set; }

        /// <summary>
        /// Получить результат
        /// </summary>
        /// <return> Результат операции </return>
        double? GetResult();
        

    }
}

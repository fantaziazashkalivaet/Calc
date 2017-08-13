using EveryDay.Calc.Calculation.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    public class OperationResult
    {
        //не работает без операции
        [DisplayName("Операция")]
        [Required(ErrorMessage = "Выбери операцию")]

        public string Operation { get; set; }

        [DisplayName("Входные данные")]
        [Required(ErrorMessage = "Введи данные")]
        public double[] Inputs { get; set; }

        public bool IsEasy { get; set; }

        public DateTime ExecutionDate { get; set; }

        [ReadOnly(true)]
        public double? Result { get; set; }

        [ReadOnly(true)]
        public int ExecutionTime { get; set; }
    }
}
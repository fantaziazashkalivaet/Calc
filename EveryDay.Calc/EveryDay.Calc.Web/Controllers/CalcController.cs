
using EveryDay.Calc.AppCalc;
using EveryDay.Calc.Calculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {

        private Calculator Calculator { get; set; }

        public CalcController()
        {
            

        }
        //
        // GET: /Calc/
        [HttpGet]
        public ActionResult Index(string operation)
        {
            var model = new OperationResult();
            model.Operation = operation;

            var operations = Helping.LoadOperations();
            var nameOperation = new string[operations.Count()];
            int i = 0;
            foreach (var item in operations)
            {
                nameOperation[i] = item.Name;
                i++;
            }

            ViewBag.nameOperation = nameOperation;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(OperationResult model, string inputs)
        {
          
            if (Calculator == null)
            {
                var extensionPath = Server.MapPath("~/App_Data/Extensions");
                var operations = Helping.LoadOperations();
                Calculator = new Calculator(operations);
            }

            model.ExecutionDate = DateTime.Now;
            model.Inputs = inputs.Split(' ').Select(Helping.Str2Double).ToArray();

            model.Result = Calculator.Calc(model.Operation, model.Inputs);

            return View(model);
        }

        private static double Str2Db(string str)
        {
            double result;

            if (!double.TryParse(str, out result))
            {

            }
            return result;
        }
    }
}
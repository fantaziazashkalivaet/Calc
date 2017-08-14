
using EveryDay.Calc.AppCalc;
using EveryDay.Calc.Calculation;
using EveryDay.Calc.Calculation.Interfaces;
using EveryDay.Calc.Web.Repository;
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
        private IRepository<Operation> OpRepository { get; set; }
        private Calculator Calculator { get; set; }

       private IEnumerable<Operation> Operations { get; set; }

        public CalcController()
        {
           // Operations = Helping.LoadOperations();
            OpRepository = new OperationRepository();

            Operations = OpRepository.GetAll();

        }
        //
        // GET: /Calc/
        [HttpGet]
        public ActionResult Index(string operation)
        {
            var model = new OperationResult();
            model.Operation = operation;

           // var wtf = new OperationRepository();
           // var wtff = wtf.Read((long)1);

            var wtf = new Operation();
            wtf.Id = 1;
            wtf.Name = "sim";
            wtf.Description = "lol";

            var wtff = new OperationRepository();
            wtff.Update(wtf, 1);

            var wtfff = wtff.Read((long)1);


            var nameOperation = new string[Operations.Count()];
            int i = 0;
            foreach (var item in Operations)
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
                Calculator = new Calculator(Helping.LoadOperations());
            }

            model.ExecutionDate = DateTime.Now;
            model.Inputs = inputs.Split(' ').Select(Helping.Str2Double).ToArray();

            model.Result = Calculator.Calc(model.Operation, model.Inputs);

            
            var nameOperation = new string[Operations.Count()];
            int i = 0;
            foreach (var item in Operations)
            {
                nameOperation[i] = item.Name;
                i++;
            }

            ViewBag.nameOperation = nameOperation;

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

using EveryDay.Calc.AppCalc;
using EveryDay.Calc.Calculation;
using EveryDay.Calc.Calculation.Interfaces;
using EveryDay.Calc.Web.Repository;
using EveryDay.Calc.Webcalc.Repository;
//using EveryDay.Calc.Webcalc.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class CalcController : Controller
    {
        #region Private Memebers

        private IOperationRepository OpRepository { get; set; }

        private IOperationResultRepository OperResultRepository { get; set; }

        private IUserRepository userRepository { get; set; }

        private Calculator Calculator { get; set; }

        private IEnumerable<Operation> Operations { get; set; }

        private IEnumerable<long> TopOperationIds { get; set; }

        #endregion
        public CalcController() { }
        public CalcController(IOperationRepository OpRepository,
            IOperationResultRepository OperResultRepository,
            IUserRepository userRepository)
        {
            //var extensionPath = Server.MapPath("~/App_Data/Extensions");
            // Operations = Helper.LoadOperations();

            if (Calculator == null)
            {
                Calculator = new Calculator(Helping.LoadOperations());
            }

            this.OpRepository = OpRepository;
            this.OperResultRepository = OperResultRepository;
            this.userRepository = userRepository;

            Operations = OpRepository.GetAll();
            TopOperationIds = OperResultRepository.GetTopOperations(1, 2);
        }
        //
        // GET: /Calc/
        [HttpGet]
        public ActionResult Index()
        {
            var model = new OperationResult(Operations, TopOperationIds);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(OperationResult model, string inputs)
        {
            model.SetViewModel(Operations, TopOperationIds);
            model.ExecutionDate = DateTime.Now;
            model.Inputs = inputs.Split(' ').Select(Helping.Str2Double).ToArray();

            string error = "";
            double? result;

            // Проверяем, вычисляли уже такую операцию или нет
            if (OperResultRepository.Check(model.Operation, inputs, out result, out error))
            {
                model.ExecutionTime = 0;
                model.Result = result;
                ViewBag.Error = error;
                return View(model);
            }

            var dbOperation = Operations.FirstOrDefault(o => o.Id == model.Operation);
            var operName = dbOperation != null ? dbOperation.Name : "";

            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                model.Result = Calculator.Calc(operName, model.Inputs);
                stopWatch.Stop();
                model.ExecutionTime = stopWatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            #region Сохраняем результат в БД

            var opr = new OperResult()
            {
                OperationId = model.Operation,
                Inputs = inputs,
                ExecutionDate = model.ExecutionDate,
                ExecutionTime = model.ExecutionTime,
                Result = model.Result,
                Error = error,
                UserId = 1 // временно
            };

            OperResultRepository.Create(opr);

            #endregion

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
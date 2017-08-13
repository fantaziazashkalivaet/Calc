using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EveryDay.Calc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calc()
        {
            return View();
        }

        public ActionResult Result(string arg1)
        {
            string[] inputs = arg1.Split(' ');
            var args = new double[inputs.Count()];
            int i = 0;
            foreach (var input in inputs)
            {
                if (!double.TryParse(input, out args[i]))
                {
                    ViewBag.result = "Введены неверные данные";
                }
                i++;
            }
            ViewBag.result = Sum(args).ToString();
            return View("Calc");
        }

        private double Sum(double[] args)
        {
            double count = 0;
            foreach (var item in args)
            {
                count += item;
            }
            return count;
        }

    }
}
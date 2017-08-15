using EveryDay.Calc.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EveryDay.Calc.Web.Controllers
{
    public class AccountCalcController : Controller
    {
        //
        // GET: /AccountCalc/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                UserRepository CheckUser = new UserRepository();
                var Check = CheckUser.Check(user.Login, user.Password);
                if (Check)
                    FormsAuthentication.SetAuthCookie(user.Login, true);
                return RedirectToAction("Index", "CalcController");
            }
            ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");

            return View(user);
        }

        public ActionResult Registration(User user)
        {
            var cr = new UserRepository();
            cr.Create(user);
            return RedirectToAction("Login", "AccountCalc");
        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDHS.Models.Function;
namespace QLDHS.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.messe = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string pass)
        {

            int check = new F_User().CheckUser(username, pass);
            if (check == -1)
            {
                var str = "Thông tin đăng nhập sai";
                ViewBag.messe = str;
                return View("Index");
            }
            return Redirect("~/Home/Index");

        }
    }
}
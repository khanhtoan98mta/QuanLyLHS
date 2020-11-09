using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDHS.Controllers
{
    public class HoatdongController : Controller
    {
        // GET: Hoatdong
        public ActionResult Index()
        {
            return View();
        }



        public bool AddArticle()
        {
            return true;
        }

        [HttpGet]
        public ActionResult ArticleDetail(string IdArticle)
        {
            return View();
        }
    }
}
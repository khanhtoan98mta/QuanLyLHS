using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDHS.Models.Entity;
using System.Data.SqlClient;
using System.Data;

namespace QLDHS.Controllers
{
    public class ThongkeController : Controller
    {
        // GET: Thongke
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DSThongkeNomon()
        {


            return View();
        }

        public ActionResult DSThongkeKQHT()
        {
            return View();
        }

        public ActionResult DSThangQuanHam_Year(int year)
        {
            year = 2020;
            SqlParameter endDate = new SqlParameter("@date", year);
            endDate.SqlDbType = SqlDbType.Int;
            List<ThongKeNienHanQH> ThongKeQH = new LUUHS().Database.SqlQuery<ThongKeNienHanQH>("exec dbo.ThongKe_NienHanQH @date", endDate).ToList();
            ViewBag.alllhs = ThongKeQH;
            return View();
        }
    }
}
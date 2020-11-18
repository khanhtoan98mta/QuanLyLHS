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
        public ActionResult ThongKe_LHS_TotNghiep()
        {
            List<string> nam = new List<string>();
            List<int> xs = new List<int>();
            List<int> xs_ = new List<int>();
            List<int> gioi = new List<int>();
            List<int> kha = new List<int>();
            List<int> tb = new List<int>();
            List<int> khac = new List<int>();


            List<ThongKe_TotNghiep_Year> ThongKeTN = new LUUHS().Database.SqlQuery<ThongKe_TotNghiep_Year>("exec dbo.ThongKe_LHS_TotNghiep").ToList();
            for (int i = 0; i < ThongKeTN.Count; i++)
            {

                nam.Add(ThongKeTN[i].Nam.ToString());
                xs.Add(ThongKeTN[i].Xuatsac);
                xs_.Add(ThongKeTN[i].Xuatsac_);
                gioi.Add(ThongKeTN[i].Gioi);
                kha.Add(ThongKeTN[i].Kha);
                tb.Add(ThongKeTN[i].TrungBinh);
                khac.Add(ThongKeTN[i].Khac);


            }
            ViewBag.nam = nam;
            ViewBag.xs = xs;
            ViewBag.xs_ = xs_;
            ViewBag.gioi = gioi;
            ViewBag.kha = kha;
            ViewBag.tb = tb;
            ViewBag.khac = khac;
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

        public ActionResult ThongKe_LHS_TotNghiep()
        {
            List<string> nam = new List<string>();
            List<int> xs = new List<int>();
            List<int> xs_ = new List<int>();
            List<int> gioi = new List<int>();
            List<int> kha = new List<int>();
            List<int> tb = new List<int>();
            List<int> khac = new List<int>();


            List<ThongKe_TotNghiep_Year> ThongKeTN = new LUUHS().Database.SqlQuery<ThongKe_TotNghiep_Year>("exec dbo.ThongKe_LHS_TotNghiep").ToList();
            for (int i = 0; i < ThongKeTN.Count; i++)
            {

                nam.Add(ThongKeTN[i].Nam.ToString());
                xs.Add(ThongKeTN[i].Xuatsac);
                xs_.Add(ThongKeTN[i].Xuatsac_);
                gioi.Add(ThongKeTN[i].Gioi);
                kha.Add(ThongKeTN[i].Kha);
                tb.Add(ThongKeTN[i].TrungBinh);
                khac.Add(ThongKeTN[i].Khac);


            }
            ViewBag.nam = nam;
            ViewBag.xs = xs;
            ViewBag.xs_ = xs_;
            ViewBag.gioi = gioi;
            ViewBag.kha = kha;
            ViewBag.tb = tb;
            ViewBag.khac = khac;
            return View();
        }
    }
}
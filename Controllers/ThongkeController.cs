using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDHS.Models.Entity;
using System.Data.SqlClient;
using System.Data;
using Xceed.Document.NET;
using Xceed.Words.NET;
using System.Data.SqlClient;
using Table = Xceed.Document.NET.Table;
using QLDHS.Models.Model_view;

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

        [HttpGet]
        public ActionResult DSThangQuanHam_Year(int Year,int DoiTuong)
        {
           
            SqlParameter year = new SqlParameter("@nam", Year);
            SqlParameter doituong = new SqlParameter("@madoituong", DoiTuong);

            year.SqlDbType = SqlDbType.Int;
            doituong.SqlDbType = SqlDbType.Int;

            List<ThongKeNienHanQH> ThongKeQH = new LUUHS().Database.SqlQuery<ThongKeNienHanQH>("exec dbo.ThongKe_NienHanQH @nam , @madoituong ", year,doituong).ToList();
            ViewBag.alllhs = ThongKeQH;
          
            return View();
        }

        [HttpPost]
        public ActionResult DSThangQuanHam_Year_Post(int Year, int DoiTuong)
        {

            SqlParameter year = new SqlParameter("@nam", Year);
            SqlParameter doituong = new SqlParameter("@madoituong", DoiTuong);

            year.SqlDbType = SqlDbType.Int;
            doituong.SqlDbType = SqlDbType.Int;

            List<ThongKeNienHanQH> ThongKeQH = new LUUHS().Database.SqlQuery<ThongKeNienHanQH>("exec dbo.ThongKe_NienHanQH @nam , @madoituong ", year, doituong).ToList();
            

            return Json(new
            {
                list = ThongKeQH
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ThongKePLTN()
        {
            List<ThongKe_TotNghiep_Year> ThongKeTN = new LUUHS().Database.SqlQuery<ThongKe_TotNghiep_Year>("exec dbo.ThongKe_LHS_TotNghiep").ToList();
            string filename = @"D:/Tai_lieu_hoc_tap/ThucTap/baocao.docx";
            var doc = DocX.Load(filename);
            string nam = "<nam";
            string xs_ = "<xs_";
            string xs = "<xs";
            string gioi = "<g";
            string kha = "<k";
            string tb = "<tb";
            string khac = "<ka";
            var doc1 = doc.Copy();
            for (int i = 0; i < ThongKeTN.Count; i++)
            {

                doc1.ReplaceText(nam + (i + 1).ToString() + ">", ThongKeTN[i].Nam.ToString());
                doc1.ReplaceText(xs_ + (i + 1).ToString() + ">", ThongKeTN[i].Xuatsac_.ToString());
                doc1.ReplaceText(xs + (i + 1).ToString() + ">", ThongKeTN[i].Xuatsac.ToString());
                doc1.ReplaceText(gioi + (i + 1).ToString() + ">", ThongKeTN[i].Gioi.ToString());
                doc1.ReplaceText(kha + (i + 1).ToString() + ">", ThongKeTN[i].Kha.ToString());
                doc1.ReplaceText(tb + (i + 1).ToString() + ">", ThongKeTN[i].TrungBinh.ToString());
                doc1.ReplaceText(khac + (i + 1).ToString() + ">", ThongKeTN[i].Khac.ToString());

            }
            using (var stream = new System.IO.MemoryStream())
            {
                doc1.SaveAs(stream);
                var content = stream.ToArray();
                return File(
                    content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "ThongkePLTotNghiep_5Nam.docx");
            }
        }

        public ActionResult ThongKeLHSKetThucKhoaHoc(int year)
        {
            SqlParameter Year = new SqlParameter("@year", year);
            Year.SqlDbType = SqlDbType.Int;

            List<CVDeNghiTotNgiep> DSDeNghiTotNgieps = new LUUHS().Database.SqlQuery<CVDeNghiTotNgiep>("exec dbo.ThongKeLHSVeNuoc @year ", Year).ToList();
            ViewBag.LHS_KTKhoaHoc = DSDeNghiTotNgieps;
            return View();
        }
        public ActionResult ThongkeNienHanQuanHam()
        {
            int year = 2020;
            int madoituong = 1;
            SqlParameter endDate = new SqlParameter("@date", year);
            SqlParameter doituong = new SqlParameter("@madoituong", madoituong);
            endDate.SqlDbType = System.Data.SqlDbType.Int;
            List<ThongKeNienHanQH> ThongKeQH = new LUUHS().Database.SqlQuery<ThongKeNienHanQH>("exec dbo.ThongKe_NienHanQH @date @madoituong", endDate,doituong).ToList();
            string filename = @"D:/Tai_lieu_hoc_tap/QuanLyLHS/MAU/DSThangQuanHam.docx";
            var doc = DocX.Load(filename);
            var doc1 = doc.Copy();
            int rowcount = ThongKeQH.Count;
            

            using (var stream = new System.IO.MemoryStream())
            {
                doc.SaveAs(stream);
                var content = stream.ToArray();
                return File(
                    content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "ThongkeNienHanQuanHam.docx");
            }
        }

       



    }
}
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
            List<ThongKeNienHanQH> ThongKeQH = new LUUHS().Database.SqlQuery<ThongKeNienHanQH>("exec dbo.ThongKe_NienHanQH_SiQuan @date", endDate).ToList();
            ViewBag.alllhs = ThongKeQH;
          
            return View();
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

        public ActionResult ThongkeNienHanQuanHam()
        {
            int year = 2020;
            SqlParameter endDate = new SqlParameter("@date", year);
            endDate.SqlDbType = System.Data.SqlDbType.Int;
            List<ThongKeNienHanQH> ThongKeQH = new LUUHS().Database.SqlQuery<ThongKeNienHanQH>("exec dbo.ThongKe_NienHanQH @date", endDate).ToList();
            string filename = @"D:/Tai_lieu_hoc_tap/ThucTap/quanham.docx";
            var doc = Xceed.Words.NET.DocX.Create(filename);

            int rowcount = ThongKeQH.Count;
            Table t = doc.AddTable(rowcount + 1, 6);
            t.Rows[0].Cells[0].Paragraphs.First().Append("Mã LHS");
            t.Rows[0].Cells[1].Paragraphs.First().Append("Họ tên");
            t.Rows[0].Cells[2].Paragraphs.First().Append("Ngày nhận");
            t.Rows[0].Cells[3].Paragraphs.First().Append("Quân hàm");
            t.Rows[0].Cells[4].Paragraphs.First().Append("Cơ sở đào tạo");
            t.Rows[0].Cells[5].Paragraphs.First().Append("Địa bàn");
            for (int i = 0; i < ThongKeQH.Count; i++)
            {
                t.Rows[i + 1].Cells[0].Paragraphs.First().Append(ThongKeQH[i].MaLHS);
                t.Rows[i + 1].Cells[1].Paragraphs.First().Append(ThongKeQH[i].HoTen);
                t.Rows[i + 1].Cells[2].Paragraphs.First().Append(ThongKeQH[i].NgayNhan.ToString());
                t.Rows[i + 1].Cells[3].Paragraphs.First().Append(ThongKeQH[i].QuanHam);
                t.Rows[i + 1].Cells[4].Paragraphs.First().Append(ThongKeQH[i].CSDaoTao);
                t.Rows[i + 1].Cells[5].Paragraphs.First().Append(ThongKeQH[i].DiaBan);
            }
            doc.InsertTable(t);

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
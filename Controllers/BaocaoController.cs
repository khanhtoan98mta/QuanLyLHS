using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using QLDHS.Models.Function;
using QLDHS.Models.Entity;
using System.Web.UI;
using ClosedXML.Excel;
using ClosedXML;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Table = Xceed.Document.NET.Table;

namespace QLDHS.Controllers
{
    public class BaocaoController : Controller
    {
        // GET: Baocao
        public ActionResult Index()
        {
            Reporter report = new Reporter();
            string inputfile = HttpContext.Server.MapPath("~/Content/Reports/Template/Template_1.docx");
            report.Baocao_Template1(inputfile, Response);



            return View();
        }
        

        /// <summary>
        /// báo cáo 1 : báo cáo về vấn đề thống kê số lượng lưu học sinh của các nước
        /// </summary>
        /// <returns></returns>
        public ActionResult Baocao_Excel_1()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Thong ke so luong luu hoc sinh");
                var current_row = 1;

                #region header
                worksheet.Cell(current_row, 1).Value = "Mã nước";
                worksheet.Cell(current_row, 2).Value = "Nước";
                worksheet.Cell(current_row, 3).Value = "Số lượng";
                #endregion


                #region thân
                foreach (var item in new F_Luuhocsinh().Thongke_LHS_time(2019))
                {
                    current_row++;
                    worksheet.Cell(current_row, 1).Value = item.madiaban;
                    worksheet.Cell(current_row, 2).Value = item.diaban;
                    worksheet.Cell(current_row, 3).Value = item.soluong;
                }
                #endregion

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ThongkeLHSCountry.xlsx");
                }
            }

        }

        public void Baocao_Word_1()
        {
            
            string outputfile = HttpContext.Server.MapPath("~/Content/Reports/Baocao_1.docx");
            using (FileStream fileStream = System.IO.File.OpenRead(outputfile))
            {
                MemoryStream memStream = new MemoryStream();
                memStream.SetLength(fileStream.Length);
                fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                Response.AddHeader("Content-Disposition", "attachment; filename=myfile.docx");
                Response.BinaryWrite(memStream.ToArray());
                Response.Flush();
                Response.Close();
                Response.End();
            }

        }


        /// <summary>
        /// xuất báo cáo 2 : báo cáo về vấn đề tiền sinh hoạt của học viên lưu học sinh
        /// </summary>
        /// <returns></returns>
        public ActionResult Baocao_Excel_2()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Thong ke so luong luu hoc sinh");
                var current_row = 1;

                #region header
                worksheet.Cell(current_row, 1).Value = "Mã nước";
                worksheet.Cell(current_row, 2).Value = "Nước";
                worksheet.Cell(current_row, 3).Value = "Số lượng";
                #endregion


                #region thân
                foreach (var item in new F_Luuhocsinh().Thongke_LHS_time(2019))
                {
                    current_row++;
                    worksheet.Cell(current_row, 1).Value = item.madiaban;
                    worksheet.Cell(current_row, 2).Value = item.diaban;
                    worksheet.Cell(current_row, 3).Value = item.soluong;
                }
                #endregion

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ThongkeLHSCountry.xlsx");
                }
            }

          
        }
        public ActionResult ThongkeNienHanQuanHam(int year,int madoituong)
        {
            LUUHS db = new LUUHS();
           
            SqlParameter endDate = new SqlParameter("@date", year);
            SqlParameter doituong = new SqlParameter("@madoituong", madoituong);
            endDate.SqlDbType = System.Data.SqlDbType.Int;
            List<ThongKeNienHanQH> ThongKeQH = new LUUHS().Database.SqlQuery<ThongKeNienHanQH>("exec dbo.ThongKe_NienHanQH @date, @madoituong", endDate, doituong).ToList();
            string filename = @"D:/Tai_lieu_hoc_tap/QuanLyLHS/MAU/DSThangQuanHam.docx";
            var doc = Xceed.Words.NET.DocX.Load(filename);
            var doc1 = doc.Copy();
            string dt = db.DoiTuongs.Find(madoituong).DoiTuong1;
            if(madoituong==0)
            {
                dt = "";
            }
            doc1.ReplaceText("<doituong>", dt);
            doc1.ReplaceText("<nam>", year.ToString());
            Table table = doc1.Tables[0];
            for(int i=0;i<ThongKeQH.Count;i++)
            {
                //cột stt
                Row myrow = table.InsertRow();
                Paragraph para0 = myrow.Cells[0].Paragraphs.First().Font("Time New Roman").FontSize(14).Append((i + 1).ToString() + ".");
                para0.Alignment = Alignment.center;
                para0.FontSize(14);
                para0.Font("Time New Roman");
                //cột hộ tên
                Paragraph para1 = myrow.Cells[1].Paragraphs.First().Append(ThongKeQH[i].HoTen);
                para1.FontSize(14);
                para1.Font("Time New Roman");
                //cột Quân hàm hiện tại
                Paragraph para2 = myrow.Cells[2].Paragraphs.First().Append(ThongKeQH[i].KiHieu);
                para2.FontSize(14);
                para2.Font("Time New Roman");
                para2.Alignment = Alignment.center;
                //cột sở sở đào tạo
                Paragraph para3 = myrow.Cells[3].Paragraphs.First().Append(ThongKeQH[i].CSDaoTao);
                para3.FontSize(14);
                para3.Font("Time New Roman");
                //cột thời gian nhận quân hàm
                if (ThongKeQH[i].NgayNhan != null)
                {
                    string str = ThongKeQH[i].NgayNhan.ToString();
                    DateTime date = Convert.ToDateTime(str);
                    string ngay = "";
                    string thang = "";
                    string nam = "";
                    ngay = date.Day.ToString();
                    if (ngay.Length == 1)
                    {
                        ngay = "0" + ngay;
                    }
                    thang = date.Month.ToString();
                    if (thang.Length == 1)
                    {
                        thang = "0" + thang;
                    }
                    nam = date.Year.ToString();
                    if (nam.Length == 1)
                    {
                        nam = "0" + nam;
                    }
                    string ngaynhan = ngay + "/" + thang + "/" + nam;

                    Paragraph para5 = myrow.Cells[4].Paragraphs.First().Append(ngaynhan);
                    para5.FontSize(14);
                    para5.Font("Time New Roman");
                    para5.Alignment = Alignment.center;
                }
                else
                {
                    Paragraph para5 = myrow.Cells[4].Paragraphs.First().Append(ThongKeQH[i].NgayNhan.ToString());
                    para5.FontSize(14);
                    para5.Font("Time New Roman");
                    para5.Alignment = Alignment.center;

                }

            }


            using (var stream = new System.IO.MemoryStream())
            {
                doc1.SaveAs(stream);
                var content = stream.ToArray();
                return File(
                    content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "ThongkeNienHanQuanHam.docx");
            }
        }

    }
}
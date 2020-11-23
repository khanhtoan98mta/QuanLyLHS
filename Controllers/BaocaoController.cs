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

    }
}
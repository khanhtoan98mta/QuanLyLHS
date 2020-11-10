using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDHS.Models.Entity;
using QLDHS.Models.Function;
using Newtonsoft.Json;

namespace QLDHS.Controllers
{
    


    public class DataMap
    {
        string iso {  get; set; }
        int soluong { get; set; }

        
        
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {            

            return View();
        }

        public ActionResult InitMap()
        {
            

            try
            {
                F_Luuhocsinh f_lhs = new F_Luuhocsinh();
                var lhs_time = f_lhs.Thongke_LHS_time(2019);
                for (int i = 0; i < lhs_time.Count; i++)
                {
                    lhs_time[i].madiaban = lhs_time[i].madiaban.Trim();
                }

                ViewBag.lhs_time = lhs_time;
            }
            catch (Exception)
            {

                throw;
            }
            

            return View();
        }

        public string ConvertThongKeLHS_Json(List<Thongke_lhs_time_class> dt)
        {


            string str = "{";
            for (int i = 0; i < dt.Count; i++)
            {
                string temp1 = dt[i].madiaban.ToString();
                temp1 = temp1.Trim();
                string temp2 = dt[i].soluong.ToString();
                str = str + (char)34 + temp1 + (char)34 + ":" + temp2 + ",";
            }
            str = str + "}";
            str = str.Replace(",}", "}");
            return str;
        }

        public ActionResult InitChart()
        {


            return View();
        }
        public ActionResult DSSINHVIEN()
        {
            try
            {
                F_Luuhocsinh f_lhs = new F_Luuhocsinh();
                ViewBag.alllhs = f_lhs.GetAll_LHS();
            }
            catch (Exception)
            {

                throw;
            }
            

            return View();
        }



        public ActionResult Hoatdongduhocsinh()
        {
            return View();
        }

        public ActionResult Nhapxuatbaocao()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username,string pass)
        {

            return Redirect("Index");
        }

        private void CreateDocument()
        {
            try
            {
                //khoi dong word
                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

                //tao animation
                winword.ShowAnimation = false;

                //hide word app
                winword.Visible = false;              
                object missing = System.Reflection.Missing.Value;

                //tao document
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                
                //them header
                foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                {
                    //Get the header range and add the header details.  
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
                    headerRange.Font.Size = 14;
                    headerRange.Text = "BÁO CÁO THỐNG KÊ DU HỌC SINH";
                }

                //them footer
                foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                {
                    //Get the footer range and add the footer details.  
                    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
                    footerRange.Font.Size = 14;
                    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Text = "";
                }

                //adding text to document  
                document.Content.SetRange(0, 0);
                document.Content.Text = "Báo cáo thống kê du học sinh trong năm qua :  " + Environment.NewLine;

                //thêm đoạn văn 1
                Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading1 = "Heading 1";
                para1.Range.set_Style(ref styleHeading1);
                para1.Range.Text = "Para 1 text";
                para1.Range.InsertParagraphAfter();
                //thêm đoạn văn 2
                Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading2 = "Heading 2";
                para2.Range.set_Style(ref styleHeading2);
                para2.Range.Text = "Para 2 text";
                para2.Range.InsertParagraphAfter();

                //thêm bảng 5x5
                Table firstTable = document.Tables.Add(para1.Range, 5, 5, ref missing, ref missing);

                firstTable.Borders.Enable = 1;
                foreach (Row row in firstTable.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        //Header row  
                        if (cell.RowIndex == 1)
                        {
                            cell.Range.Text = "Column " + cell.ColumnIndex.ToString();
                            cell.Range.Font.Bold = 1;
                            //other format properties goes here  
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                              
                            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                            //Center alignment for the Header cells  
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                        }
                        //Data row  
                        else
                        {
                            cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                        }
                    }
                }

                //Save the document  
                object filename = @"c:\temp1.docx";
                document.SaveAs2(ref filename);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;
            }
            catch (Exception)
            {
                
            }
        }
    }
}
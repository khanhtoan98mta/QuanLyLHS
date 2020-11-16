using F_Report;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLDHS.Models.Function
{
    public class Reporter
    {
        //báo cáo Excel
        //bao cáo 1
        public void Baocao1_ToExcel(HttpResponseBase Response, object clientsList)
        {
            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = clientsList;
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=FileName.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }

        //báo cáo 2

        

        //báo cáo 3


        //báo cáo Word
        //báo cáo 1 : theo template 1
        public void Baocao_Template1(string inputFile,HttpResponseBase Response)
        {
            
            string outputFile = HttpContext.Current.Server.MapPath("~/Content/Reports/Baocao_1.docx");


            // Copy Word document.
            File.Copy(inputFile, outputFile, true);

            // Open copied document.
            using (var flatDocument = new FlatDocument(outputFile))
            {
                // Search and replace document's text content.
                flatDocument.FindAndReplace("[TITLE]", "Thông tin");
                flatDocument.FindAndReplace("[SUBTITLE]", "Thông tin sinh viên...");
                flatDocument.FindAndReplace("[NAME]", "NGUYỄN VĂN NAM");
                flatDocument.FindAndReplace("[EMAIL]", "namnguyen.lion@gmail.com");
                flatDocument.FindAndReplace("[PHONE]", "(000)-111-222");

                
            }
        }





        //báo cáo 2



        //báo cáo 3



    }


}
using QLDHS.Models.Function;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDHS.Models.Entity;

namespace QLDHS.Controllers
{
    public class LuuHSController : Controller
    {
        // GET: LuuHS
        public ActionResult Index()
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

        public ActionResult EditLHS(int LHSID)
        {
           
            LUUHS db = new LUUHS();
            F_Luuhocsinh f_lhs = new F_Luuhocsinh();
            var detaillhs = f_lhs.Detai_LHS_Ma(LHSID);
            ViewBag.Doituong = db.DoiTuongs.Where(x => x.MaDoiTuong != 0).ToList();
            ViewBag.BoMon = db.BoMonDaoTaos.ToList();
            ViewBag.Khoa = db.KhoaDaoTaos.ToList();
            ViewBag.LHSID = LHSID; 
            ViewBag.CSDaotao = db.CoSoDaoTaos;
            ViewBag.DienKinhPhi = db.DienKinhPhiDaoTaos;
            ViewBag.BacDaoTao = db.BacDaoTaos;
            ViewBag.NganhDT = db.NganhDaoTaos;
            ViewBag.ChuyenNganhDaoTao = db.ChuyenNganhDaoTaos;
            ViewBag.diaban = db.DiaBanDaoTaos.ToList();
            ViewBag.QuanHam = db.QuanHams.ToList();

            return View(detaillhs);
        }
        public ActionResult EditQuanHam(int LHSID)
        {
            
            return View();
        }
        public ActionResult EditKhenThuongVaKiLuat()
        {
            return View();
        }

        public ActionResult EditVephep()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditLHSTTCoban(Thongtincoban infolhs)
        {
            F_Luuhocsinh f_lhs = new F_Luuhocsinh();
            f_lhs.EditThongtincoban(infolhs);

            return (Redirect("/luuhs/EditLHS?LHSID=" + infolhs.LHSID));

        }

        [HttpPost]
        public ActionResult EditLHSTTDaotao(Thongtindaotao infolhs)
        {
            F_Luuhocsinh f_lhs = new F_Luuhocsinh();
            f_lhs.EditLHSTTDaotao(infolhs);
            return (Redirect("/luuhs/EditLHS?LHSID=" + infolhs.LHSID));
        }
        
        public ActionResult DetailLHS(int LHSID)
        {
            LUUHS lhs = new LUUHS();
            F_Luuhocsinh f_lhs = new F_Luuhocsinh();
            var detaillhs = f_lhs.Detai_LHS_Ma(LHSID);

            ViewBag.Doituong = lhs.DoiTuongs.Where(x => x.MaDoiTuong != 0).ToList();
            return View(detaillhs);
        }

        /// <summary>
        /// Thêm mới lưu học sinh(trang view)
        /// </summary>
        /// <returns></returns>
        public ActionResult AddNewLHS()
        {
            LUUHS lhs = new LUUHS();
            var count = lhs.LuuHocSinhs.Count();
            string malhs = "SV"+DateTime.UtcNow.Year;
            if (count<100 && count>10)
            {
                malhs += "0";
            }
            else if (count >= 0 && count<10)
            {
                malhs += "00";
            }
            else { }
            ViewBag.malhs = malhs+count;

            ViewBag.Doituong = lhs.DoiTuongs.Where(x=>x.MaDoiTuong!=0).ToList();
            return View();
        }


        /// <summary>
        /// thêm mới lhs (post)
        /// </summary>
        /// <param name="luuhocsinh"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddNewLHS(LuuHocSinh luuhocsinh)
        {
            F_Luuhocsinh f_lhs = new F_Luuhocsinh();
            f_lhs.AddNewLHS(luuhocsinh);
            return (RedirectToAction("/luuhs/EditLHS?LHSID="+luuhocsinh.LHSID));
        }


        


        //chuyen ngành

        [HttpPost]
        public string UploadAvatar(HttpPostedFileBase AvatarImg,string id)
        {
            try
            {
                string fileExtend = System.IO.Path.GetExtension(AvatarImg.FileName);


                string targetFolder = Server.MapPath("~/Content/img/img_lhs/");
                string targetPath = Path.Combine(targetFolder, id+ fileExtend);
                AvatarImg.SaveAs(targetPath);
                F_Luuhocsinh f_lhs = new F_Luuhocsinh();
                f_lhs.ChangeImageLHS(Convert.ToInt32(id), "Content/img/img_lhs/"+id.ToString()+ fileExtend);
                return "Upload thành công";
            }
            catch (Exception)
            {
                return "Upload không thành công";
                
            }

            
        }




    }
}
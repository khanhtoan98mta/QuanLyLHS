using QLDHS.Models.Function;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDHS.Models.Entity;
using Xceed.Words.NET;
using QLDHS.Models.Model_view;

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
            ViewBag.diaban = db.DiaBanDaoTaos.OrderBy(x=>x.DiaBan);
            ViewBag.QuanHam = db.QuanHams.ToList();
            ViewBag.VePhep = db.VePheps.ToList();
            ViewBag.LHS_VePhep = db.LHS_VePhep.Where(x => x.LHSID == LHSID).ToList();

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

        public string XoaLHSVePhep(int LHSID, int IDVePhep)
        {


            return "Thành công";
        }

        [HttpPost]
        public ActionResult EditLHSTTCoban(Thongtincoban infolhs)
        {
            F_Luuhocsinh f_lhs = new F_Luuhocsinh();
            f_lhs.EditThongtincoban(infolhs);

            return (Redirect("/luuhs/EditLHS?LHSID=" + infolhs.LHSID));

        }

        [HttpPost]
        public ActionResult EditLHSTTDaotao(Thongtindaotao infolhs,int[] MaVePhep,DateTime[] NgayDi, DateTime[] NgayVe)
        {
            List<DsVePhep> dsvephep = new List<DsVePhep>();
            if(MaVePhep!=null)
            {
                for (int i = 0; i < MaVePhep.Length; i++)
                {
                    DsVePhep item = new DsVePhep();
                    item.MaVePhep = MaVePhep[i];
                    item.NgayDi = NgayDi[i];
                    item.NgayVe = NgayVe[i];
                    dsvephep.Add(item);
                }
                infolhs.dsvephep = dsvephep;
            }
            
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
            int id=f_lhs.AddNewLHS(luuhocsinh);
              
            return (Redirect("~/luuhs/EditLHS?LHSID="+id.ToString()));
        }

        public ActionResult DeleteLHS(int LHSID)
        {
            LUUHS luuhs = new LUUHS();
            //remove luan van tot nghiep
            LuanVanTotNghiep lvtn = new LuanVanTotNghiep();
            lvtn = luuhs.LuanVanTotNghieps.SingleOrDefault(x=>x.LHSID==LHSID);
            if(lvtn!=null)
            {
                luuhs.LuanVanTotNghieps.Remove(lvtn);
            }
            

            //remove ket qua học tập
            KetQuaHocTap kqht = new KetQuaHocTap();
            kqht = luuhs.KetQuaHocTaps.SingleOrDefault(x => x.LHSID==LHSID);
            if(kqht != null)
            {
                luuhs.KetQuaHocTaps.Remove(kqht);
            }
         

            //remove lhs_daotao
            LHS_DaoTao lhs_daotao = new LHS_DaoTao();
            lhs_daotao = luuhs.LHS_DaoTao.SingleOrDefault(x => x.LHSID == LHSID);
            if(lhs_daotao!=null)
            {
                luuhs.LHS_DaoTao.Remove(lhs_daotao);

            }
            

            //remove quyết định đi học
            QuyetDinhDiHoc qddh = new QuyetDinhDiHoc();
            qddh = luuhs.QuyetDinhDiHocs.SingleOrDefault(x => x.LHSID == LHSID);
            if(qddh!=null)
            {
                luuhs.QuyetDinhDiHocs.Remove(qddh);
            }
            

            //remove lhs về phép
            List<LHS_VePhep> lhs_vephep = new List<LHS_VePhep>();
            lhs_vephep = luuhs.LHS_VePhep.Where(x => x.LHSID == LHSID).ToList();
            if(lhs_vephep.Count!=0)
            {
                for (int i = 0; i < lhs_vephep.Count; i++)
                {
                    luuhs.LHS_VePhep.Remove(lhs_vephep[i]);
                }
            }
           
            //remove quá trình công tác
            QuaTrinhCongTac qtct = new QuaTrinhCongTac();
            qtct = luuhs.QuaTrinhCongTacs.SingleOrDefault(x => x.LHSID == LHSID);
            if(qtct != null)
            {
                luuhs.QuaTrinhCongTacs.Remove(qtct);
            }
           

            //remove thân nhân 
            ThanNhan thannhan = new ThanNhan();
            thannhan = luuhs.ThanNhans.SingleOrDefault(x => x.LHSID == LHSID);
            if(thannhan!=null)
            {
                luuhs.ThanNhans.Remove(thannhan);
            }
            

            //remove lưu học sinh
            LuuHocSinh lhs = new LuuHocSinh();
            lhs = luuhs.LuuHocSinhs.Find(LHSID);
            luuhs.LuuHocSinhs.Remove(lhs);
            luuhs.SaveChanges();
            return Redirect("~/LuuHS/Index");
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

        public ActionResult XuatPhieuLHS(int LHSID)
        {
            List<InforLHS> listlhs = new LUUHS().Database.SqlQuery<InforLHS>("exec getAll_LHS").ToList();
            InforLHS lhs = listlhs.Find(x => x.LHSID == LHSID);

            string targetfile = Server.MapPath("~/Content/Reports/Template/PhieuLHS1.docx");
            var doc = DocX.Load(targetfile);
            var doc1 = doc.Copy();
            foreach (var property in lhs.GetType().GetProperties())
            {
                var x = property.GetValue(lhs, null);

                if (x == null && property.PropertyType.ToString() == "System.String")
                {
                    x = "";
                    property.SetValue(lhs, x);
                }



            }
            doc1.ReplaceText("<malhs>", lhs.MaLHS);
            doc1.ReplaceText("<hoten>", lhs.Hoten);
            if (lhs.NgaySinh != null)
            {
                string str = lhs.NgaySinh.ToString();
                DateTime date = Convert.ToDateTime(str);
                string ngaysinh = "";
                string day = "";
                string month = "";
                string year = "";
                day = date.Day.ToString();
                if (day.Length == 1)
                {
                    day = "0" + day;
                }
                month = date.Month.ToString();
                if (month.Length == 1)
                {
                    month = "0" + month;
                }
                year = date.Year.ToString();
                if (year.Length == 1)
                {
                    year = "0" + year;
                }
                doc1.ReplaceText("<ngaysinh>", day + "/" + month + "/" + year);
            }
            else
            {
                doc1.ReplaceText("<ngaysinh>", lhs.NgaySinh.ToString());
            }

            doc1.ReplaceText("<quequan>", lhs.QueQuan);
            doc1.ReplaceText("<noiogd>", lhs.NoiOHienNay);
            doc1.ReplaceText("<diaban>", lhs.DiaBan);
            doc1.ReplaceText("<csdaotao>", lhs.CSDaoTao);
            doc1.ReplaceText("<bacdaotao>", lhs.BacDaoTao);
            doc1.ReplaceText("<khoa>", lhs.Khoa);
            doc1.ReplaceText("<bomon>", lhs.BoMon);
            string ndt = "";
            ndt = lhs.NganhDT1 + "," + lhs.NganhDT2;
            if (ndt.LastIndexOf(',') == ndt.Length - 1)
            {
                ndt = ndt.Remove(ndt.Length - 1);

            }
            doc1.ReplaceText("<nganhdt>", ndt);
            string cndt = "";
            cndt = lhs.CNDT1 + "," + lhs.CNDT2;
            if (cndt.LastIndexOf(',') == cndt.Length - 1)
            {
                cndt = cndt.Remove(cndt.Length - 1);

            }
            doc1.ReplaceText("<chuyennganhdt>", cndt);


            doc1.ReplaceText("<thoigiandaotao>", lhs.ThoiGianHoc);
            doc1.ReplaceText("<kinhphi>", lhs.DienKinhPhi);
            doc1.ReplaceText("<ki1>", lhs.Ki1.ToString());
            doc1.ReplaceText("<ki2>", lhs.Ki2.ToString());
            doc1.ReplaceText("<ki3>", lhs.Ki3.ToString());
            doc1.ReplaceText("<ki4>", lhs.Ki4.ToString());
            doc1.ReplaceText("<ki5>", lhs.Ki5.ToString());
            doc1.ReplaceText("<ki6>", lhs.Ki6.ToString());
            doc1.ReplaceText("<ki7>", lhs.Ki7.ToString());
            doc1.ReplaceText("<ki8>", lhs.Ki8.ToString());
            doc1.ReplaceText("<ki9>", lhs.Ki9.ToString());
            doc1.ReplaceText("<ki10>", lhs.Ki10.ToString());
            doc1.ReplaceText("<ki11>", lhs.Ki11.ToString());
            doc1.ReplaceText("<ki12>", lhs.Ki12.ToString());
            doc1.ReplaceText("<ki13>", lhs.Ki13.ToString());
            doc1.ReplaceText("<ki14>", lhs.Ki14.ToString());
            doc1.ReplaceText("<nomon>", lhs.LuuNoMon);
            doc1.ReplaceText("<khenthuong>", lhs.KhenThuong);
            doc1.ReplaceText("<kyluat>", lhs.KiLuat);
            string vephep = "";
            vephep = lhs.VePhepTC + "," + lhs.VePhepTT;
            if(vephep != ",")
            if (vephep.LastIndexOf(',') == vephep.Length - 1)
            {
                vephep = vephep.Remove(vephep.Length - 1);

            }
            if(vephep[0]==',')
            {
                vephep = vephep.Remove(0,1);
                
            }
            doc1.ReplaceText("<vephep>", vephep);
            doc1.ReplaceText("<thongtinllgd>", lhs.ThongTinLienLac);
            doc1.ReplaceText("<thongtingd>", lhs.ThongTinGiaDinh);
            
            using (var stream = new System.IO.MemoryStream())
            {
                doc1.SaveAs(stream);
                var content = stream.ToArray();
                return File(
                    content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "PhieuLuuHocSinh.docx");
            }
        }



    }
}
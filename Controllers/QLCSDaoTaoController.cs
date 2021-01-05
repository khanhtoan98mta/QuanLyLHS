using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDHS.Models.Entity;

namespace QLDHS.Controllers
{
    public class QLCSDaoTaoController : Controller
    {
        // GET: QLCSDaoTao
        public ActionResult Index()
        {
            LUUHS context = new LUUHS();
            List<DiaBanDaoTao> diabans = context.DiaBanDaoTaos.ToList();
            return View(diabans);
        }

        public ActionResult ThongtinCSDT(int IDDiaBan)
        {
            LUUHS context = new LUUHS();
            var csdataos = context.CoSoDaoTaos.Where(x => x.IDDiaBan == IDDiaBan).OrderBy(s => s.CSDaoTao);
            ViewBag.CSDTs = csdataos;
            ViewBag.IDDB = IDDiaBan;
            ViewData["TenDiaBan"] = context.DiaBanDaoTaos.SingleOrDefault(x => x.IDDiaBan == IDDiaBan).DiaBan;
            return View();
        }

        public ActionResult ThongtinKhoa(int MACSDT)
        {
            LUUHS context = new LUUHS();
            var khoas = context.KhoaDaoTaos.Where(x => x.MaCSDaoTao == MACSDT).OrderBy(x => x.TenKhoa);
            ViewBag.Khoas = khoas;
            ViewData["TenCSDT"] = context.CoSoDaoTaos.SingleOrDefault(x => x.MaCSDaoTao == MACSDT).CSDaoTao;
            ViewBag.MACSDT = MACSDT;

            return View();
        }

        public ActionResult ThongtinBoMon(int MaKhoa)
        {
            LUUHS context = new LUUHS();
            var bomons = context.BoMonDaoTaos.Where(x => x.MaKhoa == MaKhoa).OrderBy(x => x.TenBoMon);
            ViewBag.Bomons = bomons;
            ViewData["TenKhoa"] = context.KhoaDaoTaos.SingleOrDefault(x => x.MaKhoa == MaKhoa).TenKhoa;
            ViewBag.MaKhoa = MaKhoa;

            return View();
        }

        [HttpPost]
        public ActionResult ThemCSDT(int IDDiaBan,string[] CSDaoTao,int[] MaCSDT)
        {
            LUUHS context = new LUUHS();
            //luu thong tin cua nhung csdt da co
            List<CoSoDaoTao> CSDT_current = context.CoSoDaoTaos.Where(x => x.IDDiaBan == IDDiaBan).ToList();
            //neu so luong csdt hien tai lon hơn số được gửi đến
            if (CSDT_current.Count() > MaCSDT.Count())
            {

            }

            if (CSDaoTao != null)
            {

                for (int i = 0; i < CSDaoTao.Length; i++)
                {
                    if (CSDT_current!=null && i<CSDT_current.Count)
                    {
                        int macsdt = MaCSDT[i];
                        CoSoDaoTao csdt = context.CoSoDaoTaos.Single(a => a.MaCSDaoTao == macsdt);
                        csdt.CSDaoTao = CSDaoTao[i];
                        context.SaveChanges();
                    }
                    else
                    {
                        CoSoDaoTao csdt = new CoSoDaoTao();
                        csdt.CSDaoTao = CSDaoTao[i];
                        csdt.MaCSDaoTao = context.CoSoDaoTaos.Count() + 1;
                        csdt.IDDiaBan = IDDiaBan;
                        context.CoSoDaoTaos.Add(csdt);
                        context.SaveChanges();
                    }
                }
            }


                return Redirect("/QLCSDaoTao/ThongtinCSDT?IDDiaBan="+IDDiaBan);
        }

        [HttpPost]
        public ActionResult ThemKhoa(int MaCSDaoTao, string[] Khoa,int[] MaKhoa)
        {

            LUUHS context = new LUUHS();

            if (Khoa != null)
            {
                //luu thong tin cua nhung csdt da co
                List<KhoaDaoTao> Khoa_current = context.KhoaDaoTaos.Where(x => x.MaCSDaoTao == MaCSDaoTao).ToList();
                for (int i = 0; i < Khoa.Length; i++)
                {
                    if(Khoa[i] !="")
                    if (Khoa_current != null && i < Khoa_current.Count)
                    {
                        int ma = MaKhoa[i];
                        KhoaDaoTao khoa = context.KhoaDaoTaos.Single(a => a.MaKhoa == ma);
                        khoa.TenKhoa = Khoa[i];
                        context.SaveChanges();
                    }
                    else
                    {
                        KhoaDaoTao khoa = new KhoaDaoTao();
                        khoa.TenKhoa = Khoa[i];
                        khoa.MaKhoa = context.KhoaDaoTaos.Count() + 1;
                        khoa.MaCSDaoTao = MaCSDaoTao;
                        context.KhoaDaoTaos.Add(khoa);
                        context.SaveChanges();
                    }
                }
            }


            return Redirect("/QLCSDaoTao/ThongtinKhoa?MACSDT=" + MaCSDaoTao);
        }

        [HttpPost]
        public ActionResult ThemBoMon(int MaKhoa, string[] BoMon, int[] MaBoMon)
        {
            LUUHS context = new LUUHS();
            //xoa những bộ môn không có trong mã bộ môn

            if (BoMon != null)
            {
                List<BoMonDaoTao> BoMon_current = context.BoMonDaoTaos.Where(x => x.MaKhoa == MaKhoa).ToList();
                //luu thong tin cua nhung csdt da co
                for (int i = 0; i < BoMon.Length; i++)
                {
                    if (BoMon[i] != "")
                        if (BoMon_current != null && i < BoMon_current.Count)
                        {
                            int ma = MaBoMon[i];
                            BoMonDaoTao bomon = context.BoMonDaoTaos.Single(a => a.MaBM == ma);
                            bomon.TenBoMon = BoMon[i];
                            context.SaveChanges();
                        }
                        else
                        {
                            BoMonDaoTao bomon = new BoMonDaoTao();
                            bomon.TenBoMon = BoMon[i];
                            bomon.MaBM = context.BoMonDaoTaos.Count() + 1;
                            bomon.MaKhoa = MaKhoa;
                            context.BoMonDaoTaos.Add(bomon);
                            context.SaveChanges();
                        }
                }
            }


            return Redirect("/QLCSDaoTao/ThongtinBoMon?MaKhoa=" + MaKhoa);
        }

        [HttpPost]
        public string XoaBoMon(int MaBoMon)
        {
            LUUHS context = new LUUHS();
            try
            {
                if (MaBoMon.ToString() != "")
                {
                    BoMonDaoTao bomon = context.BoMonDaoTaos.Single(x => x.MaBM == MaBoMon);
                    context.BoMonDaoTaos.Remove(bomon);
                    //không có sinh viên nào học bộ môn này...

                    context.SaveChanges();
                }
                return "Xoa thành công";
            }
            catch (Exception)
            {

                return "Xóa không thành công";
            }

        }

        [HttpPost]
        public string XoaKhoa(int MaKhoa)
        {
            LUUHS context = new LUUHS();
            try
            {
                if (MaKhoa.ToString() != "")
                {
                    KhoaDaoTao khoa = context.KhoaDaoTaos.Single(x => x.MaKhoa == MaKhoa);
                    context.KhoaDaoTaos.Remove(khoa);
                    //không có sinh viên nào học bộ môn này...

                    context.SaveChanges();
                }
                return "Xoa thành công";
            }
            catch (Exception)
            {

                return "Xóa không thành công! Khoa chưa trống!";
            }

        }

        [HttpPost]
        public string XoaCSDT(int MaCSDT)
        {
            LUUHS context = new LUUHS();
            try
            {
                if (MaCSDT.ToString() != "")
                {
                    CoSoDaoTao coso = context.CoSoDaoTaos.Single(x => x.MaCSDaoTao == MaCSDT);
                    context.CoSoDaoTaos.Remove(coso);
                    //không có sinh viên nào học bộ môn này...

                    context.SaveChanges();
                }
                return "Xóa thành công";
            }
            catch (Exception)
            {

                return "Xóa không thành công! Cơ sở đào tạo chưa trống!";
            }

        }
    }
}
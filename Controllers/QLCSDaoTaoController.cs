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
            ViewBag.TenDiaBan = context.DiaBanDaoTaos.SingleOrDefault(x => x.IDDiaBan == IDDiaBan).DiaBan;
            return View();
        }

        public ActionResult ThongtinKhoa(int MACSDT)
        {
            LUUHS context = new LUUHS();
            var khoas = context.KhoaDaoTaos.Where(x => x.MaCSDaoTao == MACSDT).OrderBy(x => x.TenKhoa);
            ViewBag.Khoas = khoas;
            ViewBag.TenCSDT = context.CoSoDaoTaos.SingleOrDefault(x => x.MaCSDaoTao == MACSDT).CSDaoTao;

            return View();
        }

        public ActionResult ThongtinBoMon(int MaKhoa)
        {
            LUUHS context = new LUUHS();
            var bomons = context.BoMonDaoTaos.Where(x => x.MaKhoa == MaKhoa).OrderBy(x => x.TenBoMon);
            ViewBag.Bomons = bomons;
            ViewBag.TenKhoa = context.KhoaDaoTaos.SingleOrDefault(x => x.MaKhoa == MaKhoa).TenKhoa;

            return View();
        }

        [HttpPost]
        public string ThemCSDT(int IDDiaBan,string[] CSDaoTao)
        {
            LUUHS context = new LUUHS();

            if (CSDaoTao != null)
            {
                //luu thong tin cua nhung csdt da co
                List<CoSoDaoTao> CSDT_current = context.CoSoDaoTaos.Where(x => x.IDDiaBan == IDDiaBan).ToList();
                for (int i = 0; i < CSDaoTao.Length; i++)
                {
                    if (CSDT_current!=null && i<CSDT_current.Count)
                    {

                        int macsdt = CSDT_current.ElementAt(i).MaCSDaoTao;
                        CoSoDaoTao csdt = context.CoSoDaoTaos.Single(a => a.MaCSDaoTao == macsdt);
                        csdt.CSDaoTao = CSDaoTao[i];
                        context.SaveChanges();


                    }
                    else
                    {
                        CoSoDaoTao csdt = new CoSoDaoTao();
                        csdt.CSDaoTao = CSDaoTao[i];
                        csdt.MaCSDaoTao = context.CoSoDaoTaos.Count() + 1;
                        context.CoSoDaoTaos.Add(csdt);
                        context.SaveChanges();
                    }
                }
            }


                return "Thêm cơ sở đào tạo thành công";
        }

        [HttpPost]
        public string ThemKhoa()
        {
            return "Thêm khoa thành công";
        }

        [HttpPost]
        public string ThemBoMon()
        {
            return "Thêm bộ môn thành công";
        }
    }
}
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
            return View();
        }

        public ActionResult ThongtinCSDT(int IDDiaBan)
        {
            LUUHS context = new LUUHS();
            var csdataos = context.CoSoDaoTaos.Where(x => x.IDDiaBan  == IDDiaBan).OrderBy(s =>s.CSDaoTao);
            ViewBag.CSDTs = csdataos;
            ViewBag.TenDiaBan = context.DiaBanDaoTaos.SingleOrDefault(x => x.IDDiaBan == IDDiaBan).DiaBan;
            return View();
        }

        public ActionResult ThongtinKhoa(int MACSDT )
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
    }
}
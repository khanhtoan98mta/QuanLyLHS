using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDHS.Models.Entity;
using QLDHS.Models.Model_view;

namespace QLDHS.Controllers
{
    public class QLCSDaoTaoController : Controller
    {
        // GET: QLCSDaoTao
        public ActionResult Index()
        {
            LUUHS context = new LUUHS();
            //List<model_DiaBanDT> listdb = new List<model_DiaBanDT>();
            int year = DateTime.Today.Year;
            SqlParameter year_para = new SqlParameter("@year", year);
            var listdb = new LUUHS().Database.SqlQuery<model_DiaBanDT>("exec dbo.DsDiaBan @year", year_para).ToList();
            return View(listdb);
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

        public ActionResult ThongTinNganhDaoTao()
        {
            LUUHS context = new LUUHS();
            List<NganhDaoTao> list_nganhdt = context.NganhDaoTaos.ToList();

            ViewBag.list_nganhdt = list_nganhdt;
            return View();

        }

        [HttpPost]
        public ActionResult ThemNganhDaoTao(string[] TenNganh, int[] MaNganh)
        {
            LUUHS context = new LUUHS();

            if (TenNganh != null)
            {
                List<NganhDaoTao> Nganh_current = context.NganhDaoTaos.ToList();
                //luu thong tin cua nhung csdt da co
                for (int i = 0; i < TenNganh.Length; i++)
                {
                    if (TenNganh[i] != "")
                        if (Nganh_current != null && i < Nganh_current.Count)
                        {
                            int ma = MaNganh[i];
                            NganhDaoTao nganhdaotao = context.NganhDaoTaos.Single(a => a.MaNganh == ma);
                            nganhdaotao.NganhDaoTao1 = TenNganh[i];
                            context.SaveChanges();
                        }
                        else
                        {
                            NganhDaoTao nganhdaotao = new NganhDaoTao();
                            nganhdaotao.NganhDaoTao1 = TenNganh[i];
                            nganhdaotao.MaNganh = context.NganhDaoTaos.Count() + 1;
                            context.NganhDaoTaos.Add(nganhdaotao);
                            context.SaveChanges();
                        }
                }
            }
            return Redirect("/QLCSDaoTao/ThongTinNganhDaoTao");
        }

        public string XoaNganhDaoTao(int MaNganh)
        {
            LUUHS context = new LUUHS();
            try
            {
                if (MaNganh != 0)
                {
                    NganhDaoTao khoa = context.NganhDaoTaos.Single(x => x.MaNganh == MaNganh);
                    context.NganhDaoTaos.Remove(khoa);
                    //không có sinh viên nào học bộ môn này...

                    context.SaveChanges();
                }
                return "1";
            }
            catch (Exception)
            {

                return "0";
            }
        }
        public ActionResult ThongTinChuyenNganhDaoTao(int MaNganh)
        {
            LUUHS context = new LUUHS();
            List<ChuyenNganhDaoTao> chuyennganh = context.ChuyenNganhDaoTaos.Where(x => x.MaNganh == MaNganh).ToList();
            ViewBag.chuyennganh = chuyennganh;
            ViewBag.MaNganh = MaNganh;
            return View();

        }

        [HttpPost]
        public ActionResult ThemChuyenNganhDaoTao(int MaNganh,string[] TenChuyenNganh, int[] MaChuyenNganh)
        {
            LUUHS context = new LUUHS();

            if (TenChuyenNganh != null)
            {
                List<ChuyenNganhDaoTao> ChuyenNganh_current = context.ChuyenNganhDaoTaos.Where(x=>x.MaNganh == MaNganh).ToList();
                //luu thong tin cua nhung csdt da co
                for (int i = 0; i < TenChuyenNganh.Length; i++)
                {
                    if (TenChuyenNganh[i] != "")
                        if (ChuyenNganh_current != null && i < ChuyenNganh_current.Count)
                        {
                            int ma = MaChuyenNganh[i];
                            ChuyenNganhDaoTao nganhdaotao = context.ChuyenNganhDaoTaos.Single(a => a.MaChuyenNganh == ma);
                            nganhdaotao.ChuyenNganhDaoTao1 = TenChuyenNganh[i];
                            context.SaveChanges();
                        }
                        else
                        {
                            ChuyenNganhDaoTao nganhdaotao = new ChuyenNganhDaoTao();
                            nganhdaotao.ChuyenNganhDaoTao1 = TenChuyenNganh[i];
                            nganhdaotao.MaChuyenNganh = context.NganhDaoTaos.Count() + 1;
                            nganhdaotao.MaNganh = MaNganh;
                            context.ChuyenNganhDaoTaos.Add(nganhdaotao);
                            context.SaveChanges();
                        }
                }
            }
            return Redirect("/QLCSDaoTao/ThongTinChuyenNganhDaoTao?MaNganh="+MaNganh);
        }

        [HttpPost]
        public string XoaChuyenNganhDaoTao(int MaChuyenNganh)
        {
            LUUHS context = new LUUHS();
            try
            {
                if (MaChuyenNganh != 0)
                {
                    ChuyenNganhDaoTao khoa = context.ChuyenNganhDaoTaos.Single(x => x.MaChuyenNganh == MaChuyenNganh);
                    context.ChuyenNganhDaoTaos.Remove(khoa);
                    //không có sinh viên nào học bộ môn này...

                    context.SaveChanges();
                }
                return "1";
            }
            catch (Exception)
            {

                return "0";
            }
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
                return "1";
            }
            catch (Exception)
            {

                return "0";
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
                return "1";
            }
            catch (Exception)
            {

                return "0";
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
                return "1";
            }
            catch (Exception)
            {

                return "0";
            }

        }
    }
}
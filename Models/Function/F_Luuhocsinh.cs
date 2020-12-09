using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLDHS.Models.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.Entity.Migrations;

namespace QLDHS.Models.Function
{
    public class Thongke_lhs_time_class
    {
        public string madiaban { get; set; }
        public string diaban { get; set; }
        public int soluong { get; set; }

       
    }    

    public class F_Luuhocsinh
    {


        List<InforLHS> allInfoLHS = new LUUHS().Database.SqlQuery<InforLHS>("exec dbo.getAll_LHS").ToList();

        /// <summary>
        /// Lấy danh sách tất cả lưu học sinh
        /// </summary>
        /// <returns></returns>
        public List<InforLHS> GetAll_LHS()
        {                         
            return allInfoLHS;
        }

        public InforLHS Detai_LHS_Ma(int LHSID)
        {
            return allInfoLHS.Single(x => x.LHSID == LHSID);

        }

        public List<Thongke_lhs_time_class> Thongke_LHS_time(int year)
        {
            LUUHS lhs = new LUUHS();
            SqlParameter endDate = new SqlParameter("@date", year);
            endDate.SqlDbType = SqlDbType.Int;
            return lhs.Database.SqlQuery<Thongke_lhs_time_class>("exec dbo.ThongKe_LHS_ThoiGian @date",  endDate).ToList();
            
        }

        public bool ChangeImageLHS(int id,string image)
        {
            using (var db = new LUUHS())
            {
                var result = db.LuuHocSinhs.Single(b => b.LHSID == id);
                if (result != null)
                {
                    result.Image = image;
                    db.SaveChanges();
                }
            }
            return true;
        }

        public bool EditThongtincoban(Thongtincoban info)
        {
            LUUHS db = new LUUHS();
            LuuHocSinh lhs = new LuuHocSinh();
            lhs = db.LuuHocSinhs.Single(x => x.LHSID == info.LHSID);
            try
            {
                if (lhs != null)
                {
                    lhs.HoTen = info.HoTen;
                    lhs.NgaySinh = info.NgaySinh;
                    lhs.GioiTinh = info.GioiTinh;
                    lhs.DanToc = info.DanToc;
                    lhs.TonGiao = info.TonGiao;
                    lhs.Mien = info.Mien;
                    lhs.ThongTinLienLac = info.ThongTinLienLac;
                    lhs.MaDoiTuong = info.MaDoiTuong;
                    lhs.QueQuan = info.QueQuan;
                   
                    lhs.SoHieuSiQuan = info.SoHieuSiQuan;
                    lhs.NgayNhapNgu = info.NgayNhapNgu;
                    lhs.NgayVaoDoan = info.NgayVaoDoan;
                    lhs.NgayVaoDang = info.Ngayvaodang;
                    lhs.NgayChuyenDangCT = info.Ngaychuyendangchinhthuc;
                    lhs.NghienCuuNoiBat = info.Linhvucthemanh;                    
                }
                db.SaveChanges();
                ThanNhan thannhan;
                if (db.ThanNhans.SingleOrDefault(x => x.LHSID == lhs.LHSID) != null)
                {
                    thannhan = db.ThanNhans.SingleOrDefault(x => x.LHSID == lhs.LHSID);
                    thannhan.NoiOHienNay = info.NoiOHienNay;
                    thannhan.DiaChiLienLac = info.Diachilienlacgiadinh;
                    thannhan.CanBo = info.Conemcanbo;
                    thannhan.ThanhPhanGiaDinh = info.Thanhphangiadinh;
                    thannhan.ThongTinGiaDinh = info.Thongtinbo + "/" + info.Thongtinme;
                    db.SaveChanges();
                }
                else
                {

                    thannhan = new ThanNhan {
                    NoiOHienNay = info.NoiOHienNay,
                    DiaChiLienLac = info.Diachilienlacgiadinh,
                    CanBo = info.Conemcanbo,
                    ThanhPhanGiaDinh = info.Thanhphangiadinh,
                    ThongTinGiaDinh = info.Thongtinbo + "/" + info.Thongtinme,
                    LHSID = lhs.LHSID,
                    MaThanNhan = lhs.LHSID,
                    QuanHe = "Bố Mẹ"
                    };
                    db.ThanNhans.Add(thannhan);
                    db.SaveChanges();

                }

                
               
                return true;
            }
            catch (Exception)
            {

                return false;
            }



            
        }

        public bool EditLHSTTDaotao(Thongtindaotao info)
        {

           
                LUUHS db = new LUUHS();
                LuuHocSinh lhs = db.LuuHocSinhs.SingleOrDefault(x => x.LHSID == info.LHSID);
                LuanVanTotNghiep lvtn;
                KetQuaHocTap kqht;
                QuyetDinhDiHoc qd;
                LHS_DaoTao lhs_daotao;
            try
            {
                if (lhs != null)
                {
                    if (db.LHS_DaoTao.SingleOrDefault(x => x.LHSID == lhs.LHSID) == null)
                    {
                        lhs_daotao = new LHS_DaoTao
                        {
                            ID = lhs.LHSID,
                            LHSID = lhs.LHSID,
                            
                            MaBMDaoTao = info.BoMon,
                            MaBacDaoTao = info.MaBacDaoTao,
                            MaCNDaoTao1 = info.CNDT1,
                            MaCNDaoTao2 = info.CNDT2,                            
                            ThoiGianBatDau = info.ThoiGianBatDauHoc,                            
                            ThoiGianKetThuc = info.ThoiGianKetThucHoc,
                            ThoiGianDaoTao = "5 Năm",
                            TinhTrangTotNghiep = info.TinhTrangTotNghiep,
                        };
                        if (info.BoMon ==-1)
                        {
                            lhs_daotao.MaBMDaoTao = null;
                        }
                        db.LHS_DaoTao.Add(lhs_daotao);
                        db.SaveChanges();
                    }
                    else
                    {
                      
                        lhs_daotao = db.LHS_DaoTao.SingleOrDefault(x => x.LHSID == lhs.LHSID);     
                        lhs_daotao.MaBMDaoTao = info.BoMon;
                        
                        lhs.MaDKP = info.MaDienKinhPhi;
                        lhs_daotao.MaBacDaoTao = info.MaBacDaoTao;


                        lhs_daotao.MaCNDaoTao1 = info.CNDT1;
                        lhs_daotao.MaCNDaoTao2 = info.CNDT2;

                        lhs_daotao.ThoiGianBatDau = info.ThoiGianBatDauHoc;
                        lhs_daotao.ThoiGianKetThuc = info.ThoiGianKetThucHoc;
                        lhs_daotao.TinhTrangTotNghiep = info.TinhTrangTotNghiep;

                        if (info.BoMon == -1)
                        {
                            lhs_daotao.MaBMDaoTao = null;
                        }
                        db.SaveChanges();
                    }
                    

                    //them moi luan van tot nghiep
                    if (db.LuanVanTotNghieps.SingleOrDefault(x => x.LHSID == lhs.LHSID)==null)
                    {
                        lvtn = new LuanVanTotNghiep();
                       
                        lvtn.LHSID = lhs.LHSID;
                        lvtn.TenLuanVan = info.TenLuanVan;
                        lvtn.KetQuaBaoVe = info.KetQuaBaoVe;
                        db.LuanVanTotNghieps.Add(lvtn);
                        db.SaveChanges();

                    }
                    else
                    {
                        lvtn = db.LuanVanTotNghieps.SingleOrDefault(x => x.LHSID == lhs.LHSID);
                        lvtn.LHSID = lhs.LHSID;
                        lvtn.TenLuanVan = info.TenLuanVan;
                        lvtn.KetQuaBaoVe = info.KetQuaBaoVe;
                        db.SaveChanges();

                    }


                    //them ket qua hoc tap
                    if (db.KetQuaHocTaps.SingleOrDefault(x =>x.LHSID==lhs.LHSID)==null)
                    {
                        kqht = new KetQuaHocTap();
                        kqht.MaKetQua = lhs.LHSID;
                        kqht.Ki1 = info.Ki1;
                        kqht.Ki2 = info.Ki2;
                        kqht.Ki3 = info.Ki3;
                        kqht.Ki4 = info.Ki4;
                        kqht.Ki5 = info.Ki5;
                        kqht.Ki6 = info.Ki6;
                        kqht.Ki7 = info.Ki7;
                        kqht.Ki8 = info.Ki8;
                        kqht.Ki9 = info.Ki9;
                        kqht.Ki10 = info.Ki10;
                        kqht.Ki11 = info.Ki11;
                        kqht.Ki12 = info.Ki12;
                        kqht.Ki13 = info.Ki13;
                        kqht.Ki14 = info.Ki14;
                        kqht.DiemTrungBinh = info.DiemTrungBinh;
                        kqht.MoTaKetQua = info.MoTaKetQua;
                        kqht.LuuNoMon = info.LuuNoMon;
                        kqht.PhanLoaiTotNghiep = info.PhanLoaiTotNghiep;
                        db.KetQuaHocTaps.Add(kqht);
                        db.SaveChanges();
                    }
                    else
                    {
                        kqht = db.KetQuaHocTaps.SingleOrDefault(x => x.LHSID == lhs.LHSID);
                        kqht.Ki1 = info.Ki1;
                        kqht.Ki2 = info.Ki2;
                        kqht.Ki3 = info.Ki3;
                        kqht.Ki4 = info.Ki4;
                        kqht.Ki5 = info.Ki5;
                        kqht.Ki6 = info.Ki6;
                        kqht.Ki7 = info.Ki7;
                        kqht.Ki8 = info.Ki8;
                        kqht.Ki9 = info.Ki9;
                        kqht.Ki10 = info.Ki10;
                        kqht.Ki11 = info.Ki11;
                        kqht.Ki12 = info.Ki12;
                        kqht.Ki13 = info.Ki13;
                        kqht.Ki14 = info.Ki14;
                        kqht.DiemTrungBinh = info.DiemTrungBinh;
                        kqht.MoTaKetQua = info.MoTaKetQua;
                        kqht.LuuNoMon = info.LuuNoMon;
                        kqht.PhanLoaiTotNghiep = info.PhanLoaiTotNghiep;
                        db.SaveChanges();
                    }



                    //quan ham
                    //nam nhan quan ham
                    //khenthuong
                    //kiluat
                    //vepheptieuchuan
                    //vepheptutuc

                    lhs.HocPhi = info.HocPhi;
                    lhs.SinhHoatPhi = info.SinhHoatPhi;
                    lhs.BHYT = info.BHYT;
                    lhs.ChiPhiKhac = info.ChiPhiKhac;
                    lhs.KhenThuong = info.KhenThuong;
                    lhs.KiLuat = info.KiLuat;



                    if (db.QuyetDinhDiHocs.SingleOrDefault(x => x.LHSID == lhs.LHSID)!= null)
                    {
                        qd = db.QuyetDinhDiHocs.SingleOrDefault(x => x.LHSID == lhs.LHSID);
                        qd.QuyetDinhDiHoc1 = info.QuyetDinhDiHoc;
                        qd.ThoiGianDi = info.ThoiGianDi;
                        qd.ThoiGianVe = info.ThoiGianVe;

                        db.SaveChanges();
                    }
                    else
                    {
                        qd = new QuyetDinhDiHoc();
                        qd.QuyetDinhDiHoc1 = info.QuyetDinhDiHoc;
                        qd.LHSID = lhs.LHSID;
                        db.QuyetDinhDiHocs.Add(qd);

                        db.SaveChanges();
                    }
                    

                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
            

        }

        public int AddNewLHS(LuuHocSinh lhs)
        {
            using (LUUHS luuhs = new LUUHS())
            {
                try
                {                    
                    luuhs.LuuHocSinhs.Add(lhs);
                    luuhs.SaveChanges();
                    int id = lhs.LHSID;
                    // add LHS_Daotao
                    LHS_DaoTao lhs_daotao = new LHS_DaoTao();
                    lhs_daotao.LHSID = id;
                    luuhs.LHS_DaoTao.Add(lhs_daotao);
                    //add LuanVan
                    LuanVanTotNghiep lvtn = new LuanVanTotNghiep();
                    lvtn.LHSID = id;
                    luuhs.LuanVanTotNghieps.Add(lvtn);
                    // add Ket qua hoc tap
                    KetQuaHocTap kqht = new KetQuaHocTap();
                    kqht.LHSID = id;
                    luuhs.KetQuaHocTaps.Add(kqht);
                    //add qua trinh cong tac
                    QuaTrinhCongTac qtct = new QuaTrinhCongTac();
                    qtct.LHSID = id;
                    luuhs.QuaTrinhCongTacs.Add(qtct);
                    //add quyet dinh di hoc
                    QuyetDinhDiHoc qddh = new QuyetDinhDiHoc();
                    qddh.LHSID = id;
                    luuhs.QuyetDinhDiHocs.Add(qddh);
                    luuhs.SaveChanges();
                    return id;
                }
                catch (Exception)
                {

                    return -1;
                }             
            }
        }

    }
}
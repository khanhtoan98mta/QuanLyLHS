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

        public InforLHS Detai_LHS_Ma(string malhs)
        {           
            foreach (var item in allInfoLHS)
            {
                if (item.MaLHS == null)
                {
                    continue;
                }
                if (item.MaLHS.TrimEnd() == malhs)
                {
                    return item;
                }
            }


            return null;



        }

        public List<Thongke_lhs_time_class> Thongke_LHS_time(int year)
        {
            LUUHS lhs = new LUUHS();
            SqlParameter endDate = new SqlParameter("@date", year);
            endDate.SqlDbType = SqlDbType.Int;
            return lhs.Database.SqlQuery<Thongke_lhs_time_class>("exec dbo.ThongKe_LHS_ThoiGian @date",  endDate).ToList();
            
        }

        public bool ChangeImageLHS(string id,string image)
        {
            using (var db = new LUUHS())
            {
                var result = db.LuuHocSinhs.SingleOrDefault(b => b.MaLHS == id);
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
            LuuHocSinh lhs = db.LuuHocSinhs.SingleOrDefault(x => x.MaLHS == info.MaLHS);
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
                    lhs.MaDVBM = info.BoMon;
                    lhs.SoHieuSiQuan = info.SoHieuSiQuan;
                    lhs.NgayNhapNgu = info.NgayNhapNgu;
                    lhs.NgayVaoDoan = info.NgayVaoDoan;
                    lhs.NgayVaoDang = info.Ngayvaodang;
                    lhs.NgayChuyenDangCT = info.Ngaychuyendangchinhthuc;
                    lhs.NghienCuuNoiBat = info.Linhvucthemanh;
                }

                ThanNhan thannhan;
                if (db.ThanNhans.SingleOrDefault(x=>x.LHSID==lhs.LHSID) != null)
                {
                    thannhan = db.ThanNhans.SingleOrDefault(x => x.LHSID == lhs.LHSID);
                    thannhan.NoiOHienNay = info.NoiOHienNay;
                    thannhan.DiaChiLienLac = info.Diachilienlacgiadinh;
                    thannhan.CanBo = info.Conemcanbo;
                    thannhan.ThanhPhanGiaDinh = info.Thanhphangiadinh;
                    thannhan.ThongTinGiaDinh = info.Thongtinbo + "/" + info.Thongtinme;
                    
                }
                else
                {

                    thannhan = new ThanNhan();                  
                    thannhan.NoiOHienNay = info.NoiOHienNay;
                    thannhan.DiaChiLienLac = info.Diachilienlacgiadinh;
                    thannhan.CanBo = info.Conemcanbo;
                    thannhan.ThanhPhanGiaDinh = info.Thanhphangiadinh;
                    thannhan.ThongTinGiaDinh = info.Thongtinbo + "/" + info.Thongtinme;
                    thannhan.LHSID = lhs.LHSID;
                    db.ThanNhans.Add(thannhan);

                }

                
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }



            
        }

        public bool EditLHSTTDaotao(Thongtindaotao info)
        {

            try
            {
                LUUHS db = new LUUHS();
                LuuHocSinh lhs = db.LuuHocSinhs.SingleOrDefault(x => x.MaLHS == info.MaLHS);
                if (lhs != null)
                {
                    
                    var lhs_daotao = db.LHS_DaoTao.SingleOrDefault(x => x.LHSID == lhs.LHSID);
                    lhs_daotao.MaCSDaoTao = info.CSDaoTao;

                    lhs.MaDKP = info.DienKinhPhi;
                    lhs_daotao.MaBacDaoTao = info.BacDaoTao;
                    lhs_daotao.MaCNDaoTao1 = info.CNDT1;
                    lhs_daotao.MaCNDaoTao2 = info.CNDT2;
                    //nganhdaotao
                    //nganhdaotao
                    lhs_daotao.ThoiGianBatDau = info.ThoiGianBatDauHoc;
                    lhs_daotao.ThoiGianKetThuc = info.ThoiGianKetThucHoc;
                    lhs_daotao.TinhTrangTotNghiep = info.TinhTrangTotNghiep;
                    //them moi luan van tot nghiep
                    LuanVanTotNghiep lvtn = db.LuanVanTotNghieps.SingleOrDefault(x => x.LHSID == lhs.LHSID);
                    lvtn.LHSID = lhs.LHSID;
                    lvtn.TenLuanVan = info.TenLuanVan;
                    lvtn.KetQuaBaoVe = info.KetQuaBaoVe;                    
                    db.LuanVanTotNghieps.AddOrUpdate(lvtn);
                    //them ket qua hoc tap
                    KetQuaHocTap kqht = db.KetQuaHocTaps.SingleOrDefault(x => x.LHSID == lhs.LHSID);
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
                    db.KetQuaHocTaps.AddOrUpdate(kqht);
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

                    QuyetDinhDiHoc qd = db.QuyetDinhDiHocs.SingleOrDefault(x => x.LHSID == lhs.LHSID);
                    qd.QuyetDinhDiHoc1 = info.QuyetDinhDuHoc;
                    db.QuyetDinhDiHocs.AddOrUpdate(qd);

                    db.SaveChanges();

                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
            

        }

        public bool AddNewLHS(LuuHocSinh lhs)
        {
            using (LUUHS luuhs = new LUUHS())
            {
                try
                {                    
                    luuhs.LuuHocSinhs.Add(lhs);
                    luuhs.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }             
            }
        }

    }
}
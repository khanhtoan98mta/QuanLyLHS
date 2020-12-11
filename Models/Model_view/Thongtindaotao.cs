using QLDHS.Models.Model_view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDHS.Models.Entity
{
    public class Thongtindaotao
    {
        public int LHSID { get; set; }
        public string MaLHS { get; set; }
        public string Diaban { get; set; }
        public int CSDaoTao { get; set; }
        public int MaDienKinhPhi { get; set; }
        public int MaBacDaoTao { get; set; }
        public int NganhDT1 { get; set; }
        public int? CNDT1 { get; set; }
        public int NganhDT2 { get; set; }
        public int? CNDT2 { get; set; }
        public DateTime? ThoiGianBatDauHoc { get; set; }
        public DateTime? ThoiGianKetThucHoc { get; set; }
        public int? TinhTrangTotNghiep { get; set; }
        public string TenLuanVan { get; set; }
        public double? Ki1 { get; set; }
        public double? Ki2 { get; set; }
        public double? Ki3 { get; set; }
        public double? Ki4 { get; set; }
        public double? Ki5 { get; set; }
        public double? Ki6 { get; set; }
        public double? Ki7 { get; set; }
        public double? Ki8 { get; set; }
        public double? Ki9 { get; set; }
        public double? Ki10 { get; set; }
        public double? Ki11 { get; set; }
        public double? Ki12 { get; set; }
        public double? Ki13 { get; set; }
        public double? Ki14 { get; set; }
        public string MoTaKetQua { get; set; }
        public string LuuNoMon { get; set; }
        public double? DiemTrungBinh { get; set; }
        public string KetQuaBaoVe { get; set; }
        public string PhanLoaiTotNghiep { get; set; }
        public string QuanHam { get; set; }
        public DateTime? NgayNhanQuanHam { get; set; }
        public string KhenThuong { get; set; }
        public string KiLuat { get; set; }
        public string VePhepTieuChuan { get; set; }
        public string VePhepTT { get; set; }
        public float? HocPhi { get; set; }
        public float? SinhHoatPhi { get; set; }
        public float? BHYT { get; set; }
        public float? ChiPhiKhac { get; set; }
        public string QuyetDinhDiHoc { get; set; }
        public int Khoa { get; set; }
        public int BoMon { get; set; }
        public DateTime? ThoiGianDi { get; set; }
        public DateTime? ThoiGianVe { get; set; }
        public List<DsVePhep> dsvephep { get; set; }
        public int? MaQuanHam { get; set; }



    }
}
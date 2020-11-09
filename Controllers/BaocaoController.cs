using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using QLDHS.Models.Function;
using QLDHS.Models.Entity;
using System.Web.UI;
using ClosedXML.Excel;
using ClosedXML;
using Newtonsoft.Json.Linq;

namespace QLDHS.Controllers
{
    public class BaocaoController : Controller
    {
        // GET: Baocao
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// báo cáo 1 : báo cáo về vấn đề thống kê số lượng lưu học sinh của các nước
        /// </summary>
        /// <returns></returns>
        public ActionResult Baocao_Excel_1()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Thong ke so luong luu hoc sinh");
                var current_row = 1;

                #region header
                worksheet.Cell(current_row, 1).Value = "Mã nước";
                worksheet.Cell(current_row, 2).Value = "Nước";
                worksheet.Cell(current_row, 3).Value = "Số lượng";
                #endregion


                #region thân
                foreach (var item in new F_Luuhocsinh().Thongke_LHS_time(2019))
                {
                    current_row++;
                    worksheet.Cell(current_row, 1).Value = item.madiaban;
                    worksheet.Cell(current_row, 2).Value = item.diaban;
                    worksheet.Cell(current_row, 3).Value = item.soluong;
                }
                #endregion

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ThongkeLHSCountry.xlsx");
                }
            }

        }


        /// <summary>
        /// xuất báo cáo 2 : báo cáo về vấn đề tiền sinh hoạt của học viên lưu học sinh
        /// </summary>
        /// <returns></returns>
        public ActionResult Baocao_Excel_2()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Thong ke so luong luu hoc sinh");
                var current_row = 1;

                #region header
                worksheet.Cell(current_row, 1).Value = "Mã nước";
                worksheet.Cell(current_row, 2).Value = "Nước";
                worksheet.Cell(current_row, 3).Value = "Số lượng";
                #endregion


                #region thân
                foreach (var item in new F_Luuhocsinh().Thongke_LHS_time(2019))
                {
                    current_row++;
                    worksheet.Cell(current_row, 1).Value = item.madiaban;
                    worksheet.Cell(current_row, 2).Value = item.diaban;
                    worksheet.Cell(current_row, 3).Value = item.soluong;
                }
                #endregion

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ThongkeLHSCountry.xlsx");
                }
            }

        }
        public static string jsonData = @"{  
        'Hoten' : 'Họ tên',
        'MaLHS' : 'Mã LHS',
        'NgaySinh' : 'Ngày sinh',
        'ThongTinLienLac' : 'Thông tin liên lạc',
        'QueQuan' : 'Quê quán',
        'GioiTinh' : 'Giới TÍNH',
        'SoHieuSiQuan' : 'SỐ HIỆU SĨ QUAN',
        'NgayNhapNgu' : 'NGÀY NHẬP NGŨ',
        'NgayVaoDoan' : 'NGÀY VÀO ĐOÀN',
        'NgayVaoDang' : 'NGÀY VÀO ĐẢNG',
        'DanToc' : 'DÂN TỘC',
        'TonGiao' : 'TÔN GIÁO',
        'Mien' : 'MIỀN',
        'HocPhi' : 'HỌC PHÍ',
        'SinhHoatPhi' : 'PHÍ SINH HOẠT',
        'BHYT' : 'BẢO HIỂM Y TẾ',
        'ChiPhiKhac' : 'CHI PHÍ KHÁC',
        'GiaHanThoiGianDaoTao' : 'GIA HẠN THỜI GIAN ĐÀO TẠO',
        'Image' : 'ẢNH',
        'QuanHam' : 'QUÂN HÀM',
        'NghienCuuNoiBat' : 'NGHIÊN CỨU NỔI BẬT',
        'MaDVBM' : 'MÃ ĐƠN VỊ BỘ MÔN',
        'MaDVBQP' : 'MÃ ĐƠN VỊ BQP',
        'CSDaoTao' : 'CƠ SỞ ĐÀO TẠO',
        'DiaBan' : 'ĐỊA BÀN',
        'MaKetQua' : 'MÃ KẾT QUẢ',
        'Ki1' : 'KÌ 1',
        'Ki2' : 'KÌ 2',
        'Ki3' : 'KÌ 3',
        'Ki4' : 'KÌ 4',
        'Ki5' : 'KÌ 5',
        'Ki6' : 'KÌ 6',
        'Ki7' : 'KÌ 7',
        'Ki8' : 'KÌ 8',
        'Ki9' : 'KÌ 9',
        'Ki10' : 'KÌ 10',
        'Ki11' : 'KÌ 11',
        'Ki12' : 'KÌ 12',
        'Ki13' : 'KÌ 13',
        'Ki14' : 'KÌ 14',
        'PhanLoaiTotNghiep' : 'PHÂN LOẠI TỐT NGHIỆP',
        'DiemTrungBinh' : 'ĐIỂM TRUNG BÌNH',
        'MoTaKetQua' : 'MÔ TẢ KẾT QUẢ',
        'LuuNoMon' : 'LƯU NỢ MÔN',
        'LHSID' : 'LƯU HS ID',
        'MaCNDaotao1' : 'MÃ CN ĐÀO TẠO 1',
        'MaCNDaotao2' : 'MÃ CN ĐÀO TẠO 2',
        'BoMon' : 'BỘ MÔN',
        'MaDVCapTren' : 'MÃ DV CẤP TRÊN',
        'Khoa' : 'KHOA',
        'DonViBQP' : 'ĐƠN VỊ BỘ QUỐC PHÒNG',
        'CNDT1' : 'CHUYÊN NGÀNH DT 1',
        'MN1' : 'MÃ NGÀNH 1',
        'CNDT2' : 'CHUYÊN NGÀNH DT 2',
        'MN2' : 'MÃ NGÀNH 2',
        'QuaTrinhCongTac' : 'QUÁ TRÌNH CÔNG TÁC',
        'TenLuanVan' : 'TÊN LUẬN VĂN',
        'KetQuaBaoVe' : 'KẾT QUẢ BẢO VỆ',
        'QuyetDinhDuHoc' : 'QUYẾT ĐỊNH DU HỌC',
        'NganhDT1' : 'NGÀNH ĐÀO TẠO 1',
        'NganhDT2' : 'NGÀNH ĐÀO TẠO 2',
        'KiLuat' : 'KỈ LUẬT',
        'KhenThuong' : 'KHEN THƯỞNG',
        'CanBo' : 'CÁN BỘ PHỤ TRÁCH',
        'DiaChiLienLac' : 'ĐỊA CHỈ LIÊN HỆ',
        'ThongTinGiaDinh' : 'THÔNG TIN GIA ĐÌNH',
        'NoiOHienNay' : 'NƠI Ở HIỆN NAY',
        'ThanhPhanGiaDinh' : 'THÀNH PHẦN GIA ĐÌNH'
        }";
        dynamic data = JObject.Parse(jsonData);
        [HttpPost]
        public  ActionResult Baocao_MultiAttribute(List<string> ReportAttribute)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Thống kê thông tin lưu học sinh");
                var current_row = 1;
                var current_header_col = 1;
                #region header

                worksheet.Cell(current_row, 1).Value = "sd";
                worksheet.Cell(current_row, 2).Value = "Nước";
                worksheet.Cell(current_row, 3).Value = "Số lượng";

                foreach (var item in ReportAttribute)
                {
                    if (item == "Hoten")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "MaLHS")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "NgaySinh")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "ThongTinLienLac")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "QueQuan")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "GioiTinh")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "SoHieuSiQuan")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "NgayNhapNgu")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "NgayVaoDoan")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "NgayVaoDang")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "DanToc")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "TonGiao")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Mien")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "HocPhi")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "SinhHoatPhi")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "BHYT")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "ChiPhiKhac")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "GiaHanThoiGianDaoTao")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Image")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "QuanHam")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "NghienCuuNoiBat")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "MaDVBM")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "MaDVBQP")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "CSDaoTao")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "DiaBan")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "MaKetQua")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Ki1")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Ki2")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Ki3")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Ki4")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Ki5")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Ki7")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Ki8")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Ki9")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Ki10")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Ki11")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Ki12")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Ki13")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Ki14")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "PhanLoaiTotNghiep")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "DiemTrungBinh")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "MoTaKetQua")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "LuuNoMon")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "LHSID")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "MaCNDaotao1")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "MaCNDaotao2")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "BoMon")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "MaDVCapTren")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "Khoa")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "DonViBQP")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "CNDT1")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "MN1")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "CNDT2")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "MN2")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "QuaTrinhCongTac")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "TenLuanVan")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "KetQuaBaoVe")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "QuyetDinhDuHoc")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "NganhDT1")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "NganhDT2")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "KiLuat")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "KhenThuong")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "CanBo")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "DiaChiLienLac")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "ThongTinGiaDinh")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "NoiOHienNay")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }
                    else if (item == "ThanhPhanGiaDinh")
                    {
                        worksheet.Cell(current_row, current_header_col).Value = "Họ tên";
                    }



                    current_header_col++;
                }
                #endregion


                #region thân
                foreach (var item in new F_Luuhocsinh().Thongke_LHS_time(2019))
                {
                    current_row++;
                    worksheet.Cell(current_row, 1).Value = item.madiaban;
                    worksheet.Cell(current_row, 2).Value = item.diaban;
                    worksheet.Cell(current_row, 3).Value = item.soluong;
                }
                #endregion

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ThongkeLHSCountry.xlsx");
                }
            }           
        }
    }
}
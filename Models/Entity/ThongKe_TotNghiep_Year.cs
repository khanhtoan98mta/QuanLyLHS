using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDHS.Models.Entity
{
    public class ThongKe_TotNghiep_Year
    {
        public int Nam { get; set; }
        public int Xuatsac_ { get; set; }
        public int Xuatsac { get; set; }
        public int Gioi { get; set; }
        public int Kha { get; set; }
        public int TrungBinh { get; set; }
        public int Khac { get; set; }

        public ThongKe_TotNghiep_Year()
        {

        }
        public ThongKe_TotNghiep_Year(int nam, int xuatsac_, int xuatsac, int gioi, int kha, int trungBinh, int khac)
        {
            Nam = nam;
            Xuatsac_ = xuatsac_;
            Xuatsac = xuatsac;
            Gioi = gioi;
            Kha = kha;
            TrungBinh = trungBinh;
            Khac = khac;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDHS.Models.Entity
{
    public class ThongKeNienHanQH
    {
        public int LHSID { get; set; }
        public string MaLHS { get; set; }
        public string HoTen { get; set; }
        public DateTime NgayNhan { get; set; }
        public string QuanHam { get; set; }
        public string CSDaoTao { get; set; }
        public string DiaBan { get; set; }
        public string KiHieu { get; set; }
        public ThongKeNienHanQH()
        {

        }
        

    }
}
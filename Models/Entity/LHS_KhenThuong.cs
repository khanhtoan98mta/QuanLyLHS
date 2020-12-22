namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LHS_KhenThuong
    {
        public int ID { get; set; }

        public int LHSID { get; set; }

        public int MaKhenThuong { get; set; }

        [StringLength(15)]
        public string ThoiGianNhan { get; set; }

        [StringLength(100)]
        public string MoTa { get; set; }

        public virtual KhenThuong KhenThuong { get; set; }

        public virtual LuuHocSinh LuuHocSinh { get; set; }
    }
}

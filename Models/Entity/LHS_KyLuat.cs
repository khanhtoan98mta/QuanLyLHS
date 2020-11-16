namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LHS_KyLuat
    {
        public int ID { get; set; }

        public int LHSID { get; set; }

        public int MaKyLuat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianNhan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianKetThuc { get; set; }

        [StringLength(100)]
        public string MoTa { get; set; }

        public virtual KyLuat KyLuat { get; set; }

        public virtual LuuHocSinh LuuHocSinh { get; set; }
    }
}

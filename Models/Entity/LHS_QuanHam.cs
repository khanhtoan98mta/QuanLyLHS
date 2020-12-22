namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LHS_QuanHam
    {
        public int ID { get; set; }

        public int LHSID { get; set; }

        public int MaQuanHam { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        public virtual LuuHocSinh LuuHocSinh { get; set; }

        public virtual QuanHam QuanHam { get; set; }
    }
}

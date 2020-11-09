namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LHS_VePhep
    {
        public int ID { get; set; }

        public int LHSID { get; set; }

        public int MaVePhep { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayVe { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDi { get; set; }

        public virtual LuuHocSinh LuuHocSinh { get; set; }

        public virtual VePhep VePhep { get; set; }
    }
}

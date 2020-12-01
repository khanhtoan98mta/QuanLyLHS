namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanNhan")]
    public partial class ThanNhan
    {
        [Key]
        public int MaThanNhan { get; set; }

        [StringLength(100)]
        public string NoiOHienNay { get; set; }

        [StringLength(10)]
        public string QuanHe { get; set; }

        [StringLength(100)]
        public string DiaChiLienLac { get; set; }

        [StringLength(100)]
        public string ThanhPhanGiaDinh { get; set; }

        [StringLength(10)]
        public string CanBo { get; set; }

        [StringLength(100)]
        public string ThongTinGiaDinh { get; set; }

        public int? LHSID { get; set; }

        public virtual LuuHocSinh LuuHocSinh { get; set; }
    }
}

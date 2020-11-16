namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KetQuaHocTap")]
    public partial class KetQuaHocTap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaKetQua { get; set; }

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

        [StringLength(50)]
        public string PhanLoaiTotNghiep { get; set; }

        public double? DiemTrungBinh { get; set; }

        [StringLength(20)]
        public string MoTaKetQua { get; set; }

        [StringLength(500)]
        public string LuuNoMon { get; set; }

        public int LHSID { get; set; }

        public virtual LuuHocSinh LuuHocSinh { get; set; }
    }
}

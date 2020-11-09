namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoatDong")]
    public partial class HoatDong
    {
        [Key]
        public int MaHoatDong { get; set; }

        public string Image { get; set; }

        [Required]
        [StringLength(10)]
        public string Tilte { get; set; }

        public int? IDDiaBan { get; set; }

        public string Content { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGian { get; set; }

        public string TacGia { get; set; }

        public virtual DiaBanDaoTao DiaBanDaoTao { get; set; }
    }
}

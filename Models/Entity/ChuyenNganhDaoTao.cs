namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuyenNganhDaoTao")]
    public partial class ChuyenNganhDaoTao
    {
        [Key]
        public int MaChuyenNganh { get; set; }

        [Column("ChuyenNganhDaoTao")]
        [StringLength(100)]
        public string ChuyenNganhDaoTao1 { get; set; }

        public int? MaNganh { get; set; }

        public virtual NganhDaoTao NganhDaoTao { get; set; }
    }
}

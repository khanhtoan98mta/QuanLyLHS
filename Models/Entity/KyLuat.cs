namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KyLuat")]
    public partial class KyLuat
    {
        [Key]
        public int MaKyLuat { get; set; }

        [StringLength(100)]
        public string LoaiKyLuat { get; set; }
    }
}

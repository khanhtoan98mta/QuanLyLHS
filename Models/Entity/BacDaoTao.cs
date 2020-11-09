namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BacDaoTao")]
    public partial class BacDaoTao
    {
        [Key]
        public int MaBacDaoTao { get; set; }

        [Column("BacDaoTao")]
        [StringLength(10)]
        public string BacDaoTao1 { get; set; }
    }
}

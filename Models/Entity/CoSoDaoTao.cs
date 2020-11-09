namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CoSoDaoTao")]
    public partial class CoSoDaoTao
    {
        [Key]
        public int MaCSDaoTao { get; set; }

        [StringLength(100)]
        public string CSDaoTao { get; set; }

        public int? IDDiaBan { get; set; }

        public virtual DiaBanDaoTao DiaBanDaoTao { get; set; }
    }
}

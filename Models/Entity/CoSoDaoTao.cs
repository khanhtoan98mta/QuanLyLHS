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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CoSoDaoTao()
        {
            KhoaDaoTaos = new HashSet<KhoaDaoTao>();
            LHS_DaoTao = new HashSet<LHS_DaoTao>();
        }

        [Key]
        public int MaCSDaoTao { get; set; }

        [StringLength(100)]
        public string CSDaoTao { get; set; }

        public int? IDDiaBan { get; set; }

        public string GhiChu { get; set; }

        public virtual DiaBanDaoTao DiaBanDaoTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoaDaoTao> KhoaDaoTaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LHS_DaoTao> LHS_DaoTao { get; set; }
    }
}

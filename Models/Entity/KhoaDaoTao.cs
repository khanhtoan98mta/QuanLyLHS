namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial; 

    [Table("KhoaDaoTao")]
    public partial class KhoaDaoTao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoaDaoTao()
        {
            BoMonDaoTaos = new HashSet<BoMonDaoTao>();
            LHS_DaoTao = new HashSet<LHS_DaoTao>();
        }

        [Key]
        public int MaKhoa { get; set; }

        [StringLength(100)]
        public string TenKhoa { get; set; }

        public int? MaCSDaoTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoMonDaoTao> BoMonDaoTaos { get; set; }

        public virtual CoSoDaoTao CoSoDaoTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LHS_DaoTao> LHS_DaoTao { get; set; }
    }
}

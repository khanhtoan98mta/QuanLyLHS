namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoMonDaoTao")]
    public partial class BoMonDaoTao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BoMonDaoTao()
        {
            LHS_DaoTao = new HashSet<LHS_DaoTao>();
        }

        [Key]
        public int MaBM { get; set; }

        [StringLength(100)]
        public string TenBoMon { get; set; }

        public int? MaKhoa { get; set; }

        public virtual KhoaDaoTao KhoaDaoTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LHS_DaoTao> LHS_DaoTao { get; set; }
    }
}

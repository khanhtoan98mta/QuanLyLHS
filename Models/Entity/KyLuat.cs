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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KyLuat()
        {
            LHS_KyLuat = new HashSet<LHS_KyLuat>();
        }

        [Key]
        public int MaKyLuat { get; set; }

        [StringLength(100)]
        public string LoaiKyLuat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LHS_KyLuat> LHS_KyLuat { get; set; }
    }
}

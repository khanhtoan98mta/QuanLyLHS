namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VePhep")]
    public partial class VePhep
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VePhep()
        {
            LHS_VePhep = new HashSet<LHS_VePhep>();
        }

        [Key]
        public int MaVePhep { get; set; }

        [StringLength(100)]
        public string LoaiVePhep { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LHS_VePhep> LHS_VePhep { get; set; }
    }
}

namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NganhDaoTao")]
    public partial class NganhDaoTao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NganhDaoTao()
        {
            ChuyenNganhDaoTaos = new HashSet<ChuyenNganhDaoTao>();
        }

        [Key]
        public int MaNganh { get; set; }

        [Column("NganhDaoTao")]
        [StringLength(100)]
        public string NganhDaoTao1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuyenNganhDaoTao> ChuyenNganhDaoTaos { get; set; }
    }
}

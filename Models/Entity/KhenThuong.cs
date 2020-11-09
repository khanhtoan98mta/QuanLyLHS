namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhenThuong")]
    public partial class KhenThuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhenThuong()
        {
            LHS_KhenThuong = new HashSet<LHS_KhenThuong>();
        }

        [Key]
        public int MaKhenThuong { get; set; }

        [StringLength(100)]
        public string LoaiKhenThuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LHS_KhenThuong> LHS_KhenThuong { get; set; }
    }
}

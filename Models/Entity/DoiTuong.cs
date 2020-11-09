namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoiTuong")]
    public partial class DoiTuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoiTuong()
        {
            LuuHocSinhs = new HashSet<LuuHocSinh>();
        }

        [Key]
        public int MaDoiTuong { get; set; }

        [Column("DoiTuong")]
        [StringLength(50)]
        public string DoiTuong1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuuHocSinh> LuuHocSinhs { get; set; }
    }
}

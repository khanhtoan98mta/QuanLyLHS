namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuanHam")]
    public partial class QuanHam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuanHam()
        {
            LHS_QuanHam = new HashSet<LHS_QuanHam>();
        }

        [Key]
        public int MaQuanHam { get; set; }

        [StringLength(50)]
        public string TenQuanHam { get; set; }

        public double? NienHan { get; set; }

        [StringLength(5)]
        public string KiHieu { get; set; }

        public int? MaDoiTuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LHS_QuanHam> LHS_QuanHam { get; set; }
    }
}

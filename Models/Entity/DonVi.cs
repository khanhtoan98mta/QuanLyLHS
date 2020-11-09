namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonVi")]
    public partial class DonVi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonVi()
        {
            LuuHocSinhs = new HashSet<LuuHocSinh>();
            LuuHocSinhs1 = new HashSet<LuuHocSinh>();
        }

        [Key]
        public int MaDonVi { get; set; }

        [Column("DonVi")]
        [StringLength(100)]
        public string DonVi1 { get; set; }

        public int? MaDonViCapTren { get; set; }
        public int? CapDonVi { get; set; }

        [StringLength(100)]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuuHocSinh> LuuHocSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuuHocSinh> LuuHocSinhs1 { get; set; }
    }
}

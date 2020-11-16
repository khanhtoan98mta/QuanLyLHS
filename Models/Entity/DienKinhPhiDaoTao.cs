namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DienKinhPhiDaoTao")]
    public partial class DienKinhPhiDaoTao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DienKinhPhiDaoTao()
        {
            LuuHocSinhs = new HashSet<LuuHocSinh>();
        }

        [Key]
        public int MaDKP { get; set; }

        [StringLength(50)]
        public string DienKinhPhi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuuHocSinh> LuuHocSinhs { get; set; }
    }
}

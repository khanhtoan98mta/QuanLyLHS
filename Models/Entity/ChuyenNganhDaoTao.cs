namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuyenNganhDaoTao")]
    public partial class ChuyenNganhDaoTao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuyenNganhDaoTao()
        {
            LHS_DaoTao = new HashSet<LHS_DaoTao>();
            LHS_DaoTao1 = new HashSet<LHS_DaoTao>();
        }

        [Key]
        public int MaChuyenNganh { get; set; }

        [Column("ChuyenNganhDaoTao")]
        [StringLength(100)]
        public string ChuyenNganhDaoTao1 { get; set; }

        public int? MaNganh { get; set; }

        public virtual NganhDaoTao NganhDaoTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LHS_DaoTao> LHS_DaoTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LHS_DaoTao> LHS_DaoTao1 { get; set; }
    }
}

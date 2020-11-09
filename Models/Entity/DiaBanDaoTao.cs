namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiaBanDaoTao")]
    public partial class DiaBanDaoTao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiaBanDaoTao()
        {
            CoSoDaoTaos = new HashSet<CoSoDaoTao>();
            HoatDongs = new HashSet<HoatDong>();
        }

        [Key]
        public int IDDiaBan { get; set; }

        [StringLength(50)]
        public string MaDiaBan { get; set; }

        [StringLength(100)]
        public string DiaBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoSoDaoTao> CoSoDaoTaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoatDong> HoatDongs { get; set; }
    }
}

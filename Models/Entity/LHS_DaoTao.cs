namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LHS_DaoTao
    {
        public int ID { get; set; }

        public int LHSID { get; set; }

        public int? MaBMDaoTao { get; set; }

        public int? MaKhoaDaoTao { get; set; }

        public int? MaCSDaoTao { get; set; }

        public int? MaCNDaoTao1 { get; set; }

        public int? MaCNDaoTao2 { get; set; }

        public int? MaBacDaoTao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianKetThuc { get; set; }

        [StringLength(10)]
        public string ThoiGianDaoTao { get; set; }

        public int? TinhTrangTotNghiep { get; set; }

        public virtual BacDaoTao BacDaoTao { get; set; }

        public virtual BoMonDaoTao BoMonDaoTao { get; set; }

        public virtual ChuyenNganhDaoTao ChuyenNganhDaoTao { get; set; }

        public virtual ChuyenNganhDaoTao ChuyenNganhDaoTao1 { get; set; }

        public virtual CoSoDaoTao CoSoDaoTao { get; set; }

        public virtual KhoaDaoTao KhoaDaoTao { get; set; }

        public virtual LuuHocSinh LuuHocSinh { get; set; }
    }
}

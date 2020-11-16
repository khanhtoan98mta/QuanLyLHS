namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LHS_DaoTao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int LHSID { get; set; }

        public int MaCSDaoTao { get; set; }

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
    }
}

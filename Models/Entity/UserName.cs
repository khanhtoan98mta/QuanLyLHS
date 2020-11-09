namespace QLDHS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserName")]
    public partial class UserName
    {
        public int ID { get; set; }

        [Column("UserName")]
        [StringLength(100)]
        public string UserName1 { get; set; }

        [StringLength(100)]
        public string PassWord { get; set; }

        public int? RoleID { get; set; }
    }
}

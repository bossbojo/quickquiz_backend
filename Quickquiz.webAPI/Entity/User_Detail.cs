namespace Quickquiz.webAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quickquiz.User_Detail")]
    public partial class User_Detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        [StringLength(50)]
        public string faculty { get; set; }

        [StringLength(50)]
        public string branch { get; set; }

        [StringLength(50)]
        public string university { get; set; }

        public DateTime? time_dt { get; set; }
    }
}

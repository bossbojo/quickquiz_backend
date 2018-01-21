namespace Quickquiz.webAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quickquiz.Users")]
    public partial class Users
    {
        [Key]
        public int user_id { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public bool verify { get; set; }

        [Required]
        [StringLength(2)]
        public string status { get; set; }

        public int user_type_id { get; set; }

        public DateTime time_stamp_ctd { get; set; }

        public virtual Status_code Status_code { get; set; }

        public virtual User_Detail User_Detail { get; set; }

        public virtual User_type User_type { get; set; }
    }
}

namespace Quickquiz.webAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quickquiz.v_user")]
    public partial class v_user
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Verify { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string University { get; set; }

        [StringLength(50)]
        public string Faculty { get; set; }

        [StringLength(50)]
        public string Branch { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }
    }
}

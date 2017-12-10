namespace Quickquiz.webAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quickquiz.User_type")]
    public partial class User_type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_type_id { get; set; }

        [Column("user_type")]
        [StringLength(50)]
        public string user_type1 { get; set; }
    }
}

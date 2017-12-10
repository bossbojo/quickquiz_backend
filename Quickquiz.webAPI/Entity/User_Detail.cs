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

        [StringLength(256)]
        public string img { get; set; }

        [StringLength(5)]
        public string faculty_id { get; set; }

        [StringLength(5)]
        public string major_id { get; set; }

        [StringLength(5)]
        public string university_id { get; set; }

        public DateTime? time_dt { get; set; }
    }
}

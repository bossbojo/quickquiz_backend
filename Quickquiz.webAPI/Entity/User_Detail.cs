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

        [StringLength(2)]
        public string faculty_id { get; set; }

        [StringLength(2)]
        public string major_id { get; set; }

        [StringLength(5)]
        public string university_id { get; set; }

        public DateTime? time_dt { get; set; }

        public virtual D_Faculty D_Faculty { get; set; }

        public virtual D_Major D_Major { get; set; }

        public virtual D_University D_University { get; set; }

        public virtual Users Users { get; set; }
    }
}

namespace Quickquiz.webAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quickquiz.Code_quiz")]
    public partial class Code_quiz
    {
        [Key]
        public int code_id { get; set; }

        [Required]
        [StringLength(100)]
        public string quick_name { get; set; }

        [Required]
        [StringLength(10)]
        public string code { get; set; }

        public int count_quiz { get; set; }

        [Required]
        [StringLength(2)]
        public string status { get; set; }

        public int user_id { get; set; }

        public DateTime time_stamp_ctd { get; set; }
    }
}

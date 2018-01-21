namespace Quickquiz.webAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quickquiz.Question")]
    public partial class Question
    {
        [Key]
        [Column(Order = 0)]
        public int q_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int code_id { get; set; }

        [Key]
        [Column("question", Order = 2, TypeName = "text")]
        public string question1 { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2)]
        public string status { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime time_stamp_ctd { get; set; }
    }
}

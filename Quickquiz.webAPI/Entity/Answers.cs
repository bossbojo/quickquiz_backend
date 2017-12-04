namespace Quickquiz.webAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quickquiz.Answers")]
    public partial class Answers
    {
        [Key]
        [Column(Order = 0)]
        public int a_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int q_id { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "text")]
        public string answer { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool correct { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime time_stamp_ctd { get; set; }
    }
}

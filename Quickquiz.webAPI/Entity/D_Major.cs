namespace Quickquiz.webAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quickquiz.D_Major")]
    public partial class D_Major
    {

        [Key]
        [StringLength(5)]
        public string Abbreviation { get; set; }

        [Required]
        [StringLength(50)]
        public string Fullwords { get; set; }

        [Required]
        [StringLength(5)]
        public string Faculty_Abbreviation { get; set; }

        public DateTime add_dt { get; set; }

    }
}

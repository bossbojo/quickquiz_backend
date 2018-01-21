namespace Quickquiz.webAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quickquiz.University")]
    public partial class University
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(5)]
        public string Abbreviation { get; set; }

        [Required]
        [StringLength(50)]
        public string Fullwords { get; set; }

        public DateTime add_dt { get; set; }
    }
}

namespace Quickquiz.webAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quickquiz.D_Faculty")]
    public partial class D_Faculty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public D_Faculty()
        {
            D_Major = new HashSet<D_Major>();
            User_Detail = new HashSet<User_Detail>();
        }

        [Key]
        [StringLength(2)]
        public string Abbreviation { get; set; }

        [Required]
        [StringLength(50)]
        public string Fullwords { get; set; }

        public DateTime add_dt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<D_Major> D_Major { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Detail> User_Detail { get; set; }
    }
}

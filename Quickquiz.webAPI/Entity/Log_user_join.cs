namespace Quickquiz.webAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quickquiz.Log_user_join")]
    public partial class Log_user_join
    {
        public int Id { get; set; }

        public int user_id { get; set; }

        public int code_id { get; set; }

        public int count_quick { get; set; }

        public DateTime time_stamp_ctd { get; set; }
    }
}

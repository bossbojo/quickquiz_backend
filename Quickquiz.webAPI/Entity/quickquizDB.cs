namespace Quickquiz.webAPI.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class quickquizDB : DbContext
    {
        public quickquizDB()
            : base("name=quickquizDB")
        {
        }

        public virtual DbSet<Code_quiz> Code_quiz { get; set; }
        public virtual DbSet<Log_user_join> Log_user_join { get; set; }
        public virtual DbSet<Status_code> Status_code { get; set; }
        public virtual DbSet<User_Detail> User_Detail { get; set; }
        public virtual DbSet<User_type> User_type { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<v_user> v_user { get; set; }
    }
}

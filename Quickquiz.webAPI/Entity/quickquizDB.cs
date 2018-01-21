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
        public virtual DbSet<D_Faculty> D_Faculty { get; set; }
        public virtual DbSet<D_Major> D_Major { get; set; }
        public virtual DbSet<D_University> D_University { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Log_user_join> Log_user_join { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<Status_code> Status_code { get; set; }
        public virtual DbSet<University> University { get; set; }
        public virtual DbSet<User_Detail> User_Detail { get; set; }
        public virtual DbSet<User_type> User_type { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<v_user> v_user { get; set; }
        public virtual DbSet<v_user_teacher> v_user_teacher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Code_quiz>()
                .Property(e => e.quick_name)
                .IsUnicode(false);

            modelBuilder.Entity<Code_quiz>()
                .Property(e => e.code)
                .IsFixedLength();

            modelBuilder.Entity<Code_quiz>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<D_Faculty>()
                .Property(e => e.Abbreviation)
                .IsFixedLength();

            modelBuilder.Entity<D_Faculty>()
                .HasMany(e => e.D_Major)
                .WithRequired(e => e.D_Faculty)
                .HasForeignKey(e => e.Faculty_Abbreviation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<D_Faculty>()
                .HasMany(e => e.User_Detail)
                .WithOptional(e => e.D_Faculty)
                .HasForeignKey(e => e.faculty_id);

            modelBuilder.Entity<D_Major>()
                .Property(e => e.Abbreviation)
                .IsFixedLength();

            modelBuilder.Entity<D_Major>()
                .Property(e => e.Faculty_Abbreviation)
                .IsFixedLength();

            modelBuilder.Entity<D_Major>()
                .HasMany(e => e.User_Detail)
                .WithOptional(e => e.D_Major)
                .HasForeignKey(e => e.major_id);

            modelBuilder.Entity<D_University>()
                .Property(e => e.Abbreviation)
                .IsFixedLength();

            modelBuilder.Entity<D_University>()
                .HasMany(e => e.User_Detail)
                .WithOptional(e => e.D_University)
                .HasForeignKey(e => e.university_id);

            modelBuilder.Entity<Faculty>()
                .Property(e => e.Abbreviation)
                .IsFixedLength();

            modelBuilder.Entity<Faculty>()
                .HasMany(e => e.Major)
                .WithRequired(e => e.Faculty)
                .HasForeignKey(e => e.Faculty_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.Abbreviation)
                .IsFixedLength();

            modelBuilder.Entity<Status_code>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Status_code>()
                .Property(e => e.status_name)
                .IsUnicode(false);

            modelBuilder.Entity<Status_code>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Status_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<University>()
                .Property(e => e.Abbreviation)
                .IsFixedLength();

            modelBuilder.Entity<User_Detail>()
                .Property(e => e.img)
                .IsUnicode(false);

            modelBuilder.Entity<User_Detail>()
                .Property(e => e.faculty_id)
                .IsFixedLength();

            modelBuilder.Entity<User_Detail>()
                .Property(e => e.major_id)
                .IsFixedLength();

            modelBuilder.Entity<User_Detail>()
                .Property(e => e.university_id)
                .IsFixedLength();

            modelBuilder.Entity<User_type>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.User_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasOptional(e => e.User_Detail)
                .WithRequired(e => e.Users);

            modelBuilder.Entity<Answers>()
                .Property(e => e.answer)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.question1)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<v_user>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<v_user>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<v_user_teacher>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<v_user_teacher>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}

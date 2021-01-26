using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebGameMVC.Models.EF
{
    public partial class WebGameDbContext : DbContext
    {
        public WebGameDbContext()
            : base("name=WebGameDbContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Avatar> Avatars { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<Dungeon> Dungeons { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Ranking> Rankings { get; set; }
        public virtual DbSet<Stage> Stages { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Wing> Wings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Collections)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Histories)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<Ranking>()
                .Property(e => e.Medal)
                .IsFixedLength();

            modelBuilder.Entity<Ranking>()
                .HasMany(e => e.Accounts)
                .WithOptional(e => e.Ranking)
                .HasForeignKey(e => e.Rank);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Questions)
                .WithOptional(e => e.Subject)
                .HasForeignKey(e => e.SubID);
        }
    }
}

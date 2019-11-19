namespace Wsr1.Core.EnityModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Models : DbContext
    {
        public Models()
            : base("name=EntityDataContext")
        {
        }

        public virtual DbSet<Coefficient> Coefficient { get; set; }
        public virtual DbSet<Executors> Executors { get; set; }
        public virtual DbSet<ExecutorStatus> ExecutorStatus { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<NatureOfWork> NatureOfWork { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Quest> Quest { get; set; }
        public virtual DbSet<QuestStatus> QuestStatus { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coefficient>()
                .Property(e => e.CoefficientAnalis)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Coefficient>()
                .Property(e => e.CoefficientInstall)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Coefficient>()
                .Property(e => e.CoefficientService)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Coefficient>()
                .Property(e => e.CoefficientTime)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Coefficient>()
                .Property(e => e.CoefficientDifficult)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Coefficient>()
                .Property(e => e.CoefficientMoney)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Executors>()
                .HasMany(e => e.Quest)
                .WithOptional(e => e.Executors)
                .HasForeignKey(e => e.ExecutorId);

            modelBuilder.Entity<ExecutorStatus>()
                .HasMany(e => e.Executors)
                .WithRequired(e => e.ExecutorStatus)
                .HasForeignKey(e => e.IdExecutorStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Executors)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.IdGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Manager>()
                .HasMany(e => e.Group)
                .WithRequired(e => e.Manager)
                .HasForeignKey(e => e.IdManager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NatureOfWork>()
                .HasMany(e => e.Quest)
                .WithRequired(e => e.NatureOfWork)
                .HasForeignKey(e => e.IdNatureOfWork)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Executors)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.IdPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Manager)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.IdPerson);

            modelBuilder.Entity<QuestStatus>()
                .HasMany(e => e.Quest)
                .WithRequired(e => e.QuestStatus)
                .HasForeignKey(e => e.IdStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Salary>()
                .Property(e => e.JuniorMin)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Salary>()
                .Property(e => e.MiddleMin)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Salary>()
                .Property(e => e.SeniorMin)
                .HasPrecision(18, 0);
        }
    }
}

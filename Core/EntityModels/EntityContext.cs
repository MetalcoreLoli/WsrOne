namespace Wsr1.Core.EntityModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityContext : DbContext
    {
        public EntityContext()
            : base("name=EntityContext")
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
                .HasMany(e => e.Manager)
                .WithOptional(e => e.Coefficient)
                .HasForeignKey(e => e.IdCoefficient);

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
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.IdPerson)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<Salary>()
                .HasMany(e => e.Manager)
                .WithOptional(e => e.Salary)
                .HasForeignKey(e => e.IdSalary);
        }
    }
}

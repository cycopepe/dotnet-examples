using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dataLayer
{
    public partial class tododbContext : DbContext
    {
        public tododbContext()
        {
        }

        public tododbContext(DbContextOptions<tododbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskStatus> TaskStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=tododb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).ValueGeneratedNever();

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.TaskId).ValueGeneratedNever();

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.TaskProjectNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.TaskProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TaskProjectFK");

                entity.HasOne(d => d.TaskStatusNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.TaskStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TaskStatusFK");
            });

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.Property(e => e.TaskStatusId).ValueGeneratedNever();

                entity.Property(e => e.TaskStatusName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

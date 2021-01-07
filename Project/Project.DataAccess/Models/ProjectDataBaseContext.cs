using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Project.DataAccess.Connection;

#nullable disable

namespace Project.DataAccess.Models
{
    public partial class ProjectDataBaseContext : DbContext
    {
        public ProjectDataBaseContext()
        {
        }

        public ProjectDataBaseContext(DbContextOptions<ProjectDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditory> Auditories { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Inventarization> Inventarizations { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }
        public virtual DbSet<Responsible> Responsibles { get; set; }
        public virtual DbSet<Verifier> Verifiers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionStrings.NewMyConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Auditory>(entity =>
            {
                entity.HasKey(e => e.AuditoriumId)
                    .HasName("PK__Auditori__6E91B1A544E33F2D");

                entity.Property(e => e.AuditoriumId).HasColumnName("AuditoriumID");

                entity.Property(e => e.AuditoryType)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ResponsibleId).HasColumnName("ResponsibleID");

                entity.HasOne(d => d.Responsible)
                    .WithMany(p => p.Auditories)
                    .HasForeignKey(d => d.ResponsibleId)
                    .HasConstraintName("FK__Auditorie__Respo__2D27B809");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.DateUsedFrom).HasColumnType("date");

                entity.Property(e => e.DateUsedTo).HasColumnType("date");

                entity.Property(e => e.InventoryName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Reason).HasColumnType("text");
            });

            modelBuilder.Entity<Inventarization>(entity =>
            {
                entity.Property(e => e.InventarizationId).HasColumnName("InventarizationID");

                entity.Property(e => e.InventarizationDate).HasColumnType("date");

                entity.Property(e => e.VerifierId).HasColumnName("VerifierID");

                entity.HasOne(d => d.Verifier)
                    .WithMany(p => p.Inventarizations)
                    .HasForeignKey(d => d.VerifierId)
                    .HasConstraintName("FK__Inventari__Verif__286302EC");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.AuditoriumId).HasColumnName("AuditoriumID");

                entity.Property(e => e.CurrentState)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.HasOne(d => d.Auditorium)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.AuditoriumId)
                    .HasConstraintName("FK__Inventori__Audit__32E0915F");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.DocumentId)
                    .HasConstraintName("FK__Inventori__Docum__33D4B598");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.Property(e => e.ListId).HasColumnName("ListID");

                entity.Property(e => e.AuditoriumId).HasColumnName("AuditoriumID");

                entity.Property(e => e.InventarizationId).HasColumnName("InventarizationID");

                entity.HasOne(d => d.Auditorium)
                    .WithMany(p => p.Lists)
                    .HasForeignKey(d => d.AuditoriumId)
                    .HasConstraintName("FK__Lists__Auditoriu__3C69FB99");

                entity.HasOne(d => d.Inventarization)
                    .WithMany(p => p.Lists)
                    .HasForeignKey(d => d.InventarizationId)
                    .HasConstraintName("FK__Lists__Inventari__3D5E1FD2");
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.Property(e => e.RepairId).HasColumnName("RepairID");

                entity.Property(e => e.DateEnd).HasColumnType("date");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Repairs)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK__Repairs__Invento__36B12243");
            });

            modelBuilder.Entity<Responsible>(entity =>
            {
                entity.Property(e => e.ResponsibleId).HasColumnName("ResponsibleID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ResponsibleName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Verifier>(entity =>
            {
                entity.Property(e => e.VerifierId).HasColumnName("VerifierID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VefifierName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

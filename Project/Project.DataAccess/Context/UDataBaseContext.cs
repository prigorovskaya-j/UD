using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Models;

#nullable disable

namespace Project.DataAccess.Context
{
    public partial class UDataBaseContext : DbContext
    {
        public UDataBaseContext()
        {
        }

        public UDataBaseContext(DbContextOptions<UDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditorium> Auditoria { get; set; }
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
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-P87PH2B;Initial Catalog=UDataBase;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Auditorium>(entity =>
            {
                entity.ToTable("Auditorium");

                entity.Property(e => e.AuditoriumId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AuditoriumID")
                    .IsFixedLength(true);

                entity.Property(e => e.AuditoryType)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ResponsibleId).HasColumnName("ResponsibleID");

                entity.HasOne(d => d.Responsible)
                    .WithMany(p => p.Auditoria)
                    .HasForeignKey(d => d.ResponsibleId)
                    .HasConstraintName("FK__Auditoriu__Respo__534D60F1");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.DocumentId)
                    .ValueGeneratedNever()
                    .HasColumnName("DocumentID");

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
                entity.ToTable("Inventarization");

                entity.Property(e => e.InventarizationId)
                    .ValueGeneratedNever()
                    .HasColumnName("InventarizationID");

                entity.Property(e => e.InventarizationDate).HasColumnType("date");

                entity.Property(e => e.VerifierId).HasColumnName("VerifierID");

                entity.HasOne(d => d.Verifier)
                    .WithMany(p => p.Inventarizations)
                    .HasForeignKey(d => d.VerifierId)
                    .HasConstraintName("FK__Inventari__Verif__4E88ABD4");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.InventoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("InventoryID");

                entity.Property(e => e.AuditoriumId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AuditoriumID")
                    .IsFixedLength(true);

                entity.Property(e => e.CurrentState)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.HasOne(d => d.Auditorium)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.AuditoriumId)
                    .HasConstraintName("FK__Inventory__Audit__5629CD9C");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.DocumentId)
                    .HasConstraintName("FK__Inventory__Docum__571DF1D5");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.ToTable("List");

                entity.Property(e => e.ListId)
                    .ValueGeneratedNever()
                    .HasColumnName("ListID");

                entity.Property(e => e.AuditoriumId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AuditoriumID")
                    .IsFixedLength(true);

                entity.Property(e => e.InventarizationId).HasColumnName("InventarizationID");

                entity.HasOne(d => d.Auditorium)
                    .WithMany(p => p.Lists)
                    .HasForeignKey(d => d.AuditoriumId)
                    .HasConstraintName("FK__List__Auditorium__628FA481");

                entity.HasOne(d => d.Inventarization)
                    .WithMany(p => p.Lists)
                    .HasForeignKey(d => d.InventarizationId)
                    .HasConstraintName("FK__List__Inventariz__6383C8BA");
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.ToTable("Repair");

                entity.Property(e => e.RepairId)
                    .ValueGeneratedNever()
                    .HasColumnName("RepairID");

                entity.Property(e => e.DateEnd).HasColumnType("date");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Repairs)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK__Repair__Inventor__5CD6CB2B");
            });

            modelBuilder.Entity<Responsible>(entity =>
            {
                entity.ToTable("Responsible");

                entity.Property(e => e.ResponsibleId)
                    .ValueGeneratedNever()
                    .HasColumnName("ResponsibleID");

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
                entity.ToTable("Verifier");

                entity.Property(e => e.VerifierId)
                    .ValueGeneratedNever()
                    .HasColumnName("VerifierID");

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

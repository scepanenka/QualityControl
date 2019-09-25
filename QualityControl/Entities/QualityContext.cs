using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QualityControl.Entities
{
    public partial class QualityContext : DbContext
    {
        public QualityContext()
        {
        }

        public QualityContext(DbContextOptions<QualityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClientOrders> ClientOrders { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Objects> Objects { get; set; }
        public virtual DbSet<ObjectsTypes> ObjectsTypes { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersObjects> OrdersObjects { get; set; }
        public virtual DbSet<OrdersQuality> OrdersQuality { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.85.22;Database=Quality;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientOrders>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.ClientOrders)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientOrders_Clients");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.ClientOrders)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientOrders_Orders");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Information).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Patronymic).HasMaxLength(20);

                entity.Property(e => e.PersonalNumber).HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Unn)
                    .HasColumnName("UNN")
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Patronymic).HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Positions");
            });

            modelBuilder.Entity<Objects>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.InvNumber).HasMaxLength(50);

                entity.HasOne(d => d.IdObjectTypeNavigation)
                    .WithMany(p => p.Objects)
                    .HasForeignKey(d => d.IdObjectType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Objects_ObjectsTypes");
            });

            modelBuilder.Entity<ObjectsTypes>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateExecution).HasColumnType("date");

                entity.Property(e => e.DateReceipt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_Orders_Employees");

                entity.HasOne(d => d.IdOrganizationNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdOrganization)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Organizations");
            });

            modelBuilder.Entity<OrdersObjects>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdObjectNavigation)
                    .WithMany(p => p.OrdersObjects)
                    .HasForeignKey(d => d.IdObject)
                    .HasConstraintName("FK_OrdersObjects_Objects");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrdersObjects)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_OrdersObjects_Orders");
            });

            modelBuilder.Entity<OrdersQuality>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Result).HasMaxLength(10);

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrdersQuality)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersQuality_Orders");

                entity.HasOne(d => d.IdVerifierNavigation)
                    .WithMany(p => p.OrdersQuality)
                    .HasForeignKey(d => d.IdVerifier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersQuality_Employees");
            });

            modelBuilder.Entity<Organizations>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}

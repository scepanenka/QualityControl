﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Quality.DAL.Entities
{
    public class TestDBContext : DbContext
    {        
        public TestDBContext(DbContextOptions config) : base(config)
        {
            
        }

        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer(_config.GetConnectionString("QualityDB"));
            }                
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Patronymic).HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Client).HasMaxLength(100);

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdEmployer)
                    .HasConstraintName("FK_Orders_Employers");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdOrganization)
                    .HasConstraintName("FK_Orders_Organizations");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });
        }
    }
}

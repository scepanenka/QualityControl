using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Quality.DAL.Entities
{
    public class QualityContext : DbContext
    {        
        public QualityContext(DbContextOptions config) : base(config)
        {
            
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<ClientOrders> ClientOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }                
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

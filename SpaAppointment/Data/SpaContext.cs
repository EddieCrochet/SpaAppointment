using Microsoft.EntityFrameworkCore;
using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaAppointment.Data
{
    public class SpaContext : DbContext, IReadOnlySpaContext
    {
        public SpaContext(DbContextOptions<SpaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasKey(x => x.Id).ForSqlServerIsClustered();
            modelBuilder.Entity<Appointment>().Property(x => x.Id).UseSqlServerIdentityColumn();
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }

        IQueryable<Appointment> IReadOnlySpaContext.Appointments { get => Appointments.AsNoTracking(); }
        IQueryable<Customer> IReadOnlySpaContext.Customers { get => Customers.AsNoTracking(); }
        IQueryable<ServiceProvider> IReadOnlySpaContext.ServiceProviders { get => ServiceProviders.AsNoTracking(); }
    }
}

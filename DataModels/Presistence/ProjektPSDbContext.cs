using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Presistence
{
    public class ProjektPSDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<CarModel> Models{ get; set; }

        public DbSet<Location> Locations { get; set; }

        public ProjektPSDbContext(DbContextOptions<ProjektPSDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf =>
                new { vf.VehicleId, vf.FeatureId });
        }
    }
}

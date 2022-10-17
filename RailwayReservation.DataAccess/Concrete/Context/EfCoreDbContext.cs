using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RailwayReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.DataAccess.Concrete.Context
{
    public class EfCoreDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationManager configurationManager = new();//nuget 6.01 versiyonu geerekli
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../RailRoadReservationAPI"));
            configurationManager.AddJsonFile("appsettings.json");


            var dbType = configurationManager.GetConnectionString("DbType");
            if (dbType == "SQL")
            {
                optionsBuilder.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"));
            }
            else if (dbType == "PostgreSQL")
            {
                optionsBuilder.UseNpgsql(configurationManager.GetConnectionString("PostgreSqlConnection"));
            }


        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Vagon> Vagons { get; set; }

    }
}

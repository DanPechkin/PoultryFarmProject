using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryPoultryFarm.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibraryPoultryFarm.Persistence
{
    public class AppDbContext : DbContext
    {
        private static readonly string ConnectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=PoultryFarm;Integrated Security=SSPI;";

        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<Chicken> Chickens { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Production> Production { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Workshop> Workshops { get; set; }


        public static void Initialize()
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (context.Database.EnsureCreated())
                {
                    var seedData = new SeedData(context);

                    seedData.Fill();
                }
            }
        }


        public static void ReCreate()
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var seedData = new SeedData(context);

                seedData.Fill();
            }
        }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

			base.OnModelCreating(modelBuilder);
		}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}

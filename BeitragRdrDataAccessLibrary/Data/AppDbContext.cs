using BeitragRdr.Models;
using BeitragRdr.Models.ImageModels;
using BeitragRdr.Models.SubModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace BeitragRdrDataAccessLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Beitrag> Beitrags { get; set; }

        //Tags DbSets
        public DbSet<Tags> Tags { get; set; }

        //Beitrag DbSets
        public DbSet<BeitragFace> beitragFaces { get; set; }
        public DbSet<BeitragInsta> beitragInstas { get; set; }
        public DbSet<BeitragPintr> beitragPintrs { get; set; }

        
        //Images DbSets
        public DbSet<ImageModelFacebook> ImageModelFacebook { get; set; }
        public DbSet<ImageModelInstagram> ImageModelInstagram { get; set; }

        public DbSet<ImageModelPintr> ImageModelPintr { get; set; }


        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {           
                optionsBuilder.UseSqlite("Filename=Beitrag.db");
            }
        }
    }
}

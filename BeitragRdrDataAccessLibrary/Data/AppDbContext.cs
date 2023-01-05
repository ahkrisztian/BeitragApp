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
        private static IConfigurationRoot _configuration;
        public DbSet<Beitrag> Beitrags { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<BeitragFace> beitragFaces { get; set; }
        public DbSet<BeitragInsta> beitragInstas { get; set; }
        public DbSet<BeitragPintr> beitragPintrs { get; set; }

        public DbSet<BeitragTags> BeitragTags { get; set; }

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
            modelBuilder.Entity<BeitragTags>().HasKey(bt => new { bt.TagId, bt.BeitragId });

            modelBuilder.Entity<BeitragTags>()
                .HasOne(b => b.Beitrag)
                .WithMany(bt => bt.tags)
                .HasForeignKey(b => b.BeitragId);

            modelBuilder.Entity<BeitragTags>()
                .HasOne(b => b.Tags)
                .WithMany(bt => bt.Beitrags)
                .HasForeignKey(b => b.TagId);

            modelBuilder.Entity<BeitragFace>()
                 .HasOne(m => m.Image)
                 .WithOne(b => b.BeitragFace)
                 .HasForeignKey<ImageModelFacebook>(m => m.BeitragFaceId);

            modelBuilder.Entity<BeitragInsta>()
                 .HasOne(m => m.Image)
                 .WithOne(b => b.BeitragInsta)
                 .HasForeignKey<ImageModelInstagram>(m => m.BeitragInstaId);

            modelBuilder.Entity<BeitragPintr>()
                 .HasOne<ImageModelPintr>(m => m.Image)
                 .WithOne(b => b.BeitragPintr)
                 .HasForeignKey<ImageModelPintr>(m => m.BeitragPintrId);


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

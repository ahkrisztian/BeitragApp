using BeitragRdr.Models;
using BeitragRdr.Models.Address;
using BeitragRdr.Models.CompanyModel;
using BeitragRdr.Models.ImageModels;
using BeitragRdr.Models.SubModels;
using BeitragRdr.Models.UserModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace BeitragRdrDataAccessLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<AddressModel> addresses { get; set; }
        public DbSet<PhoneNumberModel> phoneNumbers { get; set; }
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
    }
}

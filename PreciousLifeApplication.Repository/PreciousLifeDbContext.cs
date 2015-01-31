using System.Data.Entity;
using PreciousLifeApplication.Repository.Entities;

namespace PreciousLifeApplication.Repository
{
    public class PreciousLifeDbContext: DbContext
    {
        public PreciousLifeDbContext()
            : base("PreciousLifeDbContextDbContext")
        {
            
        }
        public DbSet<Donor> Doners { get; set; }
        public DbSet<InterestedDonor> IDonors { get; set; }
        public DbSet<Requestor> Requestors { get; set; }
        public DbSet<CollectionCentre> CollectionCentres { get; set; }
        public DbSet<LoginDetails> LoginDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here

            //Configuring Primary Keys
            //modelBuilder.Entity<Donor>().HasKey<int>(s => s.Id);
            //modelBuilder.Entity<InterestedDonor>().HasKey<int>(s => s.Id);
            //modelBuilder.Entity<Requestor>().HasKey<int>(s => s.Id);
            //modelBuilder.Entity<CollectionCentre>().HasKey<int>(s => s.Id);
            //modelBuilder.Entity<LoginDetails>().HasKey<int>(s => s.Id);
            

            //Configuring Foreign Keys

            modelBuilder.Entity<Requestor>()
                        .HasRequired(s => s.CollectionCentre);

            modelBuilder.Entity<InterestedDonor>()
                       .HasRequired(s => s.Donor);

            modelBuilder.Entity<Requestor>()
                       .HasRequired(s => s.CollectionCentre);

            base.OnModelCreating(modelBuilder);
        }
    }
}

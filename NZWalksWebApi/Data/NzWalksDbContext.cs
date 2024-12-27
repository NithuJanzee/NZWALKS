using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using NZWalksWebApi.Models.Domains;

namespace NZWalksWebApi.Data
{
    public class NzWalksDbContext : DbContext
    {
        public NzWalksDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Walk> walks { get; set; }
        public DbSet<Difficulty> difficulties { get; set; }
        public DbSet<Region> regions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    ID = Guid.Parse("95c94607-51d5-49e9-ad0a-070109fef1d1"),
                    Name = "Easy"
                },

                new Difficulty()
                {
                    ID = Guid.Parse("93f5aea2-5c83-44f4-b5ca-63f03860977f"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    ID = Guid.Parse("81a82d74-5f66-4c91-9cc3-028f57c92f14"),
                    Name = "Hard"
                }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region()
                {

                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    FullName = "Auckland",
                    Code = "AKL",
                    ImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    FullName = "Northland",
                    Code = "NTL",
                    ImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    FullName = "Bay Of Plenty",
                    Code = "BOP",
                    ImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    FullName = "Wellington",
                    Code = "WGN",
                    ImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    FullName = "Nelson",
                    Code = "NSN",
                    ImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    FullName = "Southland",
                    Code = "STL",
                    ImageUrl = null
                },
            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}


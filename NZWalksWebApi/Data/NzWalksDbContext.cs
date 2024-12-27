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
    }
}

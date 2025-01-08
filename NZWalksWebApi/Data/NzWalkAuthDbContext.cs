using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalksWebApi.Data
{
    public class NzWalkAuthDbContext : IdentityDbContext
    {
        public NzWalkAuthDbContext(DbContextOptions<NzWalkAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "4cbe8677-d7f2-4f4b-9357-e278dd63d9e4";
            var WriterRoleId = "5dd532ba-1e95-4b4c-98c0-5c79cc0be1d6";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },

                new IdentityRole
                {
                    Id = WriterRoleId,
                    ConcurrencyStamp = WriterRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                }
            };
            
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace NZWalksWebApi.Models.Domains
{
    public class Region
    {
        [Key]
        public Guid Id { get; set; }
        public required string Code { get; set; }
        public required string FullName { get; set; }
        public string? ImageUrl { get; set; }
    }
}

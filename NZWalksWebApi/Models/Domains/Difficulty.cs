using System.ComponentModel.DataAnnotations;

namespace NZWalksWebApi.Models.Domains
{
    public class Difficulty
    {
        [Key]
        public Guid ID { get; set; }
        public required string Name { get; set; }
    }
}

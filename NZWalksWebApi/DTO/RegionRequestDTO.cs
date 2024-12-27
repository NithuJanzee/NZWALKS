using Microsoft.Win32;

namespace NZWalksWebApi.DTO
{
    public class RegionRequestDTO
    {
        public required string Code { get; set; }
        public required string FullName { get; set; }
        public string? ImageUrl { get; set; }
    }
}

namespace NZWalksWebApi.DTO
{
    public class WalkResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double lengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public string DifficultyID { get; set; }
        public string RegionID { get; set; }
    }
}

namespace NZWalksWebApi.DTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double lengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public RegionDto Region { get; set; }
        public DifficultyDTO Difficulty { get; set; }
    }
}

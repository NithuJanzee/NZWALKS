﻿namespace NZWalksWebApi.Models.Domains
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double lengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public Guid DifficultyID { get; set; }
        public Guid RegionID { get; set; }
        //navigation Property
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}
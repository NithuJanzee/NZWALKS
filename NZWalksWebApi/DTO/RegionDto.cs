﻿namespace NZWalksWebApi.DTO
{
    public class RegionDto
    {
        public  Guid Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}

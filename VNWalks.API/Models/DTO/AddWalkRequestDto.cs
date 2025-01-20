namespace VNWalks.API.Models.DTO
{
    public class AddWalkRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid RegionId { get; set; } // để client biết Region nào
        public Guid DifficultyId { get; set; } // để client biết difficulty ở mức nào
    }
}

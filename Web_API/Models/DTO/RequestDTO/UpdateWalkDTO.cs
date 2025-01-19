namespace Web_API.Models.DTO.RequestDTO
{
    public class UpdateWalkDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthinKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }
    }
}

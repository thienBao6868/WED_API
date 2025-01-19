namespace Web_API.Models.DTO.ResponseDTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthinKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public RegionDTO Region { get; set; }
        public DifficultyDTO Difficulty { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace VNWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Code has to be a minimum of 2 characters")]
        [MaxLength(5, ErrorMessage = "Code has to be a maximum of 5 characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "Name has to be a maximum of 25 characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}

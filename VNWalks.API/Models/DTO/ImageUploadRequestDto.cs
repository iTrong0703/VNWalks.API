using System.ComponentModel.DataAnnotations;

namespace VNWalks.API.Models.DTO
{
    public class ImageUploadRequestDto
    {
        [Required]
        public IFormFile ImageFile { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}

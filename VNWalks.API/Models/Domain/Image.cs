using System.ComponentModel.DataAnnotations.Schema;

namespace VNWalks.API.Models.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string FileExtension { get; set; } // .jpg, .png,...
        public long FileSizeInBytes { get; set; }
        public string FilePath { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VNWalks.API.Models.Domain;
using VNWalks.API.Models.DTO;
using VNWalks.API.Repositories;

namespace VNWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        // POST to upload an image
        // POST: https://localhost:port/api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto imageRequestDto)
        {
            ValidateImageUpload(imageRequestDto);
            if (ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    ImageFile = imageRequestDto.ImageFile,
                    FileName = imageRequestDto.FileName,
                    FileDescription = imageRequestDto.FileDescription,
                    FileExtension = Path.GetExtension(imageRequestDto.ImageFile.FileName),
                    FileSizeInBytes = imageRequestDto.ImageFile.Length
                    // FilePath = sẽ đc xử lý và gán trong repository
                };
                await _imageRepository.Upload(imageDomainModel);
                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }

        private void ValidateImageUpload(ImageUploadRequestDto image)
        {
            var allowedExtensions = new string[] { ".jpg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(image.ImageFile.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }
            if (image.ImageFile.Length > 10485760) // 10 MB = 10485760 Bytes
            {
                ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller size file!");
            }
        }
    }
}

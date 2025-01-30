using VNWalks.API.Data;
using VNWalks.API.Models.Domain;

namespace VNWalks.API.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _dbContext;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppDbContext dbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }
        public async Task<Image> Upload(Image image)
        {
            // Lấy file từ client và ghi vào thư mục Images của local
            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", 
                image.FileName + image.FileExtension);
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.ImageFile.CopyToAsync(stream);

            // Lấy ra url ở server và gán vào FilePath
            // Đường dẫn có dạng: https://localhost:1234/Images/abc.png
            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
            image.FilePath = urlFilePath;

            // Thêm image vào database
            await _dbContext.Images.AddAsync(image);
            await _dbContext.SaveChangesAsync();

            return image;
        }
    }
}

using JobPortalAPI.Services.Interaces;

namespace JobPortalAPI.Services
{
    public class ImageService : IImageService
    {
        private const string PhotoUploadPath = "uploads/";
        public async Task<string> SavePhotoAsync(IFormFile photo, string path)
        {
            if (!Directory.Exists(PhotoUploadPath))
            {
                Directory.CreateDirectory(PhotoUploadPath);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                var filePath = Path.Combine(PhotoUploadPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }

                return filePath;          
        }
    }
}

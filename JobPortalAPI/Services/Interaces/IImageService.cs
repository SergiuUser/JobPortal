namespace JobPortalAPI.Services.Interaces
{
    public interface IImageService
    {
        Task<string> SavePhotoAsync(IFormFile photo, string path);
    }
}

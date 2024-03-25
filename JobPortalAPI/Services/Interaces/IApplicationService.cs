namespace JobPortalAPI.Services.Interaces
{
    public interface IApplicationService
    {
        public Task<string> ApplyToJob(int jobID, string coverLetter, IFormFile cv);
        public Task<string> CancelApplication();
    }
}

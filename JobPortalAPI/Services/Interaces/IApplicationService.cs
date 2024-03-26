using JobPortalAPI.Models;

namespace JobPortalAPI.Services.Interaces
{
    public interface IApplicationService
    {
        public Task<string> ApplyToJob(int jobID, string coverLetter, IFormFile cv);
        public Task<string> CancelApplication(int applicationID);
        public Task<IEnumerable<ApplicationModel>> getApplicationsForUser();
        public Task<IEnumerable<ApplicationModel>> getApplicationsForJob(int jobID);
    }
}

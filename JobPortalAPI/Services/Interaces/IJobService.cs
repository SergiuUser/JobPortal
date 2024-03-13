using JobPortalAPI.Models;
using JobPortalAPI.Models.DTO;
using JobPortalAPI.Models.Helpers;

namespace JobPortalAPI.Services.Interaces
{
    public interface IJobService
    {
        public Task<IEnumerable<JobsModel>> GetAllJobs();
        public Task<IEnumerable<JobsModel>> GetJobsByFilter(string? name, double? minSalary, double? maxSalary, List<int>? experience, List<WorkScheduleEnums>? workSchedules, List<string>? categories);

        public Task<string> CreateNewJob(JobDTO entity, List<string>? categories);
        public Task<string> DeleteJob(string jobId);
    }
}

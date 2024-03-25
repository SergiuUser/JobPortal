using JobPortalAPI.Data.Repository.Interfaces;
using JobPortalAPI.Models;
using JobPortalAPI.Models.DTO;
using JobPortalAPI.Models.Helpers;
using JobPortalAPI.Services.Interaces;
using System.Security.Claims;

namespace JobPortalAPI.Services
{
    public class JobService : IJobService
    {
        protected readonly IGenericRepository<JobsModel> _jobRepository;
        protected readonly IGenericRepository<CompanyModel> _companyRepository;
        protected readonly IHttpContextAccessor _contextAccessor;

        public JobService(IGenericRepository<JobsModel> jobRepository, IGenericRepository<CompanyModel> companyRepository, IHttpContextAccessor contextAccessor)
        {
            _jobRepository = jobRepository;
            _companyRepository = companyRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<string> CreateNewJob(JobDTO entity, List<string>? categories)
        {
            int companyID = Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var company = await _companyRepository.GetOneByCondition(x => x.ID == companyID);

            ICollection<JobCategoryModel> jobCategories = new List<JobCategoryModel>(); 

            if (categories != null) 
                foreach(string cat in categories)
                {
                    var category = new JobCategoryModel
                    {
                        Name = cat
                    };
                    jobCategories.Add(category);
                }

            var jobModel = new JobsModel
            {
                Title = entity.Title,
                Description = entity.Description,
                Salary = entity.Salary,
                ExperienceYears = entity.ExperienceYears,
                WorkSchedule = entity.WorkSchedule,
                Company = company,
                JobCategories = jobCategories
            };

            await _jobRepository.CreateAsync(jobModel);
            await _jobRepository.SaveAsync();

            return "Job created succesfuly";
        }

        public Task<string> DeleteJob(string jobId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<JobsModel>> GetAllJobs()
        {
            return _jobRepository.GetAll();
        }

        public async Task<IEnumerable<JobsModel>> GetJobsByFilter(string? name, double? minSalary, double? maxSalary, List<int>? experience, List<WorkScheduleEnums>? workSchedules, List<string>? categories)
        {
            IQueryable<JobsModel> jobs = (IQueryable<JobsModel>)await _jobRepository.GetAll();

            if (name != null)
            {
                string finalName = name.Replace(" ", "").ToLower();
                jobs = jobs.Where(x => x.Title.Replace(" ", "").ToLower().Contains(finalName));
            }

            if (minSalary != null)
                jobs = jobs.Where(x => x.Salary >= minSalary);

            if (maxSalary != null)
                jobs = jobs.Where(x => x.Salary <= maxSalary);

            if (experience != null)
                jobs.Where(x => experience.Contains((int)x.ExperienceYears));

            if (workSchedules != null)
                jobs.Where(x => workSchedules.Contains(x.WorkSchedule));

            if (categories != null)
                return jobs; // Job category filters need to be added

            return jobs;
        }

    }
}

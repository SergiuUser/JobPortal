using JobPortalAPI.Data.Repository.Interfaces;
using JobPortalAPI.Models;
using JobPortalAPI.Services.Interaces;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobPortalAPI.Services
{
    public class ApplicationService : IApplicationService
    {
        protected readonly IGenericRepository<ApplicationModel> _applicationRepository;
        protected readonly IGenericRepository<JobsModel> _jobRepository;
        protected readonly IGenericRepository<PersonModel> _personRepository;
        protected readonly IHttpContextAccessor _contextAccessor;
        protected readonly IImageService _imageService;

        public ApplicationService(IGenericRepository<ApplicationModel> applicationRepository, IHttpContextAccessor contextAccessor, IGenericRepository<PersonModel> personRepository
            , IImageService imageService, IGenericRepository<JobsModel> jobRepository)
        {
            _applicationRepository = applicationRepository;
            _contextAccessor = contextAccessor;
            _personRepository = personRepository;
            _imageService = imageService;
            _jobRepository = jobRepository;
        }

        public async Task<string> ApplyToJob(int jobID, string coverLetter, IFormFile cv)
        {
            int userID = Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var person = await _personRepository.GetOneByCondition(x => x.ID == userID);

            var job = await _jobRepository.GetOneByCondition(x => x.ID == jobID);


            var application = new ApplicationModel()
            {
                Jobs = job,
                Person = person,
                CoverLetter = coverLetter,
                ResumePath = "Default",
                ApplicationDate = DateTime.Now,
            };

            if (cv != null && cv.Length > 0)
            {
                var cvPath = await _imageService.SavePhotoAsync(cv, "cv/");
                application.ResumePath = cvPath;
            }

            await _applicationRepository.CreateAsync(application);
            await _applicationRepository.SaveAsync();

            return "The application have been submited";
        }

        public async Task<string> CancelApplication(int applicationID)
        {
            int personID = Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var application = await _applicationRepository.GetOneByCondition(i => i.PersonID.Equals(personID));
            if (application != null)
            {
                await _applicationRepository.DeleteAsync(application.ID);
                await _applicationRepository.SaveAsync();
            }
            else return "You are not authorize to do that";

            return "Application was canceled, u cannot recover it";

        }

        public async Task<IEnumerable<ApplicationModel>> getApplicationsForJob(int jobID)
        {
            int companyID = Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
             
            var applications = await _applicationRepository.GetAllByCondition(i => i.JobID.Equals(jobID));

            if (applications != null)
            {
                return applications;
            }
            else return null;

        }

        public async Task<IEnumerable<ApplicationModel>> getApplicationsForUser()
        {
            int personID = Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var applications = await _applicationRepository.GetAllByCondition(i => i.PersonID.Equals(personID));

            if (applications != null)
            {
                return applications;
            }
            else return null;
        }
    }
}

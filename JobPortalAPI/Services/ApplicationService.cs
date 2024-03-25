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

        public Task<string> CancelApplication()
        {
            throw new NotImplementedException();
        }
    }
}

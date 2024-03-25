using JobPortalAPI.Models.DTO;
using JobPortalAPI.Models.Helpers;
using JobPortalAPI.Services.Interaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private readonly IJobService _jobService;

        public JobController(IJobService jobService) => _jobService = jobService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await _jobService.GetAllJobs();
            if (jobs != null)
            {
                return Ok(jobs);
            }
            else return NotFound("No jobs were found");
        }

        [HttpPost("addnewjob")]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> AddNewJob([FromQuery] JobDTO entity, [FromQuery] List<string>? categories)
        {
            try
            {
                var result = await _jobService.CreateNewJob(entity, categories);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest("An error occured, code " + ex.Message);
            }
        }



    }
}

using JobPortalAPI.Services.Interaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService) => _applicationService = applicationService;

        [HttpPost("apply")]
        [Authorize(Roles = "seeker")]
        public async Task<IActionResult> ApplyToJob([FromQuery] int jobID, [FromQuery] string? coverLetter, IFormFile cv)
        {
            string result = await _applicationService.ApplyToJob(jobID, coverLetter, cv);
            if (result != null)
                return Ok(result);
            else return BadRequest("Server error");
        }

        [HttpDelete("cancel")]
        [Authorize(Roles = "seeker")]
        public async Task<IActionResult> CancelApplication([FromQuery] int applicationId)
        {
           string result = await _applicationService.CancelApplication(applicationId);
                return Ok(result);
        }

        [HttpGet("applicationsforuser")]
        [Authorize(Roles = "seeker")]
        public async Task<IActionResult> getApplicationsforUser()
        {
            var applications = await _applicationService.getApplicationsForUser();
            if (applications != null)
                return Ok(applications);
            else return NotFound("No applications were found");
        }

        [HttpGet("applicationsforjob")]
        [Authorize(Roles = "company")]
        public async Task<IActionResult> getApplicationsforUser(int jobID)
        {
            var applications = await _applicationService.getApplicationsForJob(jobID);
            if (applications != null)
                return Ok(applications);
            else return NotFound("No applications were found");
        }





    }
}

using JobPortalAPI.Services.Interaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> ApplyToJob(int jobID, string? coverLetter, IFormFile cv)
        {
            string result = await _applicationService.ApplyToJob(jobID, coverLetter, cv);
            if (result != null)
                return Ok(result);
            else return BadRequest("Server error");
        }




    }
}

using JobPortalAPI.Models.DTO;
using JobPortalAPI.Models.DTO.CompanyDTOs;
using JobPortalAPI.Models.DTO.PersonDTOs;
using JobPortalAPI.Services.Interaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _service;

        public PersonController(IPersonService service) => _service = service;

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromForm] LoginDTO entity)
        {
            try
            {
                var result = await _service.LoginAsync(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("An error ocurred, code: " + ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] PersonRegisterDTO entity, IFormFile? photo)
        {
            try
            {
                var result = await _service.RegisterAsync(entity, photo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("An error ocurred, code" + ex.Message);
            }
        }


    }
}

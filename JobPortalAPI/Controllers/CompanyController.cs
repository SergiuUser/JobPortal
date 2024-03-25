using JobPortalAPI.Models.DTO;
using JobPortalAPI.Models.DTO.CompanyDTOs;
using JobPortalAPI.Services.Interaces;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service) => _service = service;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDTO entity)
        {
            try
            {
                var result = await _service.LoginAsync(entity);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest("An error ocurred, code: " + ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] CompanyRegisterDTO entity, IFormFile logo)
        {
            try
            {
                var result = await _service.RegisterAsync(entity, logo);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest("An error ocurred, code" + ex.Message);
            }
        }

        [HttpGet("/getallcompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _service.GetAllCompanies();
            if (companies != null)
            {
                return Ok(companies);
            }
            else return NotFound("No companies were found");
        }

        [HttpGet("getcompaniesbyname")]
        public async Task<IActionResult> GetAllCompaniesByName([FromQuery] string name)
        {
            var companies = await _service.GetAllCompaniesByName(name);
            if (companies != null)
            {
                return Ok(companies);
            }
            else return NotFound("No companies were found");
        }


    }
}

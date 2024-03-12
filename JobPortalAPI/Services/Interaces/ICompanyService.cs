using JobPortalAPI.Models;
using JobPortalAPI.Models.DTO;
using JobPortalAPI.Models.DTO.CompanyDTOs;

namespace JobPortalAPI.Services.Interaces
{
    public interface ICompanyService
    {
        Task<string> RegisterAsync(CompanyRegisterDTO entity, IFormFile photo);
        Task<string> LoginAsync(LoginDTO entity);
    }
}

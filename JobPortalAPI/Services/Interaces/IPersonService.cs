using JobPortalAPI.Models.DTO;
using JobPortalAPI.Models.DTO.CompanyDTOs;
using JobPortalAPI.Models.DTO.PersonDTOs;

namespace JobPortalAPI.Services.Interaces
{
    public interface IPersonService
    {
        Task<string> RegisterAsync(PersonRegisterDTO entity, IFormFile? photo);
        Task<string> LoginAsync(LoginDTO entity);
    }
}

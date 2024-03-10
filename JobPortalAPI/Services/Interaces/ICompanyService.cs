using JobPortalAPI.Models;

namespace JobPortalAPI.Services.Interaces
{
    public interface ICompanyService
    {
        Task RegisterAsync(CompanyModel entity);
        Task<string> LoginAsync(CompanyModel entity);
    }
}

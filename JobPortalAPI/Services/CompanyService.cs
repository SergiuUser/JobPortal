using JobPortalAPI.Data.Context;
using JobPortalAPI.Data.Repository;

namespace JobPortalAPI.Services
{
    public class CompanyService
    {
        protected readonly CompanyRepository _repository;

        public CompanyService(CompanyRepository repository) => _repository = repository;
    }
}

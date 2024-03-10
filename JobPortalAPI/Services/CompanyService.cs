using JobPortalAPI.Data.Context;
using JobPortalAPI.Data.Repository;
using JobPortalAPI.Data.Repository.Interfaces;
using JobPortalAPI.Models;

namespace JobPortalAPI.Services
{
    public class CompanyService
    {
        protected readonly IGenericRepository<CompanyModel> _repository;

        public CompanyService(IGenericRepository<CompanyModel> repository) => _repository = repository;

        

    }
}

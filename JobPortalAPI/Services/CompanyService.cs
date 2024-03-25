
using JobPortalAPI.Data.Repository.Interfaces;
using JobPortalAPI.Models;
using JobPortalAPI.Models.DTO;
using JobPortalAPI.Models.DTO.CompanyDTOs;
using JobPortalAPI.Services.Interaces;
using System.Security.Claims;

namespace JobPortalAPI.Services
{
    public class CompanyService : ICompanyService
    {
        protected readonly IGenericRepository<CompanyModel> _repository;
        protected readonly IGenericRepository<CompanyLoginInfo> _repositoryLogin;
        protected readonly IJwtService _jwtService;
        protected readonly IImageService _imageService;

        public CompanyService(IGenericRepository<CompanyModel> repository, IGenericRepository<CompanyLoginInfo> repositoryLogin, IJwtService jwtService, IImageService image)
        {
            _repository = repository;
            _repositoryLogin = repositoryLogin;
            _jwtService = jwtService;
            _imageService = image;
        }

        public async Task<string> LoginAsync(LoginDTO entity)
        {

            var CompanyLoginInfo = await _repositoryLogin.GetOneByCondition(e => e.Email == entity.Email);

            if (CompanyLoginInfo == null)
            {
                return "Email incorrect";
            }

            if (!BCrypt.Net.BCrypt.Verify(entity.Password, CompanyLoginInfo.Password))
            {
                return "Password incorrect";
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, CompanyLoginInfo.CompanyID.ToString()),
                    new Claim(ClaimTypes.Email, CompanyLoginInfo.Email),
                    new Claim(ClaimTypes.Role, CompanyLoginInfo.Role.ToString())
                };

            var token = _jwtService.GetToken(claims);

            return token;
        }

        public async Task<string> RegisterAsync(CompanyRegisterDTO entity, IFormFile? photo)
        {
            var emailCheck = await _repository.GetOneByCondition(e => e.Login.Email == entity.Register.Email);
            if (emailCheck != null)
            {
                return "This email already exists";
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(entity.Register.Password);

            var loginInfo = new CompanyLoginInfo
            {
                IsEmailConfirmed = true,
                Password = hashedPassword,
                Email = entity.Register.Email,
            };

            var adressInfo = new CompanyAddressModel
            {
                City = entity.Address.City,
                Adress = entity.Address.Adress,
                Country = entity.Address.Country,
            };

            var company = new CompanyModel
            {
                Name = entity.Company.Name,
                Email = entity.Company.Email,
                About = entity.Company.About,
                Website = entity.Company.Website,
                Login = loginInfo,
                Adress = adressInfo,
            };
            if (photo != null && photo.Length > 0)
            {
                var photoPath = await _imageService.SavePhotoAsync(photo);
                company.LogoPath = photoPath;
            }
            else { company.LogoPath = "Default"; }

            await _repository.CreateAsync(company);
            await _repository.SaveAsync();

            return "Registration successful. Please go to Login";
        }

    }
}

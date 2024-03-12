using JobPortalAPI.Data.Repository.Interfaces;
using JobPortalAPI.Models;
using JobPortalAPI.Models.DTO;
using JobPortalAPI.Models.DTO.PersonDTOs;
using JobPortalAPI.Services.Interaces;
using System.Security.Claims;

namespace JobPortalAPI.Services
{
    public class PersonService : IPersonService
    {
        protected readonly IGenericRepository<PersonModel> _repository;
        protected readonly IGenericRepository<PersonLoginInfoModel> _repositoryLogin;
        protected readonly IJwtService _jwtService;
        protected readonly IImageService _imageService;

        public PersonService(IGenericRepository<PersonModel> repository, IGenericRepository<PersonLoginInfoModel> repositoryLogin, IJwtService jwtService, IImageService imageService)
        {
            _repository = repository;
            _repositoryLogin = repositoryLogin;
            _jwtService = jwtService;
            _imageService = imageService;
        }

        public async Task<string> LoginAsync(LoginDTO entity)
        {
            var personLoginInfo = await _repositoryLogin.GetOneByCondition(e => e.Email == entity.Email);

            if (personLoginInfo == null)
            {
                return "Email incorrect";
            }

            if (!BCrypt.Net.BCrypt.Verify(entity.Password, personLoginInfo.Password))
            {
                return "Password incorrect";
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, personLoginInfo.PersonID.ToString()),
                    new Claim(ClaimTypes.Email, personLoginInfo.Email),
                    new Claim(ClaimTypes.Role, personLoginInfo.Role.ToString())
                };

            var token = _jwtService.GetToken(claims);

            return token;
        }

        public async Task<string> RegisterAsync(PersonRegisterDTO entity, IFormFile? photo)
        {
            var emailCheck = await _repository.GetOneByCondition(e => e.Login.Email == entity.Register.Email);
            if (emailCheck != null)
            {
                return "This email already exists";
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(entity.Register.Password);

            var loginInfo = new PersonLoginInfoModel
            {
                IsEmailConfirmed = true,
                Password = hashedPassword,
                Email = entity.Register.Email,
            };

            var adressInfo = new PersonAddressModel
            {
                City = entity.Adress.City,
                Adress = entity.Adress.Adress,
                Country = entity.Adress.Country,
            };

            var company = new PersonModel
            {
                FirstName = entity.Person.FirstName,
                LastName = entity.Person.LastName,
                PhoneNumber = entity.Person.PhoneNumber,
                Address = adressInfo,
                Login = loginInfo,
            };

            if (photo != null && photo.Length > 0)
            {
                var photoPath = await _imageService.SavePhotoAsync(photo);
                company.PhotoPath = photoPath;
            }
            else { company.PhotoPath = "uploads/photos/default.png"; }

            await _repository.CreateAsync(company);
            await _repository.SaveAsync();

            return "Registration successful. Please go to Login";
        }
    }
}

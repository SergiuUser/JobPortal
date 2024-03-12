namespace JobPortalAPI.Models.DTO.CompanyDTOs
{
    public class CompanyRegisterDTO
    {
        public RegisterDTO Register { get; set; }
        public CompanyDTO Company { get; set; }
        public CompanyAddressDTO Address { get; set; }
    }
}

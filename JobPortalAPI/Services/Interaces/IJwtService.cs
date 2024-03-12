using System.Security.Claims;

namespace JobPortalAPI.Services.Interaces
{
    public interface IJwtService
    {
        string GetToken(List<Claim> claims);
    }
}

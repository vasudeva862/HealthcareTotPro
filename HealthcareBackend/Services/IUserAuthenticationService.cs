using HealthCareTestingLabPortel.Models;
namespace HealthCareTestingLabPortel.Services
{
    public interface IUserAuthenticationService
    {
        UserDetails GetDetails(string Email, string Role);
    }
}

using HealthCareTestingLabPortel.Models;

namespace HealthCareTestingLabPortel.Services
{
    public interface IUserDetailsService
    {
        List<UserDetails> Get();
        UserDetails GetById(int id);
        UserDetails Create(UserDetails userDetails);
        void Update(int id, UserDetails userDetails);
        void Delete(int id);

        UserDetails GetDetails(string Email, string Role);
    }
}

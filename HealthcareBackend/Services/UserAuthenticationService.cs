using MongoDB.Driver;
using HealthCareTestingLabPortel.Models;
using static HealthCareTestingLabPortel.Services.UserAuthenticationService;

namespace HealthCareTestingLabPortel.Services
    
    
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IMongoCollection<UserDetails> _allUserDetails;
        public UserAuthenticationService(IHealthCareDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _allUserDetails = database.GetCollection<UserDetails>(settings.UserDetailsCollectionName);
        }
        public UserDetails GetDetails(string Email, string Role)
        {
            return _allUserDetails.Find(user => (user.Emailaddress == Email && user.Role == Role)).FirstOrDefault();
        }
    }
}

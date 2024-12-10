using HealthCareTestingLabPortel.Models;
using MongoDB.Driver;

namespace HealthCareTestingLabPortel.Services
{
    public class UserRoleServices : IUserRoleService
    {
        private readonly IMongoCollection<UserRoles> _Roles;
        public UserRoleServices(IHealthCareDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _Roles = database.GetCollection<UserRoles>(settings.UserRolesCollectionName);
        }
        public List<UserRoles> Get()
        {
            return _Roles.Find(userRole => true).ToList();
        }
    }
}

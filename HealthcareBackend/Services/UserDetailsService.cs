using HealthCareTestingLabPortel.Models;
using MongoDB.Driver;
namespace HealthCareTestingLabPortel.Services
{
    public class UserDetailsService : IUserDetailsService
    {
        private readonly IMongoCollection<UserDetails> _alluserdetails;

        public UserDetailsService(IHealthCareDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _alluserdetails = database.GetCollection<UserDetails>(settings.UserDetailsCollectionName);
        }
        public UserDetails Create(UserDetails userDetail)
        {
            var obj = _alluserdetails.Find(user => true).ToList();
            int count = obj.Count();
            userDetail.RecordId = count + 1;
            _alluserdetails.InsertOne(userDetail);
            return userDetail;
        }
        public void Delete(int id)
        {
            _alluserdetails.DeleteOne(user => user.RecordId == id);
        }
        public List<UserDetails> Get()
        {
            return _alluserdetails.Find(user => true).ToList();
        }

        public UserDetails GetById(int id)
        {
            return _alluserdetails.Find(user => user.RecordId == id).FirstOrDefault();
        }
        public void Update(int id, UserDetails userDetail)
        {
            _alluserdetails.ReplaceOne(user => user.RecordId == id, userDetail);
        }
        public UserDetails GetDetails(string Email, string Role)
        {
            return _alluserdetails.Find(user => (user.Emailaddress == Email && user.Role == Role)).FirstOrDefault();
        }
    }
}

    

using HealthCareTestingLabPortel.Models;
using MongoDB.Driver;

namespace HealthCareTestingLabPortel.Services

{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IMongoCollection<Orderdetails> _allOrderDetails;
        public OrderDetailService(IHealthCareDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _allOrderDetails = database.GetCollection<Orderdetails>(settings.OrderDetailsCollectionName);
        }

        public Orderdetails Create(Orderdetails orderDetail)
        {
            var obj = _allOrderDetails.Find(user => true).ToList();
            int count = obj.Count();
            orderDetail.RecordId = count + 1;
            _allOrderDetails.InsertOne(orderDetail);
            return orderDetail;
        }

        public void Delete(int id)
        {
            _allOrderDetails.DeleteOne(order => order.RecordId == id);

        }

        public List<Orderdetails> Get(string role, int userId)
        {
            if(role.ToUpper() == "ADMIN")
            {
                return _allOrderDetails.Find(order => true).ToList();
            }
            else
            {
                return _allOrderDetails.Find(order => order.CreatedBy == userId).ToList();

            }
        }

      

        public Orderdetails GetById(int id)
        {
            return _allOrderDetails.Find(order => order.RecordId == id).FirstOrDefault();
        }

        public void Update(int id, Orderdetails orderDetail)
        {
            _allOrderDetails.ReplaceOne(order => order.RecordId == id, orderDetail);
        }
    }
}


    

using HealthCareTestingLabPortel.Models;

namespace HealthCareTestingLabPortel.Services
{
    public interface IOrderDetailService
    {
        List<Orderdetails> Get(string role, int userId);
        Orderdetails GetById(int RecordId);
       
        Orderdetails Create(Orderdetails orderdetails);
        void Update(int RecordId, Orderdetails orderdetails);
        void Delete(int RecordId);
    }
}

using HealthCareTestingLabPortel.Models;

namespace HealthCareTestingLabPortel.Services
{
    public interface ILabDetailService
    {
        
        List<LabDetails> Get();
        LabDetails GetById(int id);
        LabDetails Create(LabDetails labDetail);
        void Update(int id, LabDetails labDetail);
        void Delete(int id);
    }
}

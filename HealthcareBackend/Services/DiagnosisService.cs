using HealthCareTestingLabPortel.Models;
using MongoDB.Driver;

namespace HealthCareTestingLabPortel.Services
{
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IMongoCollection<Diagnosis> _Diagnosis;
        public DiagnosisService(IHealthCareDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _Diagnosis = database.GetCollection<Diagnosis>(settings.DiagnosisCategoryCollectionName);
        }

        public List<Diagnosis> Get()
        {
            return _Diagnosis.Find(diagnosisName => true).ToList();
        }
    }
}

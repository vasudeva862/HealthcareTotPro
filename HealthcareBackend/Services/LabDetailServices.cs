using HealthCareTestingLabPortel.Models;
using MongoDB.Driver;

namespace HealthCareTestingLabPortel.Services
{
    public class LabDetailServices: ILabDetailService
    {
        private readonly IMongoCollection<LabDetails> _allLabDetails;
        public LabDetailServices(IHealthCareDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _allLabDetails = database.GetCollection<LabDetails>(settings.LabDetailsCollectionName);

        }

        public LabDetails Create(LabDetails labDetail)
        {
            var obj = _allLabDetails.Find(user => true).ToList();
            int count = obj.Count();
            labDetail.RecordId = count + 1;
            _allLabDetails.InsertOne(labDetail);
            return labDetail;
        }
        public void Delete(int id)
        {
            _allLabDetails.DeleteOne(lab=>lab.RecordId == id);
        }
        public List<LabDetails> Get()
        {
            return _allLabDetails.Find(lab => true).ToList();
        }
        public LabDetails GetById(int id)
        {
            return _allLabDetails.Find(lab => lab.RecordId == id).FirstOrDefault();

        }
        public void Update(int id, LabDetails labDetail)
        {
            _allLabDetails.ReplaceOne(lab => lab.RecordId == id, labDetail);
        }
        

       
    }

}


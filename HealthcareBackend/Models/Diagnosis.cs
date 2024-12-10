using MongoDB.Bson.Serialization.Attributes;

namespace HealthCareTestingLabPortel.Models
{
    [BsonIgnoreExtraElements]
    public class Diagnosis
    {
        
        [BsonElement("DiagnosisId")]
        public int DiagnosisId { get; set; }

        [BsonElement("DiagnosisName")]
        public string DiagnosisName { get; set; } = string.Empty;
    }
}

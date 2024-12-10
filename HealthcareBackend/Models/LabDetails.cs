using MongoDB.Bson.Serialization.Attributes;

namespace HealthCareTestingLabPortel.Models
{
    [BsonIgnoreExtraElements]
    public class LabDetails
    {
        
       
        [BsonElement("RecordId")]
        public int RecordId { get; set; }
        [BsonElement("LabName")]

        public string LabName { get; set; } = string.Empty;
        [BsonElement("LabId")]
        public int LabId { get; set; }
        [BsonElement("LabAddress")]
        public string LabAddress { get; set; }  =String.Empty;
        [BsonElement("City")]
        public string City { get; set; } = string.Empty;
        [BsonElement("State")]
        public string State { get; set; } = string.Empty;
        [BsonElement("ContactNumber")]
        public Int64 ContactNumber { get; set; } 




    }
}


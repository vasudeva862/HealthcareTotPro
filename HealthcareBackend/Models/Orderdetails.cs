using MongoDB.Bson.Serialization.Attributes;

namespace HealthCareTestingLabPortel.Models
{
    [BsonIgnoreExtraElements]
    public class Orderdetails
    {
        [BsonElement("RecordId")]
        public int RecordId { get; set; }
       
        [BsonElement("LabName")]

        public string LabName { get; set; } = String.Empty;
        [BsonElement("UserFirstName")]
        public string UserFirstName { get; set; } = String.Empty;
        [BsonElement("UserLastName")]
        public string UserLastName { get; set; } = String.Empty;
        [BsonElement("Status")]
        public string Status { get; set; } = string.Empty;
        [BsonElement("Category")]
        public string Category { get; set; } = string.Empty;
        [BsonElement("OrderedDate")]
        public string OrderedDate { get; set; }=String.Empty;
        [BsonElement("DoctorPrescription")]
        public string DoctorPrescription { get; set; }=String.Empty;
        [BsonElement("CreatedBy")]
        public Int32 CreatedBy { get; set; }
        [BsonElement("CreatedOn")]
        public DateTime CreatedOn { get; set; }
       
    }

}

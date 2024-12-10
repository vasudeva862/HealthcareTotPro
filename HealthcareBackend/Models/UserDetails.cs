using MongoDB.Bson.Serialization.Attributes;


namespace HealthCareTestingLabPortel.Models
{
    [BsonIgnoreExtraElements]
    public class UserDetails
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }=string.Empty;
        [BsonElement("RecordId")]
        public int RecordId { get; set; }
        [BsonElement("FirstName")]
        public string FirstName { get; set; } = String.Empty;
        [BsonElement("LastName")]
        public string LastName { get; set; } = String.Empty;
        [BsonElement("Emailaddress")]
        public string Emailaddress { get; set; } = string.Empty;
        [BsonElement("MobileNumber")]
        public Int64 MobileNumber { get; set; }
        [BsonElement("DateOfBirth")]
        public DateTime DateOfBirth { get; set; } 
        [BsonElement("Role")]
        public string Role { get; set; } = string.Empty;
        [BsonElement("Password")]
        public string Password { get; set; } = string.Empty;
       

    }
}

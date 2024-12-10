using MongoDB.Bson.Serialization.Attributes;

namespace HealthCareTestingLabPortel.Models
{
    [BsonIgnoreExtraElements]
    public class UserRoles
    {
        [BsonElement("RoleId")]
        public int RoleId { get; set; }
        [BsonElement("RoleName")]
        public string RoleName { get; set; } = string.Empty;
        [BsonElement("Description")]
        public string Description { get; set; } = string.Empty;
    }
}

namespace HealthCareTestingLabPortel.Models
{
    public class HealthCareDatabaseSettings : IHealthCareDatabaseSettings
    {
        public string UserDetailsCollectionName { get; set; } = string.Empty;
        public string UserRolesCollectionName { get; set; }=string.Empty;
        public string OrderDetailsCollectionName { get; set; }=string.Empty;
        public string LabDetailsCollectionName { get; set; } = string.Empty;
        public string DiagnosisCategoryCollectionName { get; set; } = string.Empty;

   

        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}

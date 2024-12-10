namespace HealthCareTestingLabPortel.Models
{
    public interface IHealthCareDatabaseSettings
    {
        string UserDetailsCollectionName { get; set; }
        string UserRolesCollectionName { get; set; }
        string OrderDetailsCollectionName { get;  set; }
        string LabDetailsCollectionName { get; set; }
        string DiagnosisCategoryCollectionName { get; set; } 

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

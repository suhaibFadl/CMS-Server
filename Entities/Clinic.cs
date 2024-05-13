namespace ClinicsSystem.Models
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        public string? Name { get; set; }
        public City city = new City();
    }
}

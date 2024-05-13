namespace ClinicsSystem.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string? Name { get; set; }
        public int NationalNo { get; set; }
        public int PassportNo { get; set; }
        public int FileNo { get; set; }
        public required Clinic clinic;

    }
}

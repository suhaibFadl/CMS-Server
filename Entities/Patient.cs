using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicsSystem.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string? Name { get; set; }
        public int NationalNo { get; set; }
        public int PassportNo { get; set; }
        [ForeignKey("PatientsClinic")]
        public int FileNo { get; set; }

        public PatientsClinics? PatientsClinics { get; set; }
    }
}

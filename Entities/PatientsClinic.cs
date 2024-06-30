using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicsSystem.Models
{
    public enum FileStatus
    {
        NotOpen,
        Open,
        Closed
    }

    public class PatientsClinics
    {
        [Key]
        public int FileNo { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        [ForeignKey("Clinic")]
        public int ClinicId { get; set; }
        public Clinic? Clinic { get; set; }

        public FileStatus FileStatus { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }

        public PatientsClinics()
        {
            EntryDate = DateTime.Now;
        }
    }
}


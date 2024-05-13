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
        public int PatientsClinicsId { get; set; }
        public int FileNo { get; set; }
        public required Patient patient;
        public required Clinic clinic;       
        public FileStatus FileStatus { get; set; }
        public DateTime EntryDate;
        public DateTime ExitDate;
    }
}

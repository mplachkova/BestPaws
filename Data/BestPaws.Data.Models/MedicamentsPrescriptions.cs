namespace BestPaws.Data.Models
{
    public class MedicamentsPrescriptions
    {
        public int MedicamentId { get; set; }

        public Medicament Medicament { get; set; }

        public int PrescriptionId { get; set; }

        public Prescription Prescription { get; set; }
    }
}

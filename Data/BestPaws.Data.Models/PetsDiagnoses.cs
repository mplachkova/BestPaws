namespace BestPaws.Data.Models
{
    public class PetsDiagnoses
    {
        public int PetId { get; set; }

        public Pet Pet { get; set; }

        public int DiagnosisId { get; set; }

        public Diagnosis Diagnosis { get; set; }
    }
}

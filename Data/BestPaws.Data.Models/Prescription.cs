namespace BestPaws.Data.Models
{
    using System.Collections.Generic;

    using BestPaws.Data.Common.Models;

    public class Prescription : BaseDeletableModel<int>
    {

        public Prescription()
        {
            this.PrescriptionsMedicaments = new HashSet<MedicamentsPrescriptions>();
        }

        public Pet Pet { get; set; }

        public int PetId { get; set; }

        public Doctor Doctor { get; set; }

        public string DoctorId { get; set; }

        public ICollection<MedicamentsPrescriptions> PrescriptionsMedicaments { get; set; }
    }
}

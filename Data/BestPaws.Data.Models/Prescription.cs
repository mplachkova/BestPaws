namespace BestPaws.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BestPaws.Data.Common.Models;

    public class Prescription : BaseDeletableModel<int>
    {

        public Prescription()
        {
            this.PrescriptionsMedicaments = new HashSet<MedicamentsPrescriptions>();
        }

        [Required]
        public Pet Pet { get; set; }

        public int PetId { get; set; }

        [Required]
        public Doctor Doctor { get; set; }

        public string DoctorId { get; set; }

        public ICollection<MedicamentsPrescriptions> PrescriptionsMedicaments { get; set; }
    }
}

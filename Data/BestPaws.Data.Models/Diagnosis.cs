namespace BestPaws.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BestPaws.Data.Common.Models;

    public class Diagnosis : BaseDeletableModel<int>
    {
        public Diagnosis()
        {
            this.DiagnosesPets = new HashSet<PetsDiagnoses>();
        }

        [Required]
        public string Name { get; set; }

        public string Comments { get; set; }

        [Required]
        public Doctor Doctor { get; set; }

        public string DoctorId { get; set; }

        public DateTime FromDate { get; set; }

        public ICollection<PetsDiagnoses> DiagnosesPets { get; set; }
    }
}

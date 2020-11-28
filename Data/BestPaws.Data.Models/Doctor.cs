namespace BestPaws.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BestPaws.Data.Common.Models;

    public class Doctor : BaseDeletableModel<string>
    {
        public Doctor()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Diagnoses = new HashSet<Diagnosis>();
            this.Prescriptions = new HashSet<Prescription>();
            this.Tests = new HashSet<Test>();
        }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string PictureLocation { get; set; }

        [Required]
        [MaxLength(100)]
        public string Specialization { get; set; }

        public string Biography { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

        public ICollection<Diagnosis> Diagnoses { get; set; }

        public ICollection<Test> Tests { get; set; }
    }
}

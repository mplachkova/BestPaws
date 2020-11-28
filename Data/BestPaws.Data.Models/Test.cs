namespace BestPaws.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BestPaws.Data.Common.Models;

    public class Test : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public Pet Pet { get; set; }

        public int PetId { get; set; }

        public DateTime FromDate { get; set; }

        [Required]
        public Doctor Doctor { get; set; }

        public string DoctorId { get; set; }

        public string Comments { get; set; }

        public TestType TestType { get; set; }

        public int TestTypeId { get; set; }
    }
}

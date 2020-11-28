namespace BestPaws.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BestPaws.Data.Common.Models;

    public class Medicament : BaseDeletableModel<int>
    {
        public Medicament()
        {
            this.MedicamentsPrescriptions = new HashSet<MedicamentsPrescriptions>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<MedicamentsPrescriptions> MedicamentsPrescriptions { get; set; }
    }
}

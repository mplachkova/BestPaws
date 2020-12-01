namespace BestPaws.Data.Models
{
    using System.Collections.Generic;

    using BestPaws.Data.Common.Models;

    public class Medicament : BaseDeletableModel<int>
    {
        public Medicament()
        {
            this.MedicamentsPrescriptions = new HashSet<MedicamentsPrescriptions>();
        }

        public string Name { get; set; }

        public ICollection<MedicamentsPrescriptions> MedicamentsPrescriptions { get; set; }
    }
}

namespace BestPaws.Data.Models
{
    using System.Collections.Generic;

    using BestPaws.Data.Common.Models;

    public class Treatment : BaseDeletableModel<int>
    {
        public Treatment()
        {
            this.PetsTreatments = new HashSet<PetsTreatments>();
        }

        public string Name { get; set; }

        public ICollection<PetsTreatments> PetsTreatments { get; set; }
    }
}

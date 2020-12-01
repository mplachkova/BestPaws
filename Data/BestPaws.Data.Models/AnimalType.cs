namespace BestPaws.Data.Models
{
    using System.Collections.Generic;

    using BestPaws.Data.Common.Models;

    public class AnimalType : BaseDeletableModel<int>
    {
        public AnimalType()
        {
            this.ReferenceValues = new HashSet<ReferenceValue>();
        }

        public string Name { get; set; }

        public ICollection<ReferenceValue> ReferenceValues { get; set; }
    }
}

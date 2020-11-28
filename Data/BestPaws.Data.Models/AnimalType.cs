namespace BestPaws.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BestPaws.Data.Common.Models;

    public class AnimalType : BaseDeletableModel<int>
    {
        public AnimalType()
        {
            this.ReferenceValues = new HashSet<ReferenceValue>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<ReferenceValue> ReferenceValues { get; set; }
    }
}

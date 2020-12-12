namespace BestPaws.Data.Models
{
    using BestPaws.Data.Common.Models;

    public class ReferenceValue : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Units { get; set; }

        public decimal MinValue { get; set; }

        public decimal MaxValue { get; set; }

        public AnimalType AnimalType { get; set; }

        public int AnimalTypeId { get; set; }
    }
}

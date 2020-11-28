namespace BestPaws.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BestPaws.Data.Common.Models;

    public class TestResult : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        [Required]
        public ReferenceValue ReferenceValue { get; set; }

        public int RefValueId { get; set; }

        [Required]
        public TestType TestType { get; set; }

        public int TestTypeId { get; set; }
    }
}

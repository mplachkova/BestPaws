namespace BestPaws.Data.Models
{

    using BestPaws.Data.Common.Models;

    public class TestResult : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public ReferenceValue ReferenceValue { get; set; }

        public int RefValueId { get; set; }

        public TestType TestType { get; set; }

        public int TestTypeId { get; set; }
    }
}

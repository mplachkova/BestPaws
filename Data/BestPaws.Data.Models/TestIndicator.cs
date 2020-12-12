namespace BestPaws.Data.Models
{

    using BestPaws.Data.Common.Models;

    public class TestIndicator : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public string Units { get; set; }

        public ReferenceValue ReferenceValue { get; set; }

        public int RefValueId { get; set; }

        public TestResult TestResult { get; set; }

        public int TestResultId { get; set; }
    }
}

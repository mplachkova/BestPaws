namespace BestPaws.Data.Models
{
    using System.Collections.Generic;

    using BestPaws.Data.Common.Models;

    public class TestResult : BaseDeletableModel<int>
    {
        public TestResult()
        {
            this.TestIndicators = new HashSet<TestIndicator>();
        }

        public ICollection<TestIndicator> TestIndicators { get; set; }
    }
}

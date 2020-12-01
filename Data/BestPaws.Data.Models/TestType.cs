namespace BestPaws.Data.Models
{
    using System.Collections.Generic;

    using BestPaws.Data.Common.Models;

    public class TestType : BaseDeletableModel<int>
    {
        public TestType()
        {
            this.TestResults = new HashSet<TestResult>();
        }

        public string TypeName { get; set; }

        public ICollection<TestResult> TestResults { get; set; }
    }
}

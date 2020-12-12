namespace BestPaws.Data.Models
{
    using BestPaws.Data.Common.Models;

    public class TestType : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}

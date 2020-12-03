namespace BestPaws.Data.Models
{
    using BestPaws.Data.Common.Models;

    public class Service : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}

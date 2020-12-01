namespace BestPaws.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BestPaws.Data.Common.Models;

    public class AnimalBreed : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}

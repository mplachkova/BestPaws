namespace BestPaws.Web.ViewModels.Services
{
    using System.ComponentModel.DataAnnotations;

    public class ServiceInputModel
    {
        [Required]
        [MinLength(10)]
        public string Name { get; set; }

        [Required]
        [MinLength(30)]
        public string Description { get; set; }
    }
}

namespace BestPaws.Web.ViewModels.PetCenter
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AddPetInputModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Range(0, 100)]
        public byte Age { get; set; }

        public string Gender { get; set; }

        [Required]
        public int AnimalTypeId { get; set; }

        public IEnumerable<SelectListItem> AnimalTypes { get; set; }
    }
}

namespace BestPaws.Web.ViewModels.PetCenter
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using BestPaws.Data.Models.Enums;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AddPetInputModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Range(0, 100)]
        public byte Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [DisplayName("AnimalType")]
        public int AnimalTypeId { get; set; }

        [Required]
        [DisplayName("AnimalBreed")]
        public int AnimalBreedId { get; set; }

        public IEnumerable<SelectListItem> AnimalTypes { get; set; }

        public IEnumerable<SelectListItem> AnimalBreeds { get; set; }
    }
}

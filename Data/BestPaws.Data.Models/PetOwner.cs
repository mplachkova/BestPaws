namespace BestPaws.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BestPaws.Data.Common.Models;

    public class PetOwner : BaseDeletableModel<string>
    {
        public PetOwner()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Address { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}

namespace BestPaws.Data.Models
{
    using System;
    using System.Collections.Generic;

    using BestPaws.Data.Common.Models;

    public class PetOwner : BaseDeletableModel<string>
    {
        public PetOwner()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Pets = new HashSet<Pet>();
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Pet> Pets { get; set; }
    }
}

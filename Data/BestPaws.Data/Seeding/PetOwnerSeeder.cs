namespace BestPaws.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BestPaws.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class PetOwnerSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.PetOwners.Any())
            {
                return;
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            await SeedOwnerAsync(userManager, "petowner@abv.bg");
        }

        private static async Task SeedOwnerAsync(UserManager<ApplicationUser> userManager, string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user != null)
            {
                if (user.PetOwner == null)
                {
                    var petOwner = new PetOwner
                    {
                        Id = user.Id,
                        FirstName = "Petar",
                        MiddleName = "Ivanov",
                        LastName = "Petrov",
                        EmailAddress = "petowner@abv.bg",
                        Address = "Sofia, 38 G. S. Rakovski str",
                        PhoneNumber = user.PhoneNumber,
                    };
                    user.PetOwner = petOwner;
                }
            }
        }
    }
}

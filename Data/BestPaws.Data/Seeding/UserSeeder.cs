namespace BestPaws.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using BestPaws.Common;
    using BestPaws.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            await SeedUserAsync(userManager, "doctor@abv.bg");
            await SeedUserAsync(userManager, "admin@bestpaws.com");
            await SeedUserAsync(userManager, "petowner@abv.bg");
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                var appUser = new ApplicationUser();
                appUser.UserName = username;
                appUser.Email = username;
                appUser.PhoneNumber = "0899999999";

                IdentityResult result = new IdentityResult();

                if (username == "doctor@abv.bg")
                {
                    result = userManager.CreateAsync(appUser, "123456").Result;
                    appUser.PhoneNumber = "0884112233";
                }
                else if (username == "admin@bestpaws.com")
                {
                    result = userManager.CreateAsync(appUser, "admin123").Result;
                    appUser.PhoneNumber = "0889123123";
                }
                else
                {
                    result = userManager.CreateAsync(appUser, "123456").Result;
                    appUser.PhoneNumber = "0888445566";
                }

                if (result.Succeeded)
                {
                    if (username == "admin@bestpaws.com")
                    {
                        await userManager.AddToRoleAsync(appUser, GlobalConstants.AdministratorRoleName);
                    }
                    else if (username == "doctor@abv.bg")
                    {
                        await userManager.AddToRoleAsync(appUser, GlobalConstants.DoctorRoleName);
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(appUser, GlobalConstants.PetOwnerRoleName);
                    }
                }
            }
        }
    }
}

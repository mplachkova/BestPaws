namespace BestPaws.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepositiry;
        private readonly IServiceProvider service;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepo, IServiceProvider serviceProvider)
        {
            this.userRepositiry = userRepo;
            this.service = serviceProvider;
        }

        public async Task CreateUserAsync(string input)
        {
            var userManager = this.service.GetRequiredService<UserManager<ApplicationUser>>();
            string password = this.GeneratePassword(input);
            var user = new ApplicationUser
            {
                UserName = input,
                Email = input,
            };

            IdentityResult result = new IdentityResult();

            result = userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Owner");
            }

            user.PetOwner = new PetOwner
            {
                Id = user.Id,
                EmailAddress = user.Email,
            };
            await this.userRepositiry.SaveChangesAsync();
        }

        private string GeneratePassword(string input)
        {
            int passwordLength = input.IndexOf("@");
            string passwordString = input.Substring(0, passwordLength) + "12345";
            return passwordString;
        }
    }
}

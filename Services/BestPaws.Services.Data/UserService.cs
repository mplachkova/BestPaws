namespace BestPaws.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using BestPaws.Common;
    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using BestPaws.Web.ViewModels.PetCenter;
    using BestPaws.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepositiry;
        private readonly IServiceProvider service;
        private readonly IDeletableEntityRepository<PetOwner> ownerRepository;

        public UserService(
            IDeletableEntityRepository<ApplicationUser> userRepo,
            IServiceProvider serviceProvider,
            IDeletableEntityRepository<PetOwner> ownerRepo)
        {
            this.userRepositiry = userRepo;
            this.service = serviceProvider;
            this.ownerRepository = ownerRepo;
        }

        public async Task CreatePetOwnerAsync(AddPetInputModel input)
        {
            var userManager = this.service.GetRequiredService<UserManager<ApplicationUser>>();
            string password = this.GeneratePassword(input.EmailAddress);
            var user = new ApplicationUser
            {
                UserName = input.EmailAddress,
                Email = input.EmailAddress,
            };

            IdentityResult result = new IdentityResult();

            result = userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, GlobalConstants.PetOwnerRoleName);
            }
            else
            {
                throw new ArgumentException(string.Format(Common.ErrorMessages.UserIsNotInDesiredRole, user, Common.GlobalConstants.PetOwnerRoleName));
            }

            user.PetOwner = new PetOwner
            {
                ApplicationUserId = user.Id,
                EmailAddress = user.Email,
            };

            await this.userRepositiry.SaveChangesAsync();
            await this.ownerRepository.SaveChangesAsync();
        }

        public async Task CreateAdminAsync(UserInputModel input)
        {
            var userManager = this.service.GetRequiredService<UserManager<ApplicationUser>>();
            var adminToBe = userManager.FindByEmailAsync(input.Email).Result;
            if (adminToBe == null)
            {
                string password = this.GeneratePassword(input.Email);
                adminToBe = new ApplicationUser
                {
                    UserName = input.Email,
                    Email = input.Email,
                };
                IdentityResult result = new IdentityResult();
                result = userManager.CreateAsync(adminToBe, password).Result;
                if (!result.Succeeded)
                {
                    throw new ArgumentException(string.Format(Common.ErrorMessages.UserIsNotInDesiredRole, adminToBe, GlobalConstants.AdministratorRoleName));
                }
            }

            await userManager.AddToRoleAsync(adminToBe, GlobalConstants.AdministratorRoleName);
            await this.userRepositiry.SaveChangesAsync();
        }

        private string GeneratePassword(string input)
        {
            int passwordLength = input.IndexOf("@");
            string passwordString = input.ToLower().Substring(0, passwordLength) + "12345";
            return passwordString;
        }
    }
}

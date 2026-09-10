using CRM.Model.ApplicationModels;
using CRM.Model.IdentityModels;
using CRM.Model.InputModels;
using CRM.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace CRM.Service
{
    public class AuthenticationService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager

        ) : IAuthenticationService
    {
        public Task<bool> ChangePasswordAsync(ApplicationUserRegisterInputModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ForgotPasswordAsync(ApplicationUserLoginInputModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<bool>> LoginAsync(ApplicationUserLoginInputModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {
                return new ResponseModel<bool>
                {
                    IsSucces = true,
                    Message = "Login succesful",
                    Data = true
                };

            }
            string errorMessage = result.IsLockedOut ? "User is locked out" :
                                  result.IsNotAllowed ? "Login is not allowed" :
                                  result.RequiresTwoFactor ? "Two-factor authentification is required" :
                                  "Invalid login attempt";
            return new ResponseModel<bool>
            {
                IsSucces = false,
                Message = errorMessage,
                Data = false
            };
        }

        public Task<bool> RefreshTokenAsync(ApplicationUserRegisterInputModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(ApplicationUserRegisterInputModel model)
        {
            ArgumentNullException.ThrowIfNull(model.Email);
            ArgumentNullException.ThrowIfNull(model.Password);

            var user = new ApplicationUser
            {
                UserName = model.FirstName + model.LastName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                RegistrationDate = DateTime.UtcNow
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => $"{e.Code}: {e.Description}"));
                throw new Exception($"Unable to create user. Errors: {errors}");
            }

            return true;
        }

        public Task<bool> ResetPasswordAsync(ApplicationUserRegisterInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}

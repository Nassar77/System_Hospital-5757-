using HospitalSystem.DAL.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace HospitalSystem.DAL.Repo.Abstraction
{
    public interface IAccountRepo
    {
        Task<Patient> GetPatientAsync(ClaimsPrincipal user);
      //  Task<Patient> GetCurrentUser();
        Task<IdentityResult> UpdatePatientAsync(Patient patient);
        Task<IdentityResult> UpdatePatientAsyn(Patient patient);
        Task<Patient> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(Patient user, string password);
        Task<IdentityResult> ChangePasswordAsync(Patient user, string oldPassword, string newPassword);
        Task RefreshSignInAsync(Patient user);
        Task<SignInResult> PasswordSignInAsync(Patient patient, string password, bool isPersistent, bool lockoutOnFailure);
        Task<IdentityResult> AccessFailedAsync(Patient patient);
        Task<bool> IsLockedOutAsync(Patient patient);
        Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
        Task<IdentityResult> CreateUserAsync(Patient user, string password);
        Task AddToRoleAsync(Patient user, string role);
        Task<SignInResult> PasswordSignInAsync(Patient user, string password);
        Task SignOutAsync();

    }
}

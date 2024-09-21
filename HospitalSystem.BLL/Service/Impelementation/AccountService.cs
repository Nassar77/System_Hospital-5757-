using AutoMapper;
using HospitalSystem.BLL.Helper;
using HospitalSystem.BLL.ModelVM.Account;
using HospitalSystem.BLL.ModelVM.Patient;
using HospitalSystem.BLL.Service.Abstraction;
using HospitalSystem.DAL.Entity;
using HospitalSystem.DAL.Repo.Abstraction;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalSystem.BLL.Service.Impelementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo patientRepo;
        private readonly IMapper mapper;

        public AccountService(IAccountRepo patientRepo, IMapper mapper)
        {
            this.patientRepo = patientRepo;
            this.mapper = mapper;
        }
        public async Task<PatientProfileVM> GetProfile(ClaimsPrincipal user)
        {
            var patient = await patientRepo.GetPatientAsync(user);
            if (patient == null) return null;

            var patientProfileVM = mapper.Map<PatientProfileVM>(patient);
            return patientProfileVM;
        }
        public async Task<IdentityResult> UpdatePatient(Patient patient)
        {
            return await patientRepo.UpdatePatientAsync(patient);
        }

        public async Task<EditePatientVM> GetPatientForEdit(ClaimsPrincipal user)
        {
            var patient = await patientRepo.GetPatientAsync(user);
            if (patient == null)
            {
                return null;
            }
            return mapper.Map<EditePatientVM>(patient);
        }
        public async Task<PatientVM> GetPatientForMoreInfo(ClaimsPrincipal user)
        {
            var patient = await patientRepo.GetPatientAsync(user);
            if (patient == null)
            {
                return null;
            }
            return mapper.Map<PatientVM>(patient);
        }
        public async Task<IdentityResult> UpdatePatient(ClaimsPrincipal user, EditePatientVM model)
        {
            var patient = await patientRepo.GetPatientAsync(user);

            if (patient == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }
            if (model.NewProfileImage != null && model.NewProfileImage.Length > 0)
            {
                var uploadedFileName = UploadImage.UploadFile("Profile", model.NewProfileImage);
                model.Image = uploadedFileName; 
            }
            // external not found the name used this for git it 
            patient.FullName = model.UserName;
            mapper.Map(model, patient);
            return await patientRepo.UpdatePatientAsync(patient);
        }

        public async Task<Patient> GetCurrentPatient(ClaimsPrincipal user)
        {
            return await patientRepo.GetPatientAsync(user);
        }

        public async Task<IdentityResult> DeletePatientAccount(ClaimsPrincipal user)
        {
            var patient = await patientRepo.GetPatientAsync(user);
            if (patient == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            patient.IsDeleted = true;
            var result = await patientRepo.UpdatePatientAsync(patient);

            if (result.Succeeded)
            {
                await patientRepo.SignOutAsync();
            }

            return result;
        }

        public async Task<IdentityResult> ChangePassword(ChangePasswordVM model)
        {
            var user = await patientRepo.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Email not found." });
            }

            var passwordCheck = await patientRepo.CheckPasswordAsync(user, model.OldPassword);
            if (!passwordCheck)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Current password is incorrect." });
            }

            var result = await patientRepo.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                await patientRepo.RefreshSignInAsync(user);
            }

            return result;
        }
        public async Task<LoginVM> GetLoginViewModelAsync()
        {
            var schemes = await patientRepo.GetExternalAuthenticationSchemesAsync();
            return new LoginVM
            {
                Schemes = schemes
            };
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(LoginVM loginVM)
        {
            var patient = await patientRepo.FindByEmailAsync(loginVM.Email);
            if (patient == null)
            {
                return Microsoft.AspNetCore.Identity.SignInResult.Failed;
            }

            var passwordCheck = await patientRepo.CheckPasswordAsync(patient, loginVM.Password);
            if (!passwordCheck)
            {
                await patientRepo.AccessFailedAsync(patient);
                return Microsoft.AspNetCore.Identity.SignInResult.Failed;
            }

            var result = await patientRepo.PasswordSignInAsync(patient, loginVM.Password, false, false);
            return result;
        }

        public async Task<bool> IsLockedOut(Patient patient)
        {
            return await patientRepo.IsLockedOutAsync(patient);
        }

        public async Task<IdentityResult> RegisterUserAsync(RegistrationVM registerVM)
        {
            // Check if user exists
            var existingUser = await patientRepo.FindByEmailAsync(registerVM.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Description = "Email address is already in use."
                });
            }

            // Handle file upload
            string uploadedFileName = null;
            if (registerVM.ProfileImage != null)
            {
                uploadedFileName = UploadImage.UploadFile("Profile", registerVM.ProfileImage);
            }

            // Use AutoMapper to map RegistrationVM to Patient
            var newUser = mapper.Map<Patient>(registerVM);
            newUser.Image = uploadedFileName;
            newUser.LockoutEnabled = true;

            var userCreated = await patientRepo.CreateUserAsync(newUser, registerVM.Password);

            if (userCreated.Succeeded)
            {
                await patientRepo.AddToRoleAsync(newUser, "Patient");
                await patientRepo.PasswordSignInAsync(newUser, registerVM.Password);
            }

            return userCreated;
        }
        public async Task Logout()
        {
            await patientRepo.SignOutAsync();
        }

    }

}


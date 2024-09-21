using System.ComponentModel.DataAnnotations;


namespace HospitalSystem.BLL.ModelVM.Account
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

using HospitalSystem.BLL.Helper;
using System.ComponentModel.DataAnnotations;


namespace HospitalSystem.BLL.ModelVM.Account
{
    public class ConfirmEmailLoginVM
    {
        [Required(ErrorMessage = "Email address is required")]
        [CustomEmailValidator(ErrorMessage = "Email address is not valid (custom)")]
        public string EmailAddress { get; set; }
    }

}

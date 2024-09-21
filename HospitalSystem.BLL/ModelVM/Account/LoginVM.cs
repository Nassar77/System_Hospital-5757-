using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;


namespace HospitalSystem.BLL.ModelVM.Account
{
    public class LoginVM
    {
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
        public IEnumerable<AuthenticationScheme>? Schemes { get; set; }
    }
}

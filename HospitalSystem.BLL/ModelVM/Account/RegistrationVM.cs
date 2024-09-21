using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace HospitalSystem.BLL.ModelVM.Account
{
	public class RegistrationVM
	{
		// in this page we used validation client side 
		[Required(ErrorMessage = "Full name is required")]
		[MinLength(3)]
		[MaxLength(25)]
		public string FullName { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(25)]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Email address is required")]
		[RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Invalid email address")]
		public string Email { get; set; }

		//[Required(ErrorMessage = "Password is required")]
		//[DataType(DataType.Password)]
		//[PasswordRules(ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
		[Required(ErrorMessage = "Password is required")]
		[StringLength(100, ErrorMessage = "Password must be at least {2} characters long.", MinimumLength = 8)]
		[DataType(DataType.Password)]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
		ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Confirm Password is required")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[Phone]
		[Display(Name = "Phone Number")]
		[MinLength(11)]
		public string PhoneNumber { get; set; }

		[Required]
		[RegularExpression(@"(Male|Female)", ErrorMessage = "Gender Must be Male or Female")]
		public string Gender { get; set; }

		[Required]
		[MinLength(14)]
		[MaxLength(14)]
		public string NationalId { get; set; }

		public IFormFile? ProfileImage { get; set; }
		public string? Name {  get; set; }


		public DateTime BirthDate { get; set; }
	}
}

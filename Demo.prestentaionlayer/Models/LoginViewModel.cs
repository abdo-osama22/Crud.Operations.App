using System.ComponentModel.DataAnnotations;

namespace Demo.prestentaionlayer.Models
{
	public class LoginViewModel
	{

		[Required(ErrorMessage = "Email Is Requird")]
		[EmailAddress(ErrorMessage = "Invalid Mail")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password Is Requires")]
		[DataType(DataType.Password)]
		public string Passowrd { get; set; }

		public bool RememberMe { get; set; }



	}
}

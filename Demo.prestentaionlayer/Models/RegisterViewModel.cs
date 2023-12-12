using System.ComponentModel.DataAnnotations;

namespace Demo.prestentaionlayer.Models
{
	public class RegisterViewModel
	{

		public string FName { get; set; }
		public string LName  { get; set; }

		 
		[Required(ErrorMessage ="Email Is Requird")]
		[EmailAddress(ErrorMessage ="Invalid Mail")]
		public string Email { get; set; }
		[Required(ErrorMessage ="Password Is Required")]
		[DataType(DataType.Password)]
		public string Passowrd { get; set; }

		[Required(ErrorMessage ="Confirm Password Is Requird")]
		[Compare("Passowrd", ErrorMessage ="Confirm password doesn't mathch the Password")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
		public bool IsAgree { get; set; }

	}
}

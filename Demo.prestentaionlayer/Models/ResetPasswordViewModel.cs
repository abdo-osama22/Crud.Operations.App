using System.ComponentModel.DataAnnotations;

namespace Demo.prestentaionlayer.Models
{
	public class ResetPasswordViewModel
	{
		[Required(ErrorMessage ="Password Is Required")]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }
		[Required(ErrorMessage ="Confirm Password Is Required")]
		[Compare("NewPassword", ErrorMessage ="Confrim message does not match with password")]
		[DataType(DataType.Password)]
		public string ConfirmPassword  { get; set; }

	}
}

using System.ComponentModel.DataAnnotations;

namespace Demo.prestentaionlayer.Models
{
	public class ForgetPasswordViewModel
	{
		[Required(ErrorMessage ="Email Is Requird")]
		[EmailAddress(ErrorMessage ="Invalid Email")]
		public string Email { get; set; }


	}
}

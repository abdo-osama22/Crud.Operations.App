using Demo.DataAccessLayer.Model;
using System.Net;
using System.Net.Mail;

namespace Demo.prestentaionlayer.Helpers
{
	public static class EmailSetting
	{
		public static void SendEmail(Email email) 
		{
			var client = new SmtpClient("smtp.gmail.com", 587);
			client.EnableSsl= true;
			client.UseDefaultCredentials=true;
			client.Credentials = new NetworkCredential("ahmedmahmod5698745@gmail.com", "ltptggtpzggqexfn");
			client.Send("ahmedmahmod5698745@gmail.com", email.To, email.Subject, email.Body);
		}
	}
}

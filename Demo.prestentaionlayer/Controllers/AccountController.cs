using Demo.DataAccessLayer.Model;
using Demo.prestentaionlayer.Helpers;
using Demo.prestentaionlayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.prestentaionlayer.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}


        #region Register
        public IActionResult Register() 
        {
            return View();
        
        }
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid) //server side validation 
			{
				var user = new ApplicationUser()
				{
					FName= model.FName,
					LName=model.LName,
					UserName = model.Email.Split('@')[0],
					Email = model.Email,
					IsAgree=model.IsAgree

				};

				var result = await _userManager.CreateAsync(user,model.Passowrd);

				if (result.Succeeded)
					return RedirectToAction(nameof(Login));
				foreach (var error in result.Errors)
					ModelState.AddModelError(string.Empty, error.Description);

				
			}
			return View(model);

		}

		#endregion

		#region Login
		public IActionResult Login() 
		{
			return View(); 
		
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				if (user is not null)
				{
					var flag = await _userManager.CheckPasswordAsync(user, model.Passowrd);
					if (flag)
					{
						await _signInManager.PasswordSignInAsync(user, model.Passowrd, model.RememberMe,false);
						return RedirectToAction("Index", "Home");
					}
					ModelState.AddModelError(string.Empty, "Invalid Password");
				}
				ModelState.AddModelError(string.Empty, "Email is not Exist"); 
			}

			return View(model);

		}


		#endregion
		#region SignOut
		public new async Task<IActionResult> SignOut() 
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(Login));
		
		}


		#endregion
		#region ForgetPassword

		public IActionResult ForgetPassword()
		{

			return View();
		
		}

		[HttpPost]
		public async Task<IActionResult> SendEmail(ForgetPasswordViewModel model)
		{

			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				if (user is not null)
				{
					var token = await _userManager.GeneratePasswordResetTokenAsync(user);
					var passwordresetlink = Url.Action("ResetPassword", "Account", new { emai = user.Email,token }, "https", Request.Scheme);

					var Email = new Email()
					{
						Subject = "Reset Password",
						To = user.Email,
						Body = passwordresetlink

					};
					EmailSetting.SendEmail(Email);
					return RedirectToAction(nameof(CheckYourInbox));
				}
				ModelState.AddModelError(string.Empty, "Email is Not Existed");
			}
			return View(model);

		}
		#endregion
		#region checkyouBox
		public IActionResult CheckYourInbox()
		{
			return View();

		}
		#endregion


		#region Reset Password
		public IActionResult ResetPassword(string email,string token) 
		{
			TempData["email"] = email;
			TempData["token"] = token;
			return View();
		
		}
		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model) 
		{

			if (ModelState.IsValid)
			{
				string email = TempData["email"] as string;
				string token = TempData["token"] as string;

				var user = await _userManager.FindByEmailAsync(email);
				var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

				if (result.Succeeded)
					return RedirectToAction(nameof(Login));
				foreach (var error in result.Errors)
					ModelState.AddModelError(string.Empty, error.Description);

			}
			return View(model);

		} 
		 
		#endregion
	}
}

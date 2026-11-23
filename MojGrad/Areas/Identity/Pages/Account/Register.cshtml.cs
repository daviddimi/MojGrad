using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojGrad.Models.Entities;

namespace MojGrad.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string? ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Внеси име и презиме.")]
            [StringLength(100, MinimumLength = 2, ErrorMessage = "Името мора да има од 2 до 100 знаци.")]
            [Display(Name = "Име и презиме")]
            public string FullName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Внеси е-пошта.")]
            [EmailAddress(ErrorMessage = "Невалидна е-пошта.")]
            [Display(Name = "Е-пошта")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Внеси лозинка.")]
            [StringLength(100, MinimumLength = 6, ErrorMessage = "Лозинката мора да има најмалку 6 знаци.")]
            [DataType(DataType.Password)]
            [Display(Name = "Лозинка")]
            public string Password { get; set; } = string.Empty;

            [DataType(DataType.Password)]
            [Display(Name = "Потврди лозинка")]
            [Compare("Password", ErrorMessage = "Лозинките не се совпаѓаат.")]
            public string ConfirmPassword { get; set; } = string.Empty;
        }

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
                return Page();

            var user = new ApplicationUser
            {
                UserName = Input.Email,
                Email = Input.Email,
                FullName = Input.FullName
            };

            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Citizen");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return Page();
        }
    }
}
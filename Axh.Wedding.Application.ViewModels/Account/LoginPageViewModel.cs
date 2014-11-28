namespace Axh.Wedding.Application.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    using Axh.Wedding.Application.ViewModels.Page;

    public class LoginPageViewModel : PageViewModelBase
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Stay logged in")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}

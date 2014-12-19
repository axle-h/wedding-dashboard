namespace Axh.Wedding.Application.ViewModels.Admin
{
    using System.ComponentModel.DataAnnotations;

    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Resources;

    public class AddUserPageViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resources), Name = "User_UserName")]
        public string UserName { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources), Name = "User_Password")]
        public string Password { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources), Name = "User_RsvpType")]
        public RsvpType RsvpType { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources), Name = "User_IsAdmin")]
        public bool IsAdmin { get; set; }
    }
}

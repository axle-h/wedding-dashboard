namespace Axh.Wedding.Application.ViewModels.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Axh.Wedding.Resources;

    public class UserViewModel
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources), Name = "User_UserName")]
        public string UserName { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources), Name = "User_IsAdmin")]
        public bool IsAdmin { get; set; }
        
    }
}

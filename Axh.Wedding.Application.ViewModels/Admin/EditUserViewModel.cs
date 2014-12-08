namespace Axh.Wedding.Application.ViewModels.Admin
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EditUserViewModel
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}

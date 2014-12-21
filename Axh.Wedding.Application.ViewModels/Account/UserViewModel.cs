namespace Axh.Wedding.Application.ViewModels.Account
{
    using System;

    public class UserViewModel
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        public RsvpType RsvpType { get; set; }
        
        public DateTime? RsvpDate { get; set; }
    }
}

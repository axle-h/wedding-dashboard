namespace Axh.Wedding.Application.ViewModels.Rsvp
{
    using System;

    public class GuestViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public bool IsAttending { get; set; }
    }
}

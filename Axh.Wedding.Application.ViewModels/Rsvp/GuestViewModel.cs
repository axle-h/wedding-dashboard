namespace Axh.Wedding.Application.ViewModels.Rsvp
{
    using System;

    using Axh.Wedding.Application.ViewModels.Page;

    public class GuestViewModel
    {
        [BindClientProperty("Id")]
        public Guid Id { get; set; }

        [BindClientProperty("FirstName")]
        public string FirstName { get; set; }

        [BindClientProperty("Surname")]
        public string Surname { get; set; }

        [BindClientProperty("IsAttending")]
        public bool IsAttending { get; set; }
    }
}

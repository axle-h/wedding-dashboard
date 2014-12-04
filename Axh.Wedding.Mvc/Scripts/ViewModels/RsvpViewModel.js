function RsvpViewModel(model) {
    var self = this;

    //self.FloatingFormViewModel = new FloatingFormViewModel();

    self.Guests = ko.observableArray();

    // Init.
    if (model.Guests != undefined) {
        $.each(model.Guests, function (id, guest) {
            self.Guests.push(new GuestViewModel(id, guest.Id, guest.FirstName, guest.Surname, guest.IsAttending));
        });
    }
};

function GuestViewModel(id, guestId, firstName, surname, isAttending) {
    var self = this;

    self.Id = id;
    self.GuestId = guestId;
    self.FirstName = ko.observable(firstName);
    self.Surname = ko.observable(surname);
    self.IsAttending = ko.observable(isAttending);

    self.HtmlId = "guests" + id;
    self.HtmlName = "Guests[" + id + "]";
};
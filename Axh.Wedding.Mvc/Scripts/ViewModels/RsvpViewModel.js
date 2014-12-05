function RsvpViewModel(model) {
    var self = this;

    self.Guests = ko.observableArray();
    self.addGuest = function() {
        self.Guests.push(new GuestViewModel(self.Guests().length));
    }
    self.removeGuest = function(guest) {
        self.Guests.remove(guest);
    }

    self.Stories = ko.observableArray();
    self.addStory = function () {
        self.Stories.push(new StoryViewModel(self.Stories().length));
    }
    self.removeStory = function (story) {
        self.Stories.remove(story);
    }

    // Init.
    if (model.Guests != undefined) {
        $.each(model.Guests, function (id, guest) {
            self.Guests.push(new GuestViewModel(id, guest.Id, guest.FirstName, guest.Surname, guest.IsAttending, guest.DietaryRequirements));
        });
    }

    if (model.Stories != undefined) {
        $.each(model.Stories, function (id, story) {
            self.Stories.push(new StoryViewModel(id, story.Id, story.StorySubject, story.StoryTitle, story.StoryBody));
        });
    }
};

function GuestViewModel(id, guestId, firstName, surname, isAttending, dietaryRequirements) {
    var self = this;

    self.Id = id;
    self.GuestId = guestId;
    self.CanBeRemoved = guestId == undefined;

    self.FirstName = ko.observable(firstName);
    self.Surname = ko.observable(surname);
    self.IsAttending = ko.observable(isAttending);
    self.DietaryRequirements = ko.observable(dietaryRequirements);

    self.HtmlId = "guests" + id;
    self.HtmlName = "Guests[" + id + "]";
};

function StoryViewModel(id, storyId, storySubject, storyTitle, storyBody) {
    var self = this;

    self.Id = id;
    self.StoryId = storyId;
    self.CanBeRemoved = storyId == undefined;

    self.StorySubject = ko.observable(storySubject);
    self.StoryTitle = ko.observable(storyTitle);
    self.StoryBody = ko.observable(storyBody);

    self.HtmlId = "stories" + id;
    self.HtmlName = "Stories[" + id + "]";
};
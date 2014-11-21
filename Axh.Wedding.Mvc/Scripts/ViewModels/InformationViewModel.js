function InformationViewModel(model) {
    var self = this;


    self.venueMap = new GoogleMapsViewModel('map-canvas-venue', model.VenueAddress);

    self.hotelMap = new GoogleMapsViewModel('map-canvas-hotel', model.HotelAddress);

};
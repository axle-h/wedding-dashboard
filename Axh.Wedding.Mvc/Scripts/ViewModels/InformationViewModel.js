function InformationViewModel(model) {
    var self = this;

    self.map = undefined;

    self.initialize = function () {
        var mapOptions = {
            scrollwheel: false,
            disableDefaultUI: true,
            draggable: true,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        self.map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

        var request = { query: model.GoogleMapsPlace };

        var service = new google.maps.places.PlacesService(self.map);
        service.textSearch(request, function (results, status) {
            if (status == google.maps.places.PlacesServiceStatus.OK) {
                var place = results[0];

                var marker = new google.maps.Marker({
                    map: self.map,
                    position: place.geometry.location
                });

                var width = 80;
                var photo = place.photos[0].getUrl({ 'maxWidth': width, 'maxHeight': width });

                var infoHtml = $('<div>', { 'class': 'content' })
                    .append($("<div>", { style: 'float: left; margin-right: 15px; width: ' + width + 'px; height: ' + width + 'px; border-radius: ' + width / 2 + 'px; ' + '-webkit-border-radius: ' + width / 2 + 'px; ' + '-moz-border-radius: ' + width / 2 + 'px; background-image: url(' + photo + '); ' }))
                    .append($("<h2>" + place.name + "</h2>", { 'style': 'float: left; clear: right;' }))
                    .append($("<div>", { 'style': 'float: left; ' }).append($("<p>" + place.formatted_address + "</p>"))
                    ).html();

                self.map.setZoom(15);

                var infowindow = new google.maps.InfoWindow({
                    content: infoHtml,
                    maxWidth: 300
                });
                infowindow.open(self.map, marker);
                google.maps.event.addListener(marker, 'click', function () {
                    infowindow.open(self.map, this);
                });
                self.map.setCenter({ lat: place.geometry.location.lat() + 0.003, lng: place.geometry.location.lng() });
            }
        });
    }

    google.maps.event.addDomListener(window, 'load', self.initialize);
};
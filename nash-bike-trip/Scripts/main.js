var map;
var directionsDisplay;
var directionsService;
var stepDisplay;
var markerArray = [];
var justATest ="where is my map?";
console.log(justATest);

function initialize() {
    // Instantiate a directions service.
    directionsService = new google.maps.DirectionsService();

    // Create a map and center it on Nashville.
    var nashville = new google.maps.LatLng(36.16393888886142, -86.76024444495332);
    var mapOptions = {
        zoom: 10,
        center: nashville
    }
    map = new google.maps.Map(document.getElementById("map"), mapOptions);

    // Create a renderer for directions and bind it to the map.
    var rendererOptions = {
        map: map
    }
    directionsDisplay = new google.maps.DirectionsRenderer(rendererOptions)

    // Instantiate an info window to hold step text.
    stepDisplay = new google.maps.InfoWindow();
}


function calcRoute() {

    // First, clear out any existing markerArray
    // from previous calculations.
    for (i = 0; i < markerArray.length; i++) {
        markerArray[i].setMap(null);
    }

    // Retrieve the start and end locations and create
    // a DirectionsRequest using WALKING directions.
    var start = document.getElementById("start").value;
    var end = document.getElementById("end").value;
    var request = {
        origin: start,
        destination: end,
        travelMode: google.maps.TravelMode.BICYCLING
    };

    // Route the directions and pass the response to a
    // function to create markers for each step.
    directionsService.route(request, function (response, status) {
        if (status == google.maps.DirectionsStatus.OK) {
            var warnings = document.getElementById("warnings_panel");

            // ---commenting out the below since i get an error on running
            // warnings.innerHTML = "" + response.routes[0].warnings + "";

            directionsDisplay.setDirections(response);
            showSteps(response);

            // ===Below is calling my bike-rack data===


            //map.data.loadGeoJson('/BikeData/bike-rack.geojson');
            map.data.loadGeoJson('https://data.nashville.gov/resource/yjju-hypq.geojson');
            //map.data.loadGeoJson('https://data.nashville.gov/resource/yjju-hypq.geojson?$$app-token=kWq8fKLZK1WORSOSKihs16jTU');

        }
    });
}

function showSteps(directionResult) {
    // For each step, place a marker, and add the text to the marker's
    // info window. Also attach the marker to an array so we
    // can keep track of it and remove it when calculating new
    // routes.
    var myRoute = directionResult.routes[0].legs[0];

    for (var i = 0; i < myRoute.steps.length; i++) {
        // var iconBase = 'https://maps.google.com/mapfiles/kml/shapes/';
        var marker = new google.maps.Marker({
            position: myRoute.steps[i].start_point,
            map: map
            // icon: iconBase + 'info-i_maps.png'
        });
        attachInstructionText(marker, myRoute.steps[i].instructions);
        markerArray[i] = marker;
    }
}

function attachInstructionText(marker, text) {
    google.maps.event.addListener(marker, 'click', function () {
        stepDisplay.setContent(text);
        stepDisplay.open(map, marker);
    });
}



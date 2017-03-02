var map;
var directionDisplay;
var directionsService;
var stepDisplay;
var start;
var end;
var request;
var xmlhttp;
var CONSTDistance = 1500;

function initialize() {
        var mapOptions = {
            center: new google.maps.LatLng(32.119801, 34.766235),
            zoom: 10,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.getElementById('map_canvas'),mapOptions);

        var rendererOptions = {
            map: map
        };
        directionsDisplay = new google.maps.DirectionsRenderer(rendererOptions);
        createAutoComplete();
}

function calcRoute() {

        request = {
            origin: start,
            destination: end,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        setDirectionsService(request)  
}


/*function showInstructions(directionResult) {

        var stepCounter;
        var myRoute = directionResult.routes[0].legs[0];
        var instruLable = getInstructDiv();
        document.getElementById("directionsDiv").style.height = "350px";
        document.getElementById("directionsDiv").style.overflow = "auto";
        instruLable.innerHTML += "<br/> <b style='font-size:medium'>הוראות נסיעה:</b> <br /><br/>";
        for (var i = 0; i < myRoute.steps.length; i++) {

            var myStep = myRoute.steps[i].instructions;
            stepCounter = i + 1;
            instruLable.innerHTML += "<p><b>" + stepCounter + ".</b> &nbsp" + myStep + "<p>&nbsp</p><hr style='border-style:solid; float:right; border-width:0.6px; width:300px; border-color:#DEE4E6 '/>" + myRoute.steps[i].distance.value + "m</p><p>&nbsp</p>";
        }
}*/

function SaveOfferPoints(directionResult) {
        // clear the array itself.
        xMarkerArray = [];
        yMarkerArray = [];
        var myRoute = directionResult.routes[0].legs[0];
        var counter = 0; //count the number of markers

        for (var i = 0; i < myRoute.steps.length; i++) {//run over all steps in route

            var myStep = myRoute.steps[i].path;
            var stepLength = myStep.length;
            var stepDistance = myRoute.steps[i].distance.value;

            if (stepDistance < CONSTDistance) {
                if (counter == 0 || (counter != 0 && xMarkerArray[counter - 1] != myRoute.steps[i].path[0].lng() && yMarkerArray[counter - 1] != myRoute.steps[i].path[0].lat())) {
                    xMarkerArray[counter] = myRoute.steps[i].path[0].lng();
                    yMarkerArray[counter] = myRoute.steps[i].path[0].lat();
                    counter++;
                }
            }
            else {
                var j = 0;
                var tmp1 = Math.floor((stepDistance / CONSTDistance)) + 1;  //The number of points required in the step
                var tmp2 = Math.floor(stepDistance / stepLength); //The average distance between each point
                var inc = Math.floor((Math.floor(stepDistance / tmp1)) / tmp2); //The space diffrence between the points
                while (j < stepLength) { // run over all points in a step
                    if (counter == 0 || (counter != 0 && xMarkerArray[counter - 1] != myRoute.steps[i].path[j].lng() && yMarkerArray[counter - 1] != myRoute.steps[i].path[j].lat())) {
                        xMarkerArray[counter] = myRoute.steps[i].path[j].lng();
                        yMarkerArray[counter] = myRoute.steps[i].path[j].lat();
                        counter++;
                    }
                    j = j + inc;
                }
            }
        }
        DisplayMarkers();
}

function SaveReqPoints(directionResult) {
    // clear the array itself.
    xMarkerArray = [];
    yMarkerArray = [];
    var myRoute = directionResult.routes[0].legs[0];
    var length = myRoute.steps.length;
    xMarkerArray[0] = myRoute.steps[0].path[0].lng();
    xMarkerArray[1] = myRoute.steps[length - 1].path[0].lng();
    yMarkerArray[0] = myRoute.steps[0].path[0].lat();
    yMarkerArray[1] = myRoute.steps[length - 1].path[0].lat();
}

/*
// clear the array itself.
        xMarkerArray = [];
        yMarkerArray = [];
        var myRoute = directionResult.routes[0].legs[0];
        var length = myRoute.steps.length;
        xMarkerArray[0] = myRoute.steps[0].path[0].lng();
        xMarkerArray[1] = myRoute.steps[length - 1].path[0].lng();
        yMarkerArray[0] = myRoute.steps[0].path[0].lat();
        yMarkerArray[1] = myRoute.steps[length - 1].path[0].lat();*/

function DisplayMarkers() {

        //display all matching users' markers
        if (typeof (Xmarkers) != "undefined") {
            for (var k = 0; k < Xmarkers.length; k++) {
                var latlng = new google.maps.LatLng(Ymarkers[k], Xmarkers[k]);
                var name = Names[k];
                var marker = new google.maps.Marker({
                    position: latlng,
                    title: name,
                    map: map
                });
            }
        }
}


function SetPoints(pageUrl) {
       
}

function SendUserDetails(id, name, picture, email, gender) {
    var xmlhttpDet;
    xmlhttpDet= CreateXmlHttp();
    var url = "Index.aspx?id="+id+"&name="+ name+"&picture="+picture + "&email="+ email +"&gender="+ gender;
    xmlhttpDet.open("POST",url,true);
    xmlhttpDet.send();
}

function originDestValidator(sender, args) {
    var el = document.getElementById(sender.controltovalidate).value;
    var posSign1 = el.indexOf("'");
    var posSign2 = el.indexOf("\"");
    if ((posSign1 == -1) && (posSign2 == -1) && (el != "הזן מיקום") && (el !="")) {
        args.IsValid = true;
        return;
    }
    else {
        args.IsValid = false;
        return;
    }
}

function noEnter() {
    return !(window.event && window.event.keyCode == 13);
}
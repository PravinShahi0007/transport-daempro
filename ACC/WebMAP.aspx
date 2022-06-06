<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMAP.aspx.cs" Inherits="ACC.WebMAP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<meta name="viewport" content="initial-scale=1.0" />
<meta charset="utf-8" />    
 <style type="text/css" >
      html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }
      #map {
        height: 100%;
      }
    </style>        
    <script src="https://maps.googleapis.com/maps/api/js?region=SA&language=ar&key=AIzaSyBiZRfD5bZzvAJccC4ZWge89JW6qdlBL9s&libraries=places&callback=initMap"  async defer></script>
    <script type="text/javascript">
        var map;
        var chicago = {lat: 41.850, lng: -87.650};
        var marker;
        var labels = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
        var labelIndex = 0;
         
        function initMap() {
            // var myLatLng = new google.maps.LatLng(24.7092, 46.672601);
            var mylat = parseFloat(getUrlVars()["lat"]);
            var mylng = parseFloat(getUrlVars()["lng"]);
            var pos = {
                lat: mylat,
                lng: mylng            
            }

            map = new google.maps.Map(document.getElementById('map'), {
                center: pos,  //myLatLng, //{ lat: -34.397, lng: 150.644 },
                zoom: 13,
                mapTypeId:google.maps.MapTypeId.ROADMAP,
                disableDefaultUI: true,
                zoomControl: true,  // zoomControlOptions 
                mapTypeControl: true,  // mapTypeControlOptions 
                scaleControl: true, // ScaleControlOptions 
                streetViewControl: true, // streetViewControlOptions 
                rotateControl: true,    // rotateControlOptions 
                fullscreenControl: true, // fullscreenControl 
                mapTypeControl: true, // mapTypeControlOptions
                mapTypeControlOptions: {
                                        style: google.maps.MapTypeControlStyle.DEFAULT,
                                        //google.maps.MapTypeControlStyle.DROPDOWN_MEN
                                        //google.maps.MapTypeControlStyle.HORIZONTAL_BAR
                                        // mapTypeIds: [google.maps.MapTypeId.ROADMAP,google.maps.MapTypeId.TERRAIN]
                                        //  position: google.maps.ControlPosition.TOP_CENTER
                                        }

            });

            var directionsService = new google.maps.DirectionsService;
            var directionsDisplay = new google.maps.DirectionsRenderer;
            directionsDisplay.setMap(map);

            var infoWindow = new google.maps.InfoWindow({map: map});
            infoWindow.setPosition(pos);
            infoWindow.setContent('هنا الموقع');
            map.setCenter(pos);
         //   addMarker2(location, map)

//            if (navigator.geolocation) {
//                navigator.geolocation.getCurrentPosition(function(position) {
//                var pos = {
//                    lat: position.coords.latitude,
//                    lng: position.coords.longitude
//                };

//                var infoWindow = new google.maps.InfoWindow({map: map});
//                infoWindow.setPosition(pos);
//                infoWindow.setContent('هنا الموقع');
//                map.setCenter(pos);
//                }, function() {
//                handleLocationError(true, infoWindow, map.getCenter());
//                });
//                } else {
//                    // Browser doesn't support Geolocation
//                handleLocationError(false, infoWindow, map.getCenter());
//            }

        }



        
        function handleLocationError(browserHasGeolocation, infoWindow, pos) {
          infoWindow.setPosition(pos);
          infoWindow.setContent(browserHasGeolocation ?
                                'Error: The Geolocation service failed.' :
                                'Error: Your browser doesn\'t support geolocation.');
        }

        function addMarker2(location, map) {
          // Add the marker at the clicked location, and add the next-available label
          // from the array of alphabetical characters.
           var image = 'images/Cars.png';
          var marker = new google.maps.Marker({
            position: location,
            //label: labels[labelIndex++ % labels.length],
            map: map,
            icon: image
          });
        }

        google.maps.event.addDomListener(window, 'load', initialize);


        function getUrlVars()
        {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for(var i = 0; i < hashes.length; i++)
            {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }
    </script>

</head>
<body dir="rtl">
    <div id="map" style="width:100%;height:100%"></div>        
    <form id="form10" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebGetMap.aspx.cs" Inherits="ACC.WebGetMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>تحديد الموقع على الخريطة بالضغط على يمين الماوس</title>
<meta name="viewport" content="initial-scale=1.0" />
<meta charset="utf-8" />    
 <style type="text/css" >
      html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }
      input
      {
          right:12px;
      }
      #map {
        height: 100%;
      }
      .controls {
        margin-top: 10px;
        border: 1px solid transparent;
        border-radius: 2px 0 0 2px;
        box-sizing: border-box;
        -moz-box-sizing: border-box;
        height: 32px;
        outline: none;
        box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
      }

      #pac-input 
      {
        background-color: #fff;
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
        margin-right:12px;
        padding: 0 11px 0 13px;
        text-overflow: ellipsis;
        width: 300px;
      }

      #pac-input:focus {
        border-color: #4d90fe;
      }

      .pac-container {
        font-family: Roboto;
      }

      #type-selector {
        color: #fff;
        background-color: #4d90fe;
        padding: 5px 11px 0px 11px;
      }

      #type-selector label {
        font-family: Arial;
        font-size: 13px;
        font-weight: 300;
      }
      #target {
        width: 345px;
      }      
    </style>        
    <script src="https://maps.googleapis.com/maps/api/js?region=SA&language=ar&key=AIzaSyBiZRfD5bZzvAJccC4ZWge89JW6qdlBL9s&libraries=places&callback=initAutocomplete"  async defer></script>
    <script type="text/javascript">
        var vPos = { lat: 24.689486, lng: 46.6723992 };
        function initAutocomplete() {
         
            var map = new google.maps.Map(document.getElementById('map'), {
                center: vPos,
                zoom: 13,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });

            var City = getParameterByName('myCity');
            if (City) {
                var geocoder = new google.maps.Geocoder();
                geocoder.geocode({ 'address': City + ',السعودية' }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        glat = results[0].geometry.location.lat();
                        glng = results[0].geometry.location.lng();
                        map.setCenter(new google.maps.LatLng(glat, glng));
                    } else {
                        // alert("Something got wrong " + status);
                        if (navigator.geolocation) {
                            navigator.geolocation.getCurrentPosition(function (position) {
                                vPos = {
                                    lat: position.coords.latitude,
                                    lng: position.coords.longitude
                                };
                                map.setCenter(vPos);
                            });
                        }
                    }
                });
            }
            else {
                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(function (position) {
                        vPos = {
                            lat: position.coords.latitude,
                            lng: position.coords.longitude
                        };
                        map.setCenter(vPos);
                    });
                }
            }

            var directionsService = new google.maps.DirectionsService;
            var directionsDisplay = new google.maps.DirectionsRenderer;
            directionsDisplay.setMap(map);
            
            // Create the search box and link it to the UI element.
            var input = document.getElementById('pac-input');
            map.controls[google.maps.ControlPosition.TOP_RIGHT].push(input);
            var searchBox = new google.maps.places.Autocomplete(input);
            searchBox.bindTo('bounds', map);

            function expandViewportToFitPlace(map, place) {
                if (place.geometry.viewport) {
                    map.fitBounds(place.geometry.viewport);
                } else {
                    map.setCenter(place.geometry.location);
                    map.setZoom(17);
                }
            };

            searchBox.addListener('place_changed', function () {
                var place = searchBox.getPlace();
                if (!place.geometry) {
                    window.alert("Autocomplete's returned place contains no geometry");
                    return;
                }
                expandViewportToFitPlace(map, place);
            });

            google.maps.event.addListener(map, "rightclick", function (event) {
                var lat = event.latLng.lat();
                var lng = event.latLng.lng();
                // populate yor box/field with lat, lng
                // alert("Lat=" + lat + "; Lng=" + lng);

                document.cookie = "Userlat=" + lat.toString() + ";";
                document.cookie = "Userlng=" + lng.toString() + ";";
                window.close();
            });


        }

        function getParameterByName(name, url) {
            if (!url) url = window.location.href;
            name = name.replace(/[\[\]]/g, "\\$&");
            var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, " "));
        }

    </script>

</head>
<body dir="rtl">
    <input id="pac-input" class="controls" type="text" placeholder="البحث عن موقع" />
    <div id="map"></div>        
    <form id="form10" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>

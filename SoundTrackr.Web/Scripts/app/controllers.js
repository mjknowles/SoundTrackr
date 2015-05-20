'use strict';

var soundTrackrControllers = angular.module('soundTrackrControllers', []);

/*phonecatControllers.controller('PhoneListCtrl', ['$scope', 'Phone',
  function ($scope, Phone) {
      $scope.phones = Phone.query();
      $scope.orderProp = 'age';
  }]);
  */

/*phonecatControllers.controller('PhoneDetailCtrl', ['$scope', '$routeParams', 'Phone',
  function ($scope, $routeParams, Phone) {
      $scope.phone = Phone.get({ phoneId: $routeParams.phoneId }, function (phone) {
          $scope.mainImageUrl = phone.images[0];
      });

      $scope.setImage = function (imageUrl) {
          $scope.mainImageUrl = imageUrl;
      }
  }]);
 */

soundTrackrControllers.controller('TracksCtrl', ['$scope', 'TrackAPI',
  function ($scope, TrackAPI) {
       /*Track.get(function (resp) {
          //$scope.geojson = [resp];
        });*/
      L.mapbox.accessToken = 'pk.eyJ1IjoibWprbm93bGVzMjMiLCJhIjoiQWJIb1d6NCJ9.3JZ_m3xjtutwqIMwSa-UXQ';

      var map = L.mapbox.map('map-four', 'mapbox.streets', {
          scrollWheelZoom: false
      }).setView([38.8929, -77.0252], 14);

      var myLayer = L.mapbox.featureLayer().addTo(map);
      //myLayer.setGeoJSON(geojson);

      $scope.tracks = TrackAPI.tracks.query();
  }]);
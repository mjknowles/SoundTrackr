'use strict';

var soundTrackrControllers = angular.module('SoundTrackrControllers', []);

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

soundTrackrControllers.controller('TracksCtrl', ['$scope', 'TrackAPI', 'UserTrackNames',
  function ($scope, TrackAPI, UserTrackNames) {
      $scope.trackNames = UserTrackNames;
      L.mapbox.accessToken = 'pk.eyJ1IjoibWprbm93bGVzMjMiLCJhIjoiQWJIb1d6NCJ9.3JZ_m3xjtutwqIMwSa-UXQ';

      var map = L.mapbox.map('map-four', 'mapbox.streets', {
          scrollWheelZoom: false
      });

      var myLayer = L.mapbox.featureLayer().addTo(map);

      $scope.getTrack = function getTrack(id) {
          TrackAPI.track.query({ trackId: id }, function (resp) {

              myLayer.setGeoJSON(resp.GeoJsonFeatures);
              map.setView(new Array(resp.GeoJsonFeatures.features[0].geometry.coordinates[1], resp.GeoJsonFeatures.features[0].geometry.coordinates[0]), 14);
          });
      };
  }]);
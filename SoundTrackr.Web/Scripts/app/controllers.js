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
soundTrackrControllers.controller('TracksCtrl', ['$scope', 'Track',
  function ($scope, Track) {
       /*Track.get(function (resp) {
          //$scope.geojson = [resp];
        });*/
      $scope.tracks = Track.query();
  }]);
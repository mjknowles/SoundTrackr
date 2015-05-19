'use strict';

(function (ng) {
    var tracks = [
      { title: 'Washington D.C.', id: 1 },
      { title: 'Nash to Bham', id: 2 },
      { title: 'Around the Block', id: 3 }
    ];

    ng.module('soundTrackrApp')
      .config(['$provide', function ($provide) {
          $provide.decorator('$httpBackend', ng.mock.e2e.$httpBackendDecorator);
      }]).run(['$httpBackend', function ($httpBackend) {
          $httpBackend.whenGET('/api/tracks/testuser').respond(tracks);
      }]);
})(angular);
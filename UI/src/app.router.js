import BookingsCtrl from './controllers/bookings'

export default function RouterConfig($routeProvider) {

  $routeProvider
    // .when('/', {
    //   templateUrl: 'partials/bookings.html'
    // })
    .when('/bookings', {
      templateUrl: 'partials/bookings.html',
      controller: BookingsCtrl,
      controllerAs: 'vm'
    })
    .otherwise({
      redirectTo: '/'
    })

}

import BookingsCtrl from './controllers/bookings'
import BookingSuccessCtrl from './controllers/booking-success'

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
    .when('/bookings/success', {
      templateUrl: 'partials/booking-success.html',
      controller: BookingSuccessCtrl,
      controllerAs: 'vm'
    })
    .otherwise({
      redirectTo: '/bookings'
    })

}

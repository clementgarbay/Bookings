import angular from 'angular'
import ngRoute from 'angular-route'
import uiSelect from 'ui-select'

import Routes from './app.router'
import BookingsService from './services/bookings'
import BookingsCtrl from './controllers/bookings'
import FlightsDirective from './directives/flights'
import HotelsDirective from './directives/hotels'

export default angular
  .module('BookingsApp', [
    ngRoute,
    uiSelect
  ])
  .config(Routes)
  .service('BookingsService', BookingsService)
  .controller('BookingsCtrl', BookingsCtrl)
  .directive('flights', FlightsDirective)
  .directive('hotels', HotelsDirective)
  .name

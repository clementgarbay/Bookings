import State from '../models/state'
import { bookingFromState } from '../models/booking'

export default function BookingsCtrl(BookingsService, $location) {
  const vm = this

  vm.state = new State().toJS()

  // Data from API
  vm.departureCities = []
  vm.arrivalCities = []
  vm.flights = []
  vm.hotels = []

  // Functions for the different booking steps
  vm.selectDepartureCity = selectDepartureCity
  vm.selectArrivalCity = selectArrivalCity
  vm.selectFlight = selectFlight
  vm.selectHotel = selectHotel

  vm.clearFlight = clearFlight
  vm.clearHotel = clearHotel
  vm.saveBooking = saveBooking

  init()

  function init() {
    BookingsService
      .getDepartureCities()
      .then(cities => vm.departureCities = cities)
  }

  function selectDepartureCity(cityName) {
    vm.state = new State({departureCity: cityName}).toJS()

    BookingsService
      .getArrivalCities(cityName)
      .then(cities => {
        vm.arrivalCities = cities
      })
  }

  function selectArrivalCity(cityName) {
    vm.state = new State({departureCity: vm.state.departureCity, arrivalCity: cityName}).toJS()

    BookingsService
      .getFlights(vm.state.departureCity, vm.state.arrivalCity)
      .then(flight => {
        vm.flights = flight
      })
  }

  function selectFlight(flight) {
    vm.state = new State({departureCity: vm.state.departureCity, arrivalCity: vm.state.arrivalCity, flight: flight}).toJS()

    BookingsService
      .getHotels(vm.state.arrivalCity)
      .then(hotels => {
        vm.hotels = hotels
      })
  }

  function selectHotel(hotel) {
    vm.state = new State({departureCity: vm.state.departureCity, arrivalCity: vm.state.arrivalCity, flight: vm.state.flight, hotel: hotel}).toJS()
  }

  function clearFlight() {
    vm.state = new State({departureCity: vm.state.departureCity, arrivalCity: vm.state.arrivalCity}).toJS()
    vm.flights = []
    vm.hotels = []
  }

  function clearHotel() {
    vm.state = new State({departureCity: vm.state.departureCity, arrivalCity: vm.state.arrivalCity, flight: vm.state.flight}).toJS()
  }

  function saveBooking() {
    BookingsService
      .save(bookingFromState(vm.state))
      .then(() => $location.path('bookings/success'), error => console.error(error))
  }

}

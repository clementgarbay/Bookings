import Booking from '../models/booking'

export default function BookingsCtrl(BookingsService) {
  const vm = this

  vm.booking = new Booking().toJS()
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
    vm.booking = new Booking({departureCity: cityName}).toJS()

    BookingsService
      .getArrivalCities(cityName)
      .then(cities => {
        vm.arrivalCities = cities
      })
  }

  function selectArrivalCity(cityName) {
    vm.booking = new Booking({departureCity: vm.booking.departureCity, arrivalCity: cityName}).toJS()

    BookingsService
      .getFlights(vm.booking.departureCity, vm.booking.arrivalCity)
      .then(flight => {
        vm.flight = flight
      })
  }

  function selectFlight(flight) {
    vm.booking = new Booking({departureCity: vm.booking.departureCity, arrivalCity: vm.booking.arrivalCity, flight: flight}).toJS()

    BookingsService
      .getHotels(vm.booking.arrivalCity)
      .then(hotels => {
        vm.hotels = hotels
      })
  }

  function selectHotel(hotel) {
    vm.booking = new Booking({departureCity: vm.booking.departureCity, arrivalCity: vm.booking.arrivalCity, flight: vm.booking.flight, hotel: hotel}).toJS()
  }

  function clearFlight() {
    vm.booking = new Booking({departureCity: vm.booking.departureCity, arrivalCity: vm.booking.arrivalCity}).toJS()
  }

  function clearHotel() {
    vm.booking = new Booking({departureCity: vm.booking.departureCity, arrivalCity: vm.booking.arrivalCity, flight: vm.booking.flight}).toJS()
  }

  function saveBooking() {
    BookingsService
      .save(vm.booking)
      .then(() => console.log('ok'))
  }

}

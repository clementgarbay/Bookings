import { Record } from 'immutable'

export default function BookingsCtrl(BookingsService) {
  const vm = this

  const Booking = Record({
    departureCity: null,
    arrivalCity: null,
    flight: null,
    hotel: null,
    nbTickets: 1,
    date: new Date().getTime()
  })

  vm.booking = new Booking()
  vm.departureCities = ['Nantes', 'Paris', 'Hong-Kong']
  vm.arrivalCities = ['Paris', 'New York', 'Berlin']
  vm.flights = []
  vm.hotels = []

  // Functions for update the booking
  vm.selectDepartureCity = selectDepartureCity
  vm.selectArrivalCity = selectArrivalCity
  vm.selectFlight = selectFlight
  vm.selectHotel = selectHotel
  vm.changeNbTickets = changeNbTickets
  vm.changeDate = changeDate

  vm.clearFlight = clearFlight
  vm.clearHotel = clearHotel
  vm.validateBooking = validateBooking

  init()

  function init() {
    BookingsService
      .getDepartureCities()
      .then(cities => vm.departureCities = cities)
  }

  function selectDepartureCity(cityName) {
    vm.booking = new Booking({departureCity: cityName})

    BookingsService
      .getArrivalCities(cityName)
      .then(cities => {
        vm.arrivalCities = cities
      })
  }

  function selectArrivalCity(cityName) {
    vm.booking = new Booking({departureCity: vm.booking.departureCity, arrivalCity: cityName})

    BookingsService
      .getFlights(vm.booking.departureCity, vm.booking.arrivalCity)
      .then(flight => {
        vm.flight = flight
      })
  }

  function selectFlight(flight) {
    vm.booking = new Booking({departureCity: vm.booking.departureCity, arrivalCity: vm.booking.arrivalCity, flight: flight})
  }

  function selectHotel(hotel) {
    vm.booking = new Booking({departureCity: vm.booking.departureCity, arrivalCity: vm.booking.arrivalCity, flight: vm.booking.flight, hotel: hotel})
  }

  // TODO: View can't update immutable record! Use these functions
  function changeNbTickets(nbTickets) {
    vm.booking = vm.booking.merge({nbTickets})
  }
  function changeDate(date) {
    vm.booking = vm.booking.merge({date})
  }

  function clearFlight() {
    vm.booking = new Booking({departureCity: vm.booking.departureCity, arrivalCity: vm.booking.arrivalCity})
  }

  function clearHotel() {
    vm.booking = new Booking({departureCity: vm.booking.departureCity, arrivalCity: vm.booking.arrivalCity, flight: vm.booking.flight})
  }

  function validateBooking() {
    // TODO
  }

}

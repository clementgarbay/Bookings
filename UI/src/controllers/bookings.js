import { Record } from 'immutable'

export default function BookingsCtrl(BookingsService) {
  const vm = this

  const Booking = Record({
    departureCity: null,
    arrivalCities: null,
    flight: null,
    hotel: null,
    nbTickets: 1
  })

  vm.booking = new Booking()
  vm.departureCities = ['Nantes', 'OK', 'Hong-Kong']
  vm.arrivalCities = []

  vm.selectDepartureCity = selectDepartureCity
  vm.selectArrivalCity = selectArrivalCity
  vm.selectFlight = selectFlight
  vm.selectHotel = selectHotel
  vm.clearFlight = clearFlight
  vm.clearHotel = clearHotel

  vm.flights = [
    {
      departureCity: 'Nantes',
      arrivalCity: 'Paris',
      airline: 'Air France',
      date: new Date().getTime()
    },
    {
      departureCity: 'Nantes',
      arrivalCity: 'Toronto',
      airline: 'Air France',
      date: new Date().getTime()
    }
  ]

  vm.hotels = [
    {
      name: 'Le fleur hotel',
      city: 'Paris',
      rating: '5/5'
    },
    {
      name: 'Le fleur hotel 2',
      city: 'Toronto',
      rating: '4/5'
    }
  ]

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

  function clearFlight() {
    vm.booking = vm.booking.remove('flight')
  }

  function clearHotel() {
    vm.booking = vm.booking.remove('hotel')
  }

}

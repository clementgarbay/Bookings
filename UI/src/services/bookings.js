export default function BookingsService($http) {

  this.getDepartureCities = () => {
    return $http.get('/api/flights')
        .then(res => res.data)
  }

  this.getArrivalCities = departureCity => {
    return $http.get(`/api/flights/${departureCity}`)
        .then(res => res.data)
  }

  this.getFlights = (departureCity, arrivalCity) => {
    return $http.get(`/api/flights/${departureCity}/${arrivalCity}`)
        .then(res => res.data)
  }

  this.getHotels = city => {
    return $http.get(`/api/hotels/${city}`)
        .then(res => res.data)
  }

}

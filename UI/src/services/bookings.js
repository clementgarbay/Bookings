export default function BookingsService($http) {

  const API_ENDPOINT = 'http://localhost:56576'

  this.getDepartureCities = () => {
    return $http.get(`${API_ENDPOINT}/api/flights`)
        .then(res => {
          console.log(res)
          return res.data
        })
  }

  this.getArrivalCities = departureCity => {
    return $http.get(`${API_ENDPOINT}/api/flights/${departureCity}`)
        .then(res => res.data)
  }

  this.getFlights = (departureCity, arrivalCity) => {
    return $http.get(`${API_ENDPOINT}/api/flights/${departureCity}/${arrivalCity}`)
        .then(res => res.data)
  }

  this.getHotels = city => {
    return $http.get(`${API_ENDPOINT}/api/hotels/${city}`)
        .then(res => res.data)
  }

}

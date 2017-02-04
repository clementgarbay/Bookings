import { Record } from 'immutable'

const Booking = Record({
  departure_city: null,
  departure_date: null,
  arrival_city: null,
  company: null,
  name: null,
  city: null,
  rating: null,
  first_name: null,
  last_name: null,
  email: null,
  rib: null
})

function bookingFromState(state) {
  return new Booking({
    departure_city: state.flight.departure_city,
    departure_date: state.flight.departure_date,
    arrival_city: state.flight.arrival_city,
    company: state.flight.company,
    name: state.hotel.name,
    city: state.hotel.city,
    rating: state.hotel.rating,
    first_name: state.user.firstName,
    last_name: state.user.lastName,
    email: state.user.email,
    rib: state.user.rib
  })
}

export { Booking, bookingFromState }

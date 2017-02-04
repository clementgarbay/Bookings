import { Record } from 'immutable'

export default Record({
  departureCity: null,
  arrivalCity: null,
  flight: null,
  nbTickets: 1,
  hotel: null,
  firstName: null,
  lastName: null,
  date: new Date().getTime()
})

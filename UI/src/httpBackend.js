export default function HttpBackend($httpBackend) {

  $httpBackend.whenRoute('GET', '/flights')
    .respond(() => {

      const flights = [
        {
          id: 1,
          name: 'Vol 1'
        },
        {
          id: 2,
          name: 'Vol 2'
        }
      ]

      return [200, {
        results: flights
      }]
    })

}

export default function FlightsDirective() {

  function FlightsCtrl() {
    const vm = this

    init()

    function init() {

    }
  }

  function link() {

  }

  return {
    bindToController: true,
    controller: FlightsCtrl,
    controllerAs: 'vm',
    templateUrl: 'directives/flights.html',
    link: link,
    restrict: 'E',
    scope: {
      flights: '=',
      onFlightClicked: '&'
    }
  }
}

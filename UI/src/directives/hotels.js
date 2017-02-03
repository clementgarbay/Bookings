export default function HotelsDirective() {

  function HotelsCtrl() {
    const vm = this

    init()

    function init() {

    }
  }

  function link() {

  }

  return {
    bindToController: true,
    controller: HotelsCtrl,
    controllerAs: 'vm',
    templateUrl: 'directives/hotels.html',
    link: link,
    restrict: 'E',
    scope: {
      hotels: '=',
      onHotelClicked: '&'
    }
  }
}

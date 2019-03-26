$(function () {

  function genCharArray(itemsCount) {
    var a = [];
    var i = 'A'.charCodeAt(0);
    var j = i + itemsCount;

    for (; i < j; ++i) {
      a.push(String.fromCharCode(i));
    }

    return a;
  }

  function BsBoardViewModel() {
    var self = this;

    self.header = ko.observableArray([]);

    self.board = ko.observableArray([]);

    self.hasWon = ko.observable(false);

    self.restartBoard = function () {
      self.restartAction();
      self.getBoardAction();
    }

    self.restartAction = function () {
      $.ajax({
        method: "POST",
        url: "/api/Battleship/Restart"
      });
    }

    self.getBoardAction = function () {
      $.ajax({
        method: "GET",
        url: "/api/Battleship/Board"
      }).done(function (data) {
        self.header(genCharArray(data.board.length));
        self.board(data.board);
        self.hasWon(data.hasWon);
      });
    }

    self.cellClick = function (x, y) {
      if (self.hasWon()) {
        self.restartAction();
        self.getBoardAction();
        return;
      }

      var fieldName = '' + this.header()[x] + (y + 1);
      $.ajax({
        method: "POST",
        url: "/api/Battleship/Strike?field=" + fieldName
      }).done(function () {
        self.getBoardAction();
      });
    }
  };

  var viewModel = new BsBoardViewModel();
  viewModel.getBoardAction();
  ko.applyBindings(viewModel);
});
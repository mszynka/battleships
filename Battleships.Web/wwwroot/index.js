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
        self.header(genCharArray(data.length));
        self.board(data);
      });
    }

    self.cellClick = function (x, y) {
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
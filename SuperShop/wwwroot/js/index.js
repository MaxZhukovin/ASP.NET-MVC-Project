"use strict";

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var Video = function Video(props) {
  return React.createElement(
    "video",
    { className: "video", autoPlay: true, loop: true },
    React.createElement("source", { src: props.videoUrl, type: props.type })
  );
};

var Message = function Message(props) {
  return React.createElement(
    "p",
    null,
    " ",
    props.message
  );
};

var Menu = function Menu(props) {

  return React.createElement(
    "ul",
    { className: "nav" },
    React.createElement(
      "li",
      null,
      "Home"
    ),
    React.createElement(
      "li",
      null,
      "Blog"
    ),
    React.createElement(
      "li",
      null,
      "About"
    ),
    React.createElement(
      "li",
      null,
      "Contact"
    )
  );
};

var Title = function Title(props) {
  return React.createElement(
    "h1",
    { className: "text" },
    props.title
  );
};

var App = function (_React$Component) {
  _inherits(App, _React$Component);

  function App(props) {
    _classCallCheck(this, App);

    var _this = _possibleConstructorReturn(this, _React$Component.call(this, props));

    _this.state = {
      videoUrl: "https://coverr.co/s3/mp4/Border-Collies.mp4",
      type: "video/mp4"
    };
    return _this;
  }

  App.prototype.render = function render() {
    return React.createElement(
      "div",
      null,
      React.createElement(Menu, null),
      React.createElement(Title, { title: "Adopt A Dog Today" }),
      React.createElement(Video, { className: "video", videoUrl: this.state.videoUrl, type: this.state.type }),
      React.createElement(
        "div",
        { className: "container" },
        React.createElement(
          "div",
          { className: "row", style: { marginTop: "60px" } },
          React.createElement(
            "div",
            { className: "col-md-6" },
            React.createElement(
              "p",
              { className: "text-center text-muted" },
              "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Officia quae earum inventore quo unde, tempora a laudantium assumenda quis minus praesentium rerum eaque itaque recusandae natus dicta iusto non aperiam."
            )
          ),
          React.createElement(
            "div",
            { className: "col-md-6" },
            React.createElement(
              "p",
              { className: "text-center text-muted" },
              "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Officia quae earum inventore quo unde, tempora a laudantium assumenda quis minus praesentium rerum eaque itaque recusandae natus dicta iusto non aperiam."
            )
          )
        )
      )
    );
  };

  return App;
}(React.Component);

ReactDOM.render(React.createElement(App, null), document.getElementById("app"));
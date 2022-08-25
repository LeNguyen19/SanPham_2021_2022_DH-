import React from "react";
import "./style.css";

function Level({ type = "none" }) {
  switch (type) {
    case "level35":
      return (
        <div className="level-container">
          <div className="level-bg">
            <div></div>
          </div>
          <div className="level level35">
            <div></div>
          </div>
        </div>
      );

    case "level45":
      return (
        <div className="level-container">
          <div className="level-bg">
            <div></div>
          </div>
          <div className="level level45">
            <div></div>
          </div>
        </div>
      );

    default:
      return (
        <div className="level-container">
          <div className="level-bg">
            <div></div>
          </div>
          <div className="level level60">
            <div></div>
          </div>
        </div>
      );
  }
}

export default Level;

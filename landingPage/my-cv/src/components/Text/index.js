import React from "react";
import "./style.css";

function Text({ type = "default", des, titleMain }) {
  switch (type) {
    case "description":
      return (
        <div className="description">
          <p>{des}</p>
        </div>
      );

    default:
      return (
        <div className="titleMain">
          <h1>{titleMain}</h1>
        </div>
      );
  }
}

export default Text;

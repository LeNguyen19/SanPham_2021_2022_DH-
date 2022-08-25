import React from "react";
import "./style.css";

function Image({ url, text }) {
  return (
    <div className="image-container">
      <img className="image" src={url} alt="img" />
      <div className="image-square"></div>
      <div className="image-border"></div>
      <div className="image-text">
        <p>{text}</p>
      </div>
      <div className="image-btn">
        <button>See details</button>
      </div>
    </div>
  );
}

export default Image;

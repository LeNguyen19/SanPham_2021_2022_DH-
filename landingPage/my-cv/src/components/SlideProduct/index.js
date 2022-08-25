import React from "react";
import "./style.css";

function Slide({ url, des }) {
  return (
    <div className="slide-container flex-col flex-jcc-aic">
      <div className="slide-img">
        <img src={url} alt="img" />
      </div>
      <h3>{des}</h3>
      <button className="slide-btn">Github</button>
    </div>
  );
}

export default Slide;

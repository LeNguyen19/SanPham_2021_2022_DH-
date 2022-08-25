import React from "react";
import Text from "../Text";
import "./style.css";
import meLeft from "../../assets/imgLeft.jpg";
import meRight from "../../assets/imgRight.jpg";
import meCenter from "../../assets/imgCenter.jpg";

function About(props) {
  return (
    <div id="about" className="container flex-jcc-aic">
      <div className="container-width flex-jcc-aic flex-col-rg40">
        <div className="about-title">
          <Text titleMain="About me" />
        </div>
        <div className="about-content">
          <div data-aos="fade-up-right">
            <div className="about-image">
              <div className="img">
                <img src={meLeft} alt="" />
              </div>
              <div className="aboout-text">
                <p>Keylee Nguyen</p>
                <h3>Student at university</h3>
              </div>
            </div>
          </div>

          <div data-aos="fade-up">
            <div className="about-image">
              <div className="img">
                <img src={meCenter} alt="" />
              </div>
              <div className="aboout-text">
                <p>Keylee Nguyen</p>
                <h3>Student at university</h3>
              </div>
            </div>
          </div>

          <div data-aos="fade-up-left">
            <div className="about-image">
              <div className="img">
                <img src={meRight} alt="" />
              </div>
              <div className="aboout-text">
                <p>Keylee Nguyen</p>
                <h3>Student at university</h3>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default About;

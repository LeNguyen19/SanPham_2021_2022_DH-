import React, { useEffect } from "react";
import "./style.css";
import bgHome from "../../assets/bgHome.jpg";
import avt from "../../assets/avt.png";
import Aos from "aos";
import "aos/dist/aos.css";


const dbIntro = {
  img_bgHome: bgHome,
  img_avt: avt,
  description:
    "I am a student at university, currently studying information technology at Ho Chi Minh City University of Food Industry. With the professional knowledge I have learned, I hope to find a suitable job to apply and promote my abilities. At the same time, I want to improve my professional qualifications and professional capacity through the company's professional working environment.",
};

function Introduce(props) {
  useEffect(() => {
    Aos.init({ duration: 2000 });
  }, []);
  return (
    <div className="container">
      <div className="flex-jcc-aic flex-col introduced">
        <div className="intro-background">
          <img data-aos="fade-up" src={dbIntro.img_bgHome} alt="bg" />
        </div>
        <div className="intro-avt">
          <img data-aos="fade-up" src={dbIntro.img_avt} alt="avt" />
        </div>
        <div className="intro-ring">
          <div data-aos="fade-up">
            <div></div>
          </div>
        </div>
        <div className="intro-title">
          <p data-aos="fade-up">{dbIntro.description}</p>
        </div>
      </div>
    </div>
  );
}

export default Introduce;

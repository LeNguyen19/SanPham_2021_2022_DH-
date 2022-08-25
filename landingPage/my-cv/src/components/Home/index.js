import React from "react";
import "./style.css";
import home from "../../assets/home.jpg";
import Navbar from "../../components/Navbar/index";
import Introduce from "../../components/Introduce/index";

const dbHome = {
  title: "HELLO!",
  description: "My name is Kaylee Nguyen I am a student at university",
};

function Home(props) {
  return (
    <div className="container home-container">
      <img className="home-bg" src={home} alt="bg" />
      <div className="home-navbar">
        <Navbar />
      </div>
      <div className="home-content">
        <h1>{dbHome.title}</h1>
        <p>{dbHome.description}</p>
      </div>
      <div className="home-title">
        <h1>{dbHome.title}</h1>
      </div>

      <div className="home-animation flex-row">
        <div className="triangle triangle-left"></div>
        <div className="triangle triangle-center"></div>
        <div className="triangle triangle-right"></div>
      </div>
      <Introduce />
    </div>
  );
}

export default Home;

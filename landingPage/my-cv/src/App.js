import React from "react";
import "./App.css";
import Home from "./components/Home/index";
import Skills from "./components/Skills";
import Product from "./components/Product";
import Activities from "./components/Activities";
import About from "./components/About";
import Contact from "./components/Contact";

function App(props) {
  return (
    <div className="app-container">
      <Home />
      <Skills/>
      <Product/>
      <Activities/>
      <About/>
      <Contact/>
    </div>
  );
}

export default App;

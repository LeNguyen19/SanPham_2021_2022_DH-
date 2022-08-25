import React from "react";
import "./style.css";

const dbLinks = [
  {
    url: "#home",
    title: "Home",
  },
  {
    url: "#skills",
    title: "Skills",
  },
  {
    url: "#product",
    title: "Product",
  },
  {
    url: "#activity",
    title: "Activities",
  },
  {
    url: "#about",
    title: "About",
  },
  {
    url: "#contact",
    title: "Contact",
  },
];

function Navbar(props) {
  return (
    <ul class="menu-list">
      {dbLinks.map(({ title, url }) => (
        <li key={title}>
          <a href={url}>{title}</a>
        </li>
      ))}
    </ul>
  );
}

export default Navbar;

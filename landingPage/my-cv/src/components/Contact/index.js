import React from "react";
import "./style.css";
import bg from "../../assets/bgContact.jpg";

function Contact(props) {
  return (
    <div id="contact" className="container flex-jcc-aic">
      <div className="contact-container">
        <img src={bg} alt="" />
        <div className="contact-content flex-jcc-aic flex-col">
          <h1>Contact</h1>
          <p>
            Address: 36/21A Tran Tan Street, Tan Son Nhi Ward, Tan Phu DisTrict,
            Ho Chi Minh City
          </p>
          <p>Email: lenguyendt2001@gmail.com</p>
          <p>Number phone: 0834200776</p>
        </div>
      </div>
    </div>
  );
}

export default Contact;

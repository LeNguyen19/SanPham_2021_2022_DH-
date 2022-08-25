import React from "react";
import "./style.css";
import check from "../../assets/check.jpg";
import Text from "../Text";

function SkillsType1({des}) {
  return (
    <div className="tyle1 flex-row">
      <div className="type1-icon">
        <img src={check} alt="check"/>
      </div>
      <div className="type1-text">
        <Text type="description" des={des} />
      </div>
    </div>
  );
}

export default SkillsType1;

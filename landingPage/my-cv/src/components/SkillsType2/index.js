import React from "react";
import "./style.css";
import Text from "../Text";
import Level from "../Level";

function SKillsType2({ des, level, type }) {
  return (
    <div className="flex-col type2">
      <div className="type2-text flex-row-jcsb">
        <Text type="description" des={des} />
        <Text type="description" des={level} />
      </div>
      <div className="type2-level">
        <Level type={type}/>
      </div>
    </div>
  );
}

export default SKillsType2;

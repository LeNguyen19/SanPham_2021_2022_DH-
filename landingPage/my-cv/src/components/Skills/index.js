import React, { useEffect } from "react";
import "./style.css";
import Aos from "aos";
import "aos/dist/aos.css";
import Text from "../../components/Text/index.js";
import SkillsType1 from "../../components/SkillsType1/index";
import SKillsType2 from "../SkillsType2";

const dbSkillsType1 = [
  {
    description: "Basic understanding of object-oriented programming.",
  },
  {
    description: "Basic understanding of SQL Server databases.",
  },
  {
    description: "Capable of teamwork.",
  },
  {
    description: "Have a high spirit of learning.",
  },
];

const dbSkillsType2 = [
  {
    des: "html/css",
    level: "60%",
    type: "none",
  },
  {
    des: "javascript",
    level: "35%",
    type: "level35",
  },
  {
    des: "bootstrap",
    level: "60%",
    type: "none",
  },
  {
    des: "c, c#, java",
    level: "45%",
    type: "level45",
  },
];

function Skills(props) {
  useEffect(() => {
    Aos.init({ duration: 2000 });
  }, []);
  return (
    <div id="skills" className="container flex-jcc-aic">
      <div className="flex-jcc-aic container-width flex-col-rg40">
        <div>
          <Text titleMain="My Professional Skills" />
        </div>
        <div className="skills-content">
          <div className="skills-left">
            <div data-aos="flip-right">
              {dbSkillsType1.map((skill1) => (
                <SkillsType1
                  key={skill1.description}
                  des={skill1.description}
                />
              ))}
            </div>
          </div>
          <div className="skills-left">
            <div data-aos="flip-left">
              {dbSkillsType2.map((skill2) => (
                <SKillsType2
                  key={skill2.des}
                  des={skill2.des}
                  level={skill2.level}
                  type={skill2.type}
                />
              ))}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Skills;

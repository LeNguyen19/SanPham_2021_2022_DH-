import React, { useEffect } from "react";
import "./style.css";
import Text from "../Text";
import travel from "../../assets/travel.jpg";
import music from "../../assets/music.jpeg";
import shopping from "../../assets/shopping.jpg";
import eat from "../../assets/eat.jpg";
import Image from "../Image";
import Aos from "aos";
import "aos/dist/aos.css";

const dbActivities = [
  {
    url: travel,
    text: "To travel",
  },
  {
    url: music,
    text: "Listen to music",
  },
  {
    url: shopping,
    text: "Go to shopping",
  },
  {
    url: eat,
    text: "Eat sweets",
  },
];

function Activities(props) {
  useEffect(() => {
    Aos.init({ duration: 2000 });
  }, []);
  return (
    <div id="activity" className="container flex-jcc-aic">
      <div className="container-width  flex-jcc-aic flex-col-rg40">
        <div className="activity-title">
          <Text titleMain="Some Of Interests" />
        </div>
        <div className="activity-content">
          {dbActivities.map((activity) => (
            <div data-aos="flip-down">
              <Image
                key={activity.text}
                url={activity.url}
                text={activity.text}
              />
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}

export default Activities;

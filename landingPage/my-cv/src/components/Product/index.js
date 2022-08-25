import React from "react";
import "./style.css";
import Text from "../Text";
import Slide from "../SlideProduct";
import app from "../../assets/app.jpg";
import web from "../../assets/website.jpg";
import software from "../../assets/software.jpg";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import RightArrow from "../../assets/next.svg";
import LeftArrow from "../../assets/prev.svg";

const dbProduct = [
  {
    img_app: app,
    des: "Car ticket booking",
  },
  {
    img_app: web,
    des: "Cosmetics selling website",
  },
  {
    img_app: software,
    des: "Garage management",
  },
  {
    img_app: web,
    des: "Cosmetics selling website",
  },
  {
    img_app: software,
    des: "Garage management",
  },
  {
    img_app: app,
    des: "Car ticket booking",
  },
  {
    img_app: software,
    des: "Garage management",
  },
  {
    img_app: app,
    des: "Car ticket booking",
  },
  {
    img_app: web,
    des: "Cosmetics selling website",
  },
];

function Product(props) {
  const SlickArrowLeft = ({ currentSlide, slideCount, style, ...props }) => (
    <img id="btnPrev" src={LeftArrow} alt="prevArrow" {...props} />
  );

  const SlickArrowRight = ({ currentSlide, slideCount, style, ...props }) => (
    <img id="btnNext" src={RightArrow} alt="nextArrow" {...props} />
  );
  const settings = {
    dots: false,
    infinite: true,
    speed: 500,
    slidesToShow: 3,
    slidesToScroll: 3,
    prevArrow: <SlickArrowLeft />,
    nextArrow: <SlickArrowRight />,
  };
  return (
    <div id="product" className="container flex-jcc-aic">
      <div className="container-width flex-jcc-aic flex-col-rg40">
        <div className="product-title">
          <Text titleMain="My Product Made" />
        </div>
        <div data-aos="zoom-in">
          <div className="product-content">
            <Slider {...settings}>
              {dbProduct.map((slide) => (
                <Slide key={slide.des} url={slide.img_app} des={slide.des} />
              ))}
            </Slider>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Product;

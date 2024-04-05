import React from "react";
import "./productCarousel.css";
import Carousel from "react-bootstrap/Carousel";

function ProductCarousel() {
  return (
    <React.Fragment>
      <Carousel fade interval={7000}>
        <Carousel.Item>
          <img
            className="d-block w-100 carousel-img"
            src="https://www.thepkglab.com/CF/Scales/GetFile?identifier=cdd3ba0d-8ac3-4f7e-abeb-d22a51b2fba8&contextId=4"
            alt="First slide"
          />
          <Carousel.Caption className="overlay-text-container">
            <div className="overlay-text">Featured Products</div>
          </Carousel.Caption>
          <Carousel.Caption>
            <h3>First Product</h3>
            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
          <img
            className="d-block w-100 carousel-img"
            src="https://beanrockcoffee.com/wp-content/uploads/2021/02/coffeebag_beanrock-coffee.jpg"
            alt="First slide"
          />
          <Carousel.Caption className="overlay-text-container">
            <div className="overlay-text">Featured Products</div>
          </Carousel.Caption>
          <Carousel.Caption>
            <h3>Second Product</h3>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
          <img
            className="d-block w-100 carousel-img"
            src="https://casemakes.com/wp-content/uploads/StumpTown.jpg"
            alt="First slide"
          />
          <Carousel.Caption className="overlay-text-container">
            <div className="overlay-text">Featured Products</div>
          </Carousel.Caption>
          <Carousel.Caption>
            <h3>Third Product</h3>
            <p>
              Praesent commodo cursus magna, vel scelerisque nisl consectetur.
            </p>
          </Carousel.Caption>
        </Carousel.Item>
      </Carousel>
    </React.Fragment>
  );
}

export default ProductCarousel;

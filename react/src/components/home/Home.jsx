import React from "react";
import ProductCarousel from "../productCarousel/ProductCarousel";
import { Container } from "react-bootstrap";

function Home() {
  return (
    <React.Fragment>
      <Container className="mt-3">
        <ProductCarousel />
      </Container>
    </React.Fragment>
  );
}

export default Home;

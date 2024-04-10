import React from "react";
import "./appFooter.css";
import { Container } from "react-bootstrap";

function AppFooter() {
  return (
    <React.Fragment>
      <Container className="d-flex justify-content-center">
        <footer>
          <hr className="footer-border" />
          <div className="row">
            <p className="col">Placeholder</p>
            <p className="col">Placeholder</p>
            <p className="col">Placeholder</p>
          </div>
        </footer>
      </Container>
      <Container className="d-flex justify-content-end">
        <footer>
          <p>Siplicity ©</p>
        </footer>
      </Container>
    </React.Fragment>
  );
}

export default AppFooter;

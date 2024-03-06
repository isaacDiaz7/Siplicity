import React from "react";
import { Navbar, Container, Nav, NavDropdown, Form } from "react-bootstrap";

function AppHeader() {
  return (
    <React.Fragment>
      <Navbar expand="lg" className="bg-primary">
        <Container>
          <Navbar.Brand href="#home">
            <img
              alt=""
              src="../src/assets/react.svg"
              width="30"
              height="30"
              className="d-inline-block align-top"
            />{" "}
            Siplicity
          </Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <NavDropdown title="Shop" id="shop-nav-dropdown">
                <NavDropdown.Item href="#action/3.1">Shop All</NavDropdown.Item>
                <NavDropdown.Item href="#action/3.2">Coffee</NavDropdown.Item>
                <NavDropdown.Item href="#action/3.3">
                  Matcha & Tea
                </NavDropdown.Item>
                <NavDropdown.Item href="#action/3.3">
                  Brew Tools
                </NavDropdown.Item>
                <NavDropdown.Item href="#action/3.3">Merch</NavDropdown.Item>
                <NavDropdown.Divider />
                <NavDropdown.Item href="#action/3.4">
                  Subscription
                </NavDropdown.Item>
              </NavDropdown>
              <Nav.Link href="#home">About Us</Nav.Link>
              <Nav.Link href="#link">Subscription</Nav.Link>
            </Nav>
            <Nav>
              <Nav.Link href="#deets">Location</Nav.Link>
              <Nav.Link href="#deets">Order Now</Nav.Link>
              <Nav.Link href="#deets">Account</Nav.Link>
              <Form className="d-flex">
                <Form.Control
                  type="search"
                  placeholder="Search"
                  className="me-2"
                  aria-label="Search"
                />
              </Form>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </React.Fragment>
  );
}

export default AppHeader;

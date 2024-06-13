import React, { useState } from "react";
import { Link } from "react-router-dom";
import { Row, Col, Card } from "react-bootstrap";
import { Formik, ErrorMessage, Field, Form } from "formik";
function LoginPage() {
  const [loginForm] = useState({
    email: "",
    password: "",
    rememberPassword: false,
  });

  const loginSubmit = (loginValues) => {
    console.log(loginValues);
  };

  return (
    <React.Fragment>
      <Row className="align-items-center justify-content-center g-0 min-vh-100 form-background">
        <Col lg={5} md={5} className="py-8 py-xl-0">
          <Card className="bg-primary">
            <Card.Body className="p-6">
              <Formik
                enableReinitialize={true}
                initialValues={loginForm}
                onSubmit={loginSubmit}
              >
                <Form>
                  <Row>
                    <Col lg={12} md={12} className="mb-3">
                      <div className="input-group mb-3">
                        <Field
                          type="text"
                          className="form-control"
                          placeholder="Email"
                          aria-label="Email"
                          aria-describedby="basic-addon1"
                          name="email"
                        />
                        <ErrorMessage
                          name="email"
                          component="div"
                          className="text-center error-message"
                        />
                      </div>
                    </Col>
                    <Col lg={12} md={12} className="mb-2">
                      <div className="input-group mb-2">
                        <Field
                          type="password"
                          className="form-control"
                          placeholder="Password"
                          name="password"
                        />
                        <ErrorMessage
                          name="password"
                          component="div"
                          className="text-center error-message"
                        />
                      </div>
                    </Col>
                    <Col lg={12} md={12} className="mb-3">
                      <div className="d-md-flex align-items-center">
                        <Field type="checkbox" name="rememberPassword" />{" "}
                        <label>Remember Password?</label>
                      </div>
                      <div className="d-md-flex justify-content-between align-items-center mt-2">
                        <Link to="/resetpassword" className="text-black">
                          Forgot your password?
                        </Link>
                      </div>
                    </Col>
                    <Col lg={12} md={12} className="mb-0 d-grid gap-2">
                      <button
                        id="loginRedirect"
                        type="submit"
                        className="btn mx-auto btn-secondary"
                      >
                        Login
                      </button>
                    </Col>
                  </Row>
                </Form>
              </Formik>
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </React.Fragment>
  );
}

export default LoginPage;

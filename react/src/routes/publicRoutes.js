import { lazy } from "react";

const Home = lazy(() => import("../components/home/Home"));
const LoginPage = lazy(() => import("../components/login/LoginPage"));

const routes = [
  {
    path: "/",
    name: "Home Page",
    exact: true,
    elements: Home,
    roles: [],
    isAnonymous: true,
  },
  {
    path: "/login",
    name: "Login Page",
    exact: true,
    elements: LoginPage,
    roles: [],
    isAnonymous: true,
  },
];

const errorRoutes = [
  {
    path: "*",
    name: "Error - 404",
    roles: [],
    exact: true,
    isAnonymous: true,
  },
];

var allRoutes = [...routes, errorRoutes];

export default allRoutes;

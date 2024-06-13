import "./App.css";
import Home from "./components/home/Home";
import AppHeader from "./components/AppHeader";
import AppFooter from "./components/footer/AppFooter";
import LoginPage from "./components/login/LoginPage";
import { useRoutes } from "react-router-dom";

function App() {
  const routes = [
    {
      path: "/",
      element: <Home />,
    },
    {
      path: "/login",
      element: <LoginPage />,
    },
  ];
  const routesElement = useRoutes(routes);
  return (
    <>
      <AppHeader />
      <div className="app">{routesElement}</div>
      <AppFooter />
    </>
  );
}

export default App;

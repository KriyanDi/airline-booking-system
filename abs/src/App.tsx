import React, { useState } from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Home from "./components/Home/Home";
import Navigation from "./components/Navigation/Navigation";
import LoginPage from "./components/User/Login/LoginPage";
import RegisterPage from "./components/User/Register/RegisterPage";

const App = () => {
  const [activeItem, setActiveItem] = useState("/");

  let hasLoggedUser = false;

  return (
    <Router>
      <div>
        {!hasLoggedUser ? <Navigation activeItem={activeItem} setActiveItem={setActiveItem} /> : null}
        <Switch>
          <Route path="/" exact component={Home} />
          <Route path="/login" exact component={LoginPage} />
          <Route path="/register" exact component={RegisterPage} />
        </Switch>
      </div>
    </Router>
  );
};

export default App;

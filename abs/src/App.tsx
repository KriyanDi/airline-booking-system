import React, { useEffect, useState } from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Home from "./components/Home/Home";
import Navigation from "./components/Navigation/Navigation";
import UserNavigation from "./components/Navigation/UserNavigation";
import LoginPage from "./components/User/Login/LoginPage";
import RegisterPage from "./components/User/Register/RegisterPage";
import { useAppDispatch, useAppSelector } from "./redux/hooks";
import { logout, selectLogged, selectUser } from "./redux/slices/user/userSlice";
import UserBook from "./components/User/User/UserBook";
import UserTickets from "./components/User/User/UserTickets";
import AdminNavigation from "./components/Navigation/AdminNavigation";
import ManageAirports from "./components/User/Admin/ManageAirports";
import ManageAirlines from "./components/User/Admin/ManageAirlines";
import ManageTickets from "./components/User/Admin/ManageTickets";
import ManageFlights from "./components/User/Admin/ManageFlights";

const App = () => {
  const dispatch = useAppDispatch();
  const selector = useAppSelector;

  const [activeItem, setActiveItem] = useState("home");

  let isLogged = false;
  let isAdmin = false;

  useEffect(() => {}, [dispatch]);

  isLogged = selector(selectLogged);
  isAdmin = selector(selectUser)?.isAdmin;

  let navigation = () => {
    if (isLogged) {
      return isAdmin ? (
        <AdminNavigation activeItem={activeItem} setActiveItem={setActiveItem} />
      ) : (
        <UserNavigation activeItem={activeItem} setActiveItem={setActiveItem} />
      );
    } else {
      return <Navigation activeItem={activeItem} setActiveItem={setActiveItem} />;
    }
  };

  return (
    <Router>
      <div>
        {navigation()}

        <Switch>
          <Route exact path="/" render={(props) => <Home activeItem={activeItem} setActiveItem={setActiveItem} />} />
          <Route
            exact
            path="/login"
            render={(props) => <LoginPage activeItem={activeItem} setActiveItem={setActiveItem} />}
          />
          <Route
            exact
            path="/register"
            render={(props) => <RegisterPage activeItem={activeItem} setActiveItem={setActiveItem} />}
          />
          <Route exact path="/book" component={UserBook} />
          <Route exact path="/tickets" component={UserTickets} />
          <Route exact path="/manageAirports" component={ManageAirports} />
          <Route exact path="/manageAirlines" component={ManageAirlines} />
          <Route exact path="/manageFlights" component={ManageFlights} />
          <Route exact path="/manageTickets" component={ManageTickets} />
        </Switch>
      </div>
    </Router>
  );
};

export default App;

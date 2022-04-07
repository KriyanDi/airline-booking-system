import React, { useState } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Segment } from "semantic-ui-react";
import Home from "./components/Home/Home";
import { NavigationBar } from "./components/Navigation/Utilities";
import SearchTickets from "./components/SearchTickets/SearchTickets";
// import LoginPage from "./components/Users/Login/LoginPage";
// import RegisterPage from "./components/Users/Register/RegisterPage";

const App = () => {
  const [activeItem, setActiveItem] = useState("home");
  const [airports, setAirports] = useState(null);

  let handleItemClick = (name: string) => setActiveItem(name);

  const [isLogged, setIsLogged] = useState<boolean>(false);
  const [isUser, setIsUser] = useState<boolean>(true);

  return (
    <div>
      {/* <BrowserRouter>
        {NavigationBar()}
        <Routes>
          {isLogged ? }
          <Route path="home" element={<Home props={handleItemClick} />} />

          <Route path="login" element={<LoginPage props={handleItemClick} />} />

          <Route
            path="registration"
            element={<RegisterPage props={handleItemClick} />}
          />

          <Route path="search">

          
        </Routes>
      </BrowserRouter> */}
      <Segment>
        <SearchTickets />
      </Segment>
    </div>
  );
};

export default App;

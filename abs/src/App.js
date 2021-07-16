import React from "react";
import ManageAirports from "./components/Airport/ManageAirports";
import ManageAirlines from "./components/Airline/ManageAirlines";
import ManageFlights from "./components/Flight/ManageFlights";

import { Provider } from "react-redux";
import store from "./store";

const App = () => {
  let header = "Airline Booking System ✈️";

  return (
    <Provider store={store}>
      <div className="ui form attached segment">
        <div className="ui segment">
          <h2 className="ui dividing header container">{header}</h2>
          <ManageAirports />
          <ManageAirlines />
          <ManageFlights />
        </div>
      </div>
    </Provider>
  );
};

export default App;

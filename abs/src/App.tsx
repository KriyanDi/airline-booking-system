import React from "react";
import ManageAirports from "./components/airports/ManageAirports";
import ManageAirlines from "./components/airlines/ManageAirlines";
import ManageFlights from "./components/flights/ManageFlights";
import store from "./_redux/store";
import { Provider } from "react-redux";

const App = () => {
  return (
    <Provider store={store}>
      <div className="ui form attached segment">
        <div className="ui segment">
          <h2 className="ui dividing header container">"Airline Booking System ✈️"</h2>
          <ManageAirports />
          <ManageAirlines />
          <ManageFlights />
        </div>
      </div>
    </Provider>
  );
};

export default App;

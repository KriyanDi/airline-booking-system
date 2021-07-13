import React from "react";
import AddAirline from "./components/AddAirline";
import AddAirport from "./components/AddAirport";
import AddFlight from "./components/AddFlight";

const App = () => {
  return (
    <div className="ui form attached segment">
      <div className="ui segment">
        <h2 class="ui dividing header container">Airline Booking System ✈️</h2>
        <AddAirport />
        <AddAirline />
        <AddFlight />
      </div>
    </div>
  );
};

export default App;

import React from "react";
import AddAirline from "./components/Airline/AddAirline";
import AddAirport from "./components/Airport/AddAirport";
import AddFlight from "./components/Flight/AddFlight";
import BookSeat from "./components/Flight/BookSeat";

import { Provider } from "react-redux";
import store from "./store";

const App = () => {
  return (
    <Provider store={store}>
      <div className="ui form attached segment">
        <div className="ui segment">
          <h2 className="ui dividing header container">
            Airline Booking System ✈️
          </h2>
          <AddAirport />
          <AddAirline />
          <AddFlight />
          <BookSeat />
        </div>
      </div>
    </Provider>
  );
};

export default App;

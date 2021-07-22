import React from "react";
import ManageAirports from "./components/airport/ManageAirports";

import { Provider } from "react-redux";
import store from "./store";

const App = () => {
  return (
    <Provider store={store}>
      <div className="ui form attached segment">
        <div className="ui segment">
          <h2 className="ui dividing header container">"Airline Booking System ✈️"</h2>
          <ManageAirports />
        </div>
      </div>
    </Provider>
  );
};

export default App;

import React from "react";
import AddFlight from "./AddFlight";
import AddSection from "./AddSection";
import BookSeat from "./BookSeat";
import SearchFlights from "./SearchFlights";

const ManageFlights = () => {
  return (
    <div className="ui form field segment container">
      <AddFlight />
      <AddSection />
      <BookSeat />
      <SearchFlights />
    </div>
  );
};

export default ManageFlights;

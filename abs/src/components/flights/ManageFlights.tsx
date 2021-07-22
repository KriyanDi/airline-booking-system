import React from "react";
import AddFlight from "./AddFlight";

const ManageFlights = () => {
  return (
    <div className="ui form field segment container">
      <AddFlight />
      <AddSection />
      {/* <AddSection
        flightIds={props.flightIds}
        getFlightById={props.getFlightById}
        createSection={props.createSection}
        deleteSection={props.deleteSection}
      />
      <BookSeat
        airlines={props.airlines}
        flightIds={props.flightIds}
        getFlightById={props.getFlightById}
        onBook={props.bookSeat}
        onUnbook={props.unbookSeat}
        findCols={props.getColsForFlightSection}
        findRows={props.getRowsForFlightSection}
      />
      <SearchFlight airports={props.airports} flights={props.flights} /> */}
    </div>
  );
};

export default ManageFlights;

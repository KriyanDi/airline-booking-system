import React from "react";
import AddFlight from "./AddFlight";
import AddSection from "./AddSection";
import BookSeat from "./BookSeat";
import { connect } from "react-redux";
import {
  selectAirports,
  selectAirlines,
  selectFlights,
  selectFlightIds,
  selectFlightByFlightId,
} from "../../utils/selectors";
import {
  createFlight,
  deleteFlight,
  createSection,
  deleteSection,
  bookSeat,
  unbookSeat,
} from "../../actions/flightsActions";
import SearchFlight from "./SearchFlight";

const ManageFlights = (props) => {
  return (
    <div className="ui form field segment container">
      <AddFlight
        airports={props.airports}
        airlines={props.airlines}
        flights={props.flights}
        createFlight={props.createFlight}
        deleteFlight={props.deleteFlight}
      />
      <AddSection
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
      />
      <SearchFlight airports={props.airports} flights={props.flights} />
    </div>
  );
};

const mapStateToProps = (state) => {
  const airports = selectAirports(state).map((el) => el.name);
  const airlines = selectAirlines(state).map((el) => el.name);
  const flights = selectFlights(state);
  const flightIds = selectFlightIds(state);

  const getFlightById = (flightId) =>
    flightId !== "" ? selectFlightByFlightId(state, flightId) : null;

  return { airports, airlines, flights, flightIds, getFlightById };
};

export default connect(mapStateToProps, {
  createFlight,
  deleteFlight,
  createSection,
  deleteSection,
  bookSeat,
  unbookSeat,
})(ManageFlights);

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
} from "../../utils/selectors";
import {
  createFlight,
  deleteFlight,
  createSection,
  deleteSection,
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
        createSection={props.createSection}
        deleteSection={props.deleteSection}
      />
      <BookSeat />
      <SearchFlight airports={props.airports} flights={props.flights} />
    </div>
  );
};

const mapStateToProps = (state) => {
  const airports = selectAirports(state).map((el) => el.name);
  const airlines = selectAirlines(state).map((el) => el.name);
  const flights = selectFlights(state);
  const flightIds = selectFlightIds(state);

  return { airports, airlines, flights, flightIds };
};

export default connect(mapStateToProps, {
  createFlight,
  deleteFlight,
  createSection,
  deleteSection,
})(ManageFlights);

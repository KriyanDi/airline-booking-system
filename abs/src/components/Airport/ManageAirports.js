import React from "react";
import { connect } from "react-redux";
import { selectAirports } from "../../utils/selectors";
import { createAirport, deleteAirport } from "../../actions/airportActions";
import { deleteFlightsOnDeletedAirport } from "../../actions/flightsActions";
import AddDeleteInputListControl from "../_common/AddDeleteInputListControl";

const ManageAirports = (props) => {
  const onAirportDeleteHandler = (el) => {
    props.deleteAirport(el.id);
    props.deleteFlightsOnDeletedAirport(el.name);
  };

  return (
    <AddDeleteInputListControl
      objectName="Airports"
      buttonName="Airport"
      onAdd={props.createAirport}
      onDelete={onAirportDeleteHandler}
      list={props.airports}
    />
  );
};

const mapStateToProps = (state) => {
  const airports = selectAirports(state);
  return { airports };
};

export default connect(mapStateToProps, {
  createAirport,
  deleteAirport,
  deleteFlightsOnDeletedAirport,
})(ManageAirports);

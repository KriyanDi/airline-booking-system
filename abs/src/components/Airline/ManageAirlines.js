import React from "react";
import { connect } from "react-redux";
import { selectAirlines } from "../../utils/selectors";
import { createAirline, deleteAirline } from "../../actions/airlineActions";
import { deleteFlightsOnDeletedAirline } from "../../actions/flightsActions";
import AddDeleteInputListControl from "../_common/AddDeleteInputListControl";

const ManageAirlines = (props) => {
  const onAirlineDeleteHandler = (el) => {
    props.deleteAirline(el.id);
    props.deleteFlightsOnDeletedAirline(el.name);
  };

  return (
    <AddDeleteInputListControl
      objectName="Airlines"
      buttonName="Airline"
      onAdd={props.createAirline}
      onDelete={onAirlineDeleteHandler}
      list={props.airlines}
    />
  );
};

const mapStateToProps = (state) => {
  const airlines = selectAirlines(state);
  return { airlines };
};

export default connect(mapStateToProps, {
  createAirline,
  deleteAirline,
  deleteFlightsOnDeletedAirline,
})(ManageAirlines);

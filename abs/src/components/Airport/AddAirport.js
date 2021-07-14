import React from "react";
import WrapAddFieldListViewer from "../_common/WrapAddFieldListViewer";
import { connect } from "react-redux";
import { selectAirportList } from "../../selectors";
import { createAirport, deleteAirport } from "../../actions/airportActions";

const AddAirport = (props) => {
  return (
    <WrapAddFieldListViewer
      objectName="Airport"
      buttonName="Airport"
      onAddClick={props.createAirport}
      onDeleteClick={props.deleteAirport}
      list={props.airports}
    />
  );
};

const mapStateToProps = (state) => {
  const airports = selectAirportList(state);
  return { airports };
};

export default connect(mapStateToProps, { createAirport, deleteAirport })(
  AddAirport
);

import React from "react";
import { connect } from "react-redux";
import { createAirport, deleteAirport } from "../actions/airportActions";
import { selectAirportList } from "../selectors";
import WrapAddFieldListViewer from "./common/WrapAddFieldListViewer";

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

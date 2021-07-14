import React from "react";
import WrapAddFieldListViewer from "../_common/WrapAddFieldListViewer";
import { connect } from "react-redux";
import { selectAirlineList } from "../../utils/selectors";
import { createAirline, deleteAirline } from "../../actions/airlineActions";

const AddAirline = (props) => {
  return (
    <WrapAddFieldListViewer
      objectName="Airline"
      buttonName="Airline"
      onAddClick={props.createAirline}
      onDeleteClick={props.deleteAirline}
      list={props.airlines}
    />
  );
};

const mapStateToProps = (state) => {
  const airlines = selectAirlineList(state);
  return { airlines };
};

export default connect(mapStateToProps, { createAirline, deleteAirline })(
  AddAirline
);

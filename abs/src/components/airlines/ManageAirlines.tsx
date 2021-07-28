import React from "react";
import ManageElement from "../_common/ManageElement";
import { connect } from "react-redux";
import { selectAirlines } from "../../utils/selectors";
import { IAirline } from "../../interfaces/airlineModel";
import { ManageAirlinesProps } from "../../interfaces/propsInterfaces";
import { createAirline, deleteAirline } from "../../_redux/slices/airlinesSlice";
import { deleteFlightsOnDeletedAirline } from "../../_redux/slices/flightsSlice";
import { RootState } from "../../_redux/store";

const ManageAirlines = (props: ManageAirlinesProps) => {
  const onAirlineDeleteHandler = (el: IAirline) => {
    props.deleteAirline({ id: el.id });
    props.deleteFlightsOnDeletedAirline({ name: el.name });
  };

  return (
    <ManageElement
      elementName="Airlines"
      list={props.airlineValues}
      onAdd={props.createAirline}
      onDelete={onAirlineDeleteHandler}
    />
  );
};

const mapStateToProps = (state: RootState) => {
  let airlineValues = selectAirlines(state);

  return { airlineValues };
};

export default connect(mapStateToProps, {
  createAirline,
  deleteAirline,
  deleteFlightsOnDeletedAirline,
})(ManageAirlines);

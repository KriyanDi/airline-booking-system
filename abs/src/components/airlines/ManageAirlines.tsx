import React from "react";
import { IAirline } from "../../interfaces/airlineModel";
import ManageElement from "../_common/ManageElement";

import { connect } from "react-redux";

import { selectAirlines } from "../../utils/selectors";
import { createAirline, deleteAirline } from "../../actions/airlineActions";
import { deleteFlightsOnDeletedAirline } from "../../actions/flightActions";

interface ManageAirlinesProps {
  airlines: any[];
  createAirline(name: string): void;
  deleteAirline(id: number): void;
  deleteFlightsOnDeletedAirline(name: string | undefined): void;
}

const ManageAirlines = (props: ManageAirlinesProps) => {
  const onAirlineDeleteHandler = (el: IAirline) => {
    props.deleteAirline(el.id);
    props.deleteFlightsOnDeletedAirline(el.name);
  };

  return (
    <ManageElement
      elementName="Airlines"
      list={props.airlines}
      onAdd={props.createAirline}
      onDelete={onAirlineDeleteHandler}
    />
  );
};

const mapStateToProps = (state: any) => {
  const airlines = selectAirlines(state);
  return { airlines };
};

export default connect(mapStateToProps, {
  createAirline,
  deleteAirline,
  deleteFlightsOnDeletedAirline,
})(ManageAirlines);

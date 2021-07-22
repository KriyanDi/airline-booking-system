import React from "react";
import { IAirport } from "../../interfaces/airportModel";
import ManageElement from "../_common/ManageElement";

import { connect } from "react-redux";

import { selectAirports } from "../../utils/selectors";
import { createAirport, deleteAirport } from "../../actions/airportActions";
import { deleteFlightsOnDeletedAirport } from "../../actions/flightActions";

interface ManageAirportsProps {
  airports: any[];
  createAirport(name: string): void;
  deleteAirport(id: number): void;
  deleteFlightsOnDeletedAirport(name: string | undefined): void;
}

const ManageAirports = (props: ManageAirportsProps) => {
  const onAirportDeleteHandler = (el: IAirport) => {
    props.deleteAirport(el.id);
    props.deleteFlightsOnDeletedAirport(el.name);
  };

  return (
    <ManageElement
      elementName="Airports"
      list={props.airports}
      onAdd={props.createAirport}
      onDelete={onAirportDeleteHandler}
    />
  );
};

const mapStateToProps = (state: any) => {
  const airports = selectAirports(state);
  return { airports };
};

export default connect(mapStateToProps, {
  createAirport,
  deleteAirport,
  deleteFlightsOnDeletedAirport,
})(ManageAirports);

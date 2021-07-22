import React from "react";
import { IAirport } from "../../interfaces/airportModel";
import ManageElement from "../_common/ManageElement";

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

export default ManageAirports;

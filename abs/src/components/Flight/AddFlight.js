import React, { useState } from "react";
import DropdownWithLabel from "../_common/DropdownWithLabel";
import TableViewer from "../_common/TableViewer";

const AddFlight = (props) => {
  const [airline, setAirline] = useState("");
  const [from, setFrom] = useState("");
  const [to, setTo] = useState("");

  return (
    <>
      <h4 className="ui dividing header">Manage Flights</h4>

      <div className="ui segment">
        <h5 className="ui dividing header">Add Flights</h5>

        <div className="three fields">
          <DropdownWithLabel
            label="Airline Name:"
            list={props.airlines}
            onChange={setAirline}
          />
          <DropdownWithLabel
            label="From Airport:"
            list={props.airports}
            onChange={setFrom}
          />
          <DropdownWithLabel
            label="Destination Airport:"
            list={props.airports}
            onChange={setTo}
          />
        </div>

        <button
          className="ui button"
          onClick={() => {
            if (airline !== "" && from !== "" && to !== "") {
              props.createFlight(airline, from, to);
            }
          }}
        >
          Add Flight
        </button>

        <div className="ui segment">
          <h4 className="ui dividing grey header">Flights</h4>
          <TableViewer
            content={props.flights.map((el) => ({
              ...el,
              seatClasses: el.seatClasses.length,
            }))}
            onDelete={(el) => props.deleteFlight(el.id)}
          />
        </div>
      </div>
    </>
  );
};

export default AddFlight;

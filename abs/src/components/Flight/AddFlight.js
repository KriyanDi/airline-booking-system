import React, { useState } from "react";
import DropdownWithLabel from "../_common/DropdownWithLabel";
import TableViewer from "../_common/TableViewer";
import { years, months, days } from "../../utils/constants";

const AddFlight = (props) => {
  const [airline, setAirline] = useState("");
  const [from, setFrom] = useState("");
  const [to, setTo] = useState("");

  const [day, setDay] = useState(null);
  const [month, setMonth] = useState(null);
  const [year, setYear] = useState(null);

  const [setDefault, setSetDefault] = useState(false);

  const resetValues = () => {
    setAirline("");
    setFrom("");
    setTo("");
    setDay(null);
    setMonth(null);
    setYear(null);
    setSetDefault(true);
  };

  let isAddFlightButtonEnabled =
    airline !== "" &&
    from !== "" &&
    to !== "" &&
    day !== null &&
    month !== null &&
    year !== null;

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
            setDefault={setDefault}
            setSetDefault={setSetDefault}
          />
          <DropdownWithLabel
            label="From Airport:"
            list={props.airports}
            onChange={setFrom}
            setDefault={setDefault}
            setSetDefault={setSetDefault}
          />
          <DropdownWithLabel
            label="Destination Airport:"
            list={props.airports}
            onChange={setTo}
            setDefault={setDefault}
            setSetDefault={setSetDefault}
          />
        </div>

        <div className="three fields">
          <DropdownWithLabel
            label="Day:"
            list={days()}
            onChange={setDay}
            setDefault={setDefault}
            setSetDefault={setSetDefault}
          />
          <DropdownWithLabel
            label="Month:"
            list={months()}
            onChange={setMonth}
            setDefault={setDefault}
            setSetDefault={setSetDefault}
          />
          <DropdownWithLabel
            label="Year:"
            list={years()}
            onChange={setYear}
            setDefault={setDefault}
            setSetDefault={setSetDefault}
          />
        </div>

        <button
          className={`ui ${isAddFlightButtonEnabled ? "" : "disabled"} button`}
          onClick={() => {
            props.createFlight(airline, from, to, new Date(year, month, day));
            resetValues();
          }}
        >
          Add Flight
        </button>

        <div className="ui segment">
          <h4 className="ui dividing grey header">Flights</h4>
          <TableViewer
            content={props.flights.map((el) => ({
              ...el,
              seatClasses: el.seatClasses.size,
            }))}
            onDelete={(el) => props.deleteFlight(el.id)}
          />
        </div>
      </div>
    </>
  );
};

export default AddFlight;

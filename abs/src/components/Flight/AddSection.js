import React, { useState } from "react";
import { SEATCLASS } from "../../utils/constants";
import DropdownWithLabel from "../_common/DropdownWithLabel";
import TableViewer from "../_common/TableViewer";
import Dropdown from "../_common/Dropdown";
import { rowsList, colsList } from "../../utils/constants";

const AddSection = (props) => {
  const [seatClass, setSeatClass] = useState("");
  const [rows, setRows] = useState(0);
  const [cols, setCols] = useState(0);
  const [flight, setFlight] = useState(null);

  const [setDefault, setSetDefault] = useState(false);

  const resetValues = () => {
    setSeatClass("");
    setRows(0);
    setCols(0);
    setFlight(null);
    setSetDefault(true);
  };

  const FlightIdChangeHandler = (flightId) => {
    setFlight(props.getFlightById(flightId));
  };

  const AddNewSectionHandler = () => {
    if (flight.seatClasses.get(seatClass) === undefined)
      props.createSection(flight.id, seatClass, rows, cols);
  };

  const header = "Add Section To Flight";

  let isAddSectionEnabled =
    flight !== null && rows !== 0 && cols !== 0 && seatClass !== "";

  return (
    <div className="ui segment">
      <h5 className="ui dividing header">{header}</h5>

      <div className="one field">
        <Dropdown
          label="Flight Id:"
          list={props.flightIds}
          onChange={FlightIdChangeHandler}
          setDefault={false}
          setSetDefault={setSetDefault}
        />
      </div>

      <div className="three fields">
        <DropdownWithLabel
          label="Section:"
          list={Object.keys(SEATCLASS)}
          onChange={setSeatClass}
          setDefault={setDefault}
          setSetDefault={setSetDefault}
        />
        <DropdownWithLabel
          label="Number of Rows:"
          list={rowsList()}
          onChange={setRows}
          setDefault={setDefault}
          setSetDefault={setSetDefault}
        />
        <DropdownWithLabel
          label="Number of Cols:"
          list={colsList()}
          onChange={setCols}
          setDefault={setDefault}
          setSetDefault={setSetDefault}
        />
      </div>

      <button
        className={`ui ${isAddSectionEnabled ? "" : "disabled"} button`}
        onClick={() => {
          AddNewSectionHandler(flight.id, seatClass, rows, cols);
          resetValues();
        }}
      >
        Add Section
      </button>

      <div className="ui segment">
        <h4 className="ui dividing grey header">
          All Seat Classes For Selected Flight
        </h4>
        <TableViewer
          content={
            flight
              ? Array.from(flight.seatClasses.values()).map((el) => {
                  let elCopy = { ...el };
                  delete elCopy.seats;
                  return elCopy;
                })
              : null
          }
          onDelete={(el) => props.deleteSection(flight.id, el.seatClass)}
        />
      </div>
    </div>
  );
};

export default AddSection;

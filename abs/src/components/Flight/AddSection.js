import React, { useState } from "react";
import { SEATCLASS } from "../../utils/constants";
import DropdownWithLabel from "../_common/DropdownWithLabel";
import TextInputWithLabel from "../_common/TextInputWithLabel";
import TableViewer from "../_common/TableViewer";
import Dropdown from "../_common/Dropdown";

const AddSection = (props) => {
  const [seatClass, setSeatClass] = useState("");
  const [rows, setRows] = useState(0);
  const [cols, setCols] = useState(0);
  const [flight, setFlight] = useState(null);

  const FlightIdChangeHandler = (value) => {
    setFlight(props.getFlightById(value));
  };

  const AddNewSectionHandler = () => {
    if (flight.seatClasses.get(seatClass) === undefined)
      props.createSection(flight.id, seatClass, rows, cols);
  };

  const header = "Add Section To Flight";

  return (
    <div className="ui segment">
      <h5 className="ui dividing header">{header}</h5>

      <div className="one field">
        <Dropdown
          label="Flight Id:"
          list={props.flightIds}
          onChange={FlightIdChangeHandler}
        />
      </div>

      <div className="three fields">
        <DropdownWithLabel
          label="Section:"
          list={Object.keys(SEATCLASS)}
          onChange={setSeatClass}
        />
        <TextInputWithLabel
          label={"Number of Rows:"}
          placeholder={"Rows ..."}
          onChange={setRows}
        />
        <TextInputWithLabel
          label={"Number of Cols:"}
          placeholder={"Cols ..."}
          onChange={setCols}
        />
      </div>

      <button
        className="ui button"
        onClick={
          flight !== null && rows !== 0 && cols !== 0 && seatClass !== ""
            ? () => AddNewSectionHandler()
            : () => {}
        }
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

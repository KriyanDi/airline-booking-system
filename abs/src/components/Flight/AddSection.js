import React, { useState, useEffect } from "react";
import { SEATCLASS } from "../../utils/constants";
import DropdownWithLabel from "../_common/DropdownWithLabel";
import TextInputWithLabel from "../_common/TextInputWithLabel";
import TableViewer from "../_common/TableViewer";
import { createSection, deleteSection } from "../../actions/flightsActions";
import { selectFlightByFlightId, selectFlightIds } from "../../utils/selectors";
import { connect } from "react-redux";
import Dropdown from "../_common/Dropdown";

const AddSection = (props) => {
  const [seatClass, setSeatClass] = useState("");
  const [rows, setRows] = useState("");
  const [cols, setCols] = useState("");
  const [flight, setFlight] = useState(null);

  const FlightIdChangeHandler = (value) => {
    setFlight(props.getFlightById(value));
  };

  return (
    <div className="ui segment">
      <h5 className="ui dividing header">Add Section</h5>
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
          flight !== null
            ? () => props.createSection(flight.id, seatClass, rows, cols)
            : () => {}
        }
      >
        Add Section to Flight
      </button>

      <div className="ui segment">
        <h4 className="ui dividing grey header">Section for selected fligh</h4>
        <TableViewer
          content={flight ? flight.seatClasses : null}
          onClick={deleteSection}
        />
      </div>
    </div>
  );
};

const mapStateToProps = (state) => {
  const getFlightById = (flightId) => selectFlightByFlightId(state, flightId);

  return { getFlightById };
};

export default connect(mapStateToProps, { createSection, deleteSection })(
  AddSection
);

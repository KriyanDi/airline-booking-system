import React from "react";
import DropdownWithLabel from "./common/DropdownWithLabel";
import TextInputWithLabel from "./common/TextInputWithLabel";

const AddFlight = (props) => {
  return (
    <div className="ui form field segment container">
      <h4 className="ui dividing header">Manage Flights</h4>
      <div className="three fields">
        <DropdownWithLabel label="Airline Name:" />
        <DropdownWithLabel label="From Airport:" />
        <DropdownWithLabel label="Destination Airport:" />
      </div>

      <div className="three fields">
        <DropdownWithLabel label="Section:" />
        <TextInputWithLabel
          label={"Number of Rows:"}
          placeholder={"Rows ..."}
        />
        <TextInputWithLabel
          label={"Number of Cols:"}
          placeholder={"Cols ..."}
        />
      </div>

      <div className="ui segment">
        <label>Current Sections:</label>
        {/* SectionsList */}
      </div>

      <button className="ui button">Add Flight</button>
    </div>
  );
};

export default AddFlight;

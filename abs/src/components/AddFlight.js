import React from "react";
import DropdownWithLabel from "./common/DropdownWithLabel";
import TextInputWithLabel from "./common/TextInputWithLabel";
import { connect } from "react-redux";
import { selectAirportList, selectAirlineList } from "../selectors";
import { SEATCLASS } from "../constants";

const AddFlight = (props) => {
  return (
    <div className="ui form field segment container">
      <h4 className="ui dividing header">Manage Flights</h4>
      <div className="three fields">
        <DropdownWithLabel label="Airline Name:" list={props.airlines} />
        <DropdownWithLabel label="From Airport:" list={props.airports} />
        <DropdownWithLabel label="Destination Airport:" list={props.airports} />
      </div>

      <div className="three fields">
        <DropdownWithLabel label="Section:" list={Object.keys(SEATCLASS)} />
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

const mapStateToProps = (state) => {
  const airports = selectAirportList(state).map((el) => el.name);
  const airlines = selectAirlineList(state).map((el) => el.name);

  return { airports, airlines };
};

export default connect(mapStateToProps)(AddFlight);

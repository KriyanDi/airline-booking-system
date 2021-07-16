import React, { useState } from "react";
import DropdownWithLabel from "../_common/DropdownWithLabel";
import TextInputWithLabel from "../_common/TextInputWithLabel";
import { connect } from "react-redux";
import { selectAirports, selectAirlines } from "../../utils/selectors";
import { SEATCLASS } from "../../utils/constants";
import ShowSeats from "./ShowSeats";

const BookSeat = (props) => {
  const header = "Manage Book Seats";

  const [airline, setAirline] = useState("");
  const [flightId, setFlightId] = useState({});
  const [seatClass, setSeatClass] = useState("");

  return (
    <div className="ui form field segment container">
      <h4 className="ui dividing header">{header}</h4>

      <div className="three fields">
        <DropdownWithLabel
          label="Airline Name:"
          list={props.airlines}
          onChange={setAirline}
        />
        <DropdownWithLabel
          label="Flight Number:"
          list={props.flighNumbers}
          onChange={setFlightId}
        />
        <DropdownWithLabel
          label="Seat class:"
          list={Object.keys(SEATCLASS)}
          onChange={setSeatClass}
        />
      </div>

      <div className="two fields">
        <TextInputWithLabel label="Row:" placeholder="Row ..." />
        <TextInputWithLabel label="Col:" placeholder="Col ..." />
      </div>

      <button className="ui button">Book Seat</button>

      <ShowSeats />
    </div>
  );
};

const mapStateToProps = (state) => {
  const airports = selectAirports(state).map((el) => el.name);
  const airlines = selectAirlines(state).map((el) => el.name);

  return { airports, airlines };
};

export default connect(mapStateToProps)(BookSeat);

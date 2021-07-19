import React, { useState } from "react";
import DropdownWithLabel from "../_common/DropdownWithLabel";
import TextInputWithLabel from "../_common/TextInputWithLabel";
import ShowSeats from "./ShowSeats";

const BookSeat = (props) => {
  const header = "Book Seat";

  const [airline, setAirline] = useState("");
  const [flightId, setFlightId] = useState({});
  const [seatClass, setSeatClass] = useState("");
  const [row, setRow] = useState(null);
  const [col, setCol] = useState(null);

  const extractSeatClasses = (flight) =>
    flight !== undefined ? Array.from(flight.seatClasses.keys()) : [];

  const extractSeats = (flightId) => {
    let flight = props.getFlightById(flightId);
    let section = flight ? flight.seatClasses.get(seatClass) : [];

    return Array.from(
      section ? (section.seats ? section.seats.values() : []) : []
    );
  };

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
          label="Flight Id:"
          list={props.flightIds}
          onChange={setFlightId}
        />
        <DropdownWithLabel
          label="Seat class:"
          list={extractSeatClasses(props.getFlightById(flightId))}
          onChange={setSeatClass}
        />
      </div>

      <div className="two fields">
        <TextInputWithLabel
          label="Row:"
          placeholder="Row ..."
          onChange={setRow}
        />
        <TextInputWithLabel
          label="Col:"
          placeholder="Col ..."
          onChange={setCol}
        />
      </div>

      <button
        className="ui button"
        onClick={
          airline !== "" &&
          flightId !== "" &&
          seatClass !== "" &&
          row !== null &&
          col !== null
            ? () => {
                let flight = props.getFlightById(flightId);
                return props.onBook(
                  flight.id,
                  seatClass,
                  Number(row) + Number(col)
                );
              }
            : () => {}
        }
      >
        Book Seat
      </button>

      <ShowSeats seats={extractSeats(flightId)} />
    </div>
  );
};

export default BookSeat;

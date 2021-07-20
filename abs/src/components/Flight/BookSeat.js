import React, { useState } from "react";
import DropdownWithLabel from "../_common/DropdownWithLabel";
import ShowSeats from "./ShowSeats";
import { colsListNumber, rowsList } from "../../utils/constants";

const BookSeat = (props) => {
  const header = "Book Seat";

  const [flightId, setFlightId] = useState({});
  const [seatClass, setSeatClass] = useState("");
  const [row, setRow] = useState(null);
  const [col, setCol] = useState(null);

  const [setDefault, setSetDefault] = useState(false);

  const extractSeatClasses = (flight) =>
    flight !== undefined ? Array.from(flight.seatClasses.keys()) : [];

  const extractSeats = (flightId) => {
    let flight = props.getFlightById(flightId);
    let section = flight ? flight.seatClasses.get(seatClass) : [];

    return Array.from(
      section ? (section.seats ? section.seats.values() : []) : []
    );
  };

  const resetValues = () => {
    setRow(null);
    setCol(null);
    setSetDefault(true);
  };

  let isBookSeatButtonEnabled =
    row !== null && col !== null && props.getFlightById(flightId) !== undefined;

  return (
    <div className="ui form field segment container">
      <h4 className="ui dividing header">{header}</h4>

      <div className="two fields">
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
        <DropdownWithLabel
          label="Number of Rows:"
          list={rowsList(props.findRows(flightId, seatClass))}
          onChange={setRow}
          setDefault={setDefault}
          setSetDefault={setSetDefault}
        />
        <DropdownWithLabel
          label="Number of Cols:"
          list={colsListNumber(props.findCols(flightId, seatClass))}
          onChange={setCol}
          setDefault={setDefault}
          setSetDefault={setSetDefault}
        />
      </div>

      <button
        className={`ui ${isBookSeatButtonEnabled ? "" : "disabled"} button`}
        onClick={() => {
          let flight = props.getFlightById(flightId);
          props.onBook(flight.id, seatClass, row + col);
          resetValues();
        }}
      >
        Book Seat
      </button>

      <ShowSeats seats={extractSeats(flightId)} />
    </div>
  );
};

export default BookSeat;

import React from "react";
import DropdownWithLabel from "./common/DropdownWithLabel";
import TextInputWithLabel from "./common/TextInputWithLabel";

const BookSeat = (props) => {
  return (
    <div className="ui form field segment container">
      <h4 class="ui dividing header">Manage Book Seats</h4>
      <div className="three fields">
        <DropdownWithLabel label="Airline Name:" />
        <DropdownWithLabel label="Flight Number:" />
        <DropdownWithLabel label="Seat class:" />
      </div>
      <div className="two fields">
        <TextInputWithLabel label="Row:" placeholder="Row ..." />
        <TextInputWithLabel label="Col:" placeholder="Col ..." />
      </div>

      <button className="ui button">Book Seat</button>
    </div>
  );
};

export default BookSeat;

import React, { useState } from "react";
import DropdownWithLabel from "../_common/DropdownWithLabel";
import TableViewer from "../_common/TableViewer";

const SearchFlight = (props) => {
  const [from, setFrom] = useState("");
  const [to, setTo] = useState("");

  const createSearchContent = (from, to, list) => {
    let searchedFlights =
      list && list.length
        ? list.filter(
            (el) =>
              (el.from === from || from === "") && (el.to === to || to === "")
          )
        : [];

    return searchedFlights.map((el) => ({
      ...el,
      seatClasses: el.seatClasses.size,
    }));
  };

  const header = "Search Flights";

  return (
    <div className="ui segment">
      <h4 className="ui dividing header">{header}</h4>
      <div className="two fields">
        <DropdownWithLabel
          label="From Airport"
          list={props.airports}
          onChange={setFrom}
        />

        <DropdownWithLabel
          label="To Airport"
          list={props.airports}
          onChange={setTo}
        />
      </div>

      <div className="ui segment">
        <h4 className="ui dividing grey header">Search Results:</h4>
        <TableViewer content={createSearchContent(from, to, props.flights)} />
      </div>
    </div>
  );
};

export default SearchFlight;

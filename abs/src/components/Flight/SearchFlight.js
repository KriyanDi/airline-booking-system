import React, { useState } from "react";
import DropdownWithLabel from "../_common/DropdownWithLabel";
import TableViewer from "../_common/TableViewer";

const SearchFlight = (props) => {
  const [from, setFrom] = useState("");
  const [to, setTo] = useState("");

  const createSearchContent = (list) =>
    list && list.lengt
      ? list.filter((el) => el.from === from && el.to === to)
      : [];

  const header = "Search Flights";

  return (
    <div className="ui segment">
      <h4 className="ui dividing header">{header}</h4>
      <div className="two fields">
        <DropdownWithLabel
          label="From Airport"
          list={props.aiports}
          onChange={setFrom}
        />

        <DropdownWithLabel
          label="To Airport"
          list={props.aiports}
          onChange={setTo}
        />
      </div>

      <div className="ui segment">
        <h4 className="ui dividing grey header">Search Results:</h4>
        <TableViewer content={createSearchContent(props.flight)} />
      </div>
    </div>
  );
};

export default SearchFlight;

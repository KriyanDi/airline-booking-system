import React, { useState } from "react";
import { IFlight } from "../../interfaces/flightModel";
import store from "../../store";
import Dropdown from "../_common/Dropdown";
import TableViewer from "../_common/TableViewer";
import { selectAirports, selectFlights } from "../../utils/selectors";
import { connect } from "react-redux";

interface SearchFlightProps {
  airports: any[];
  flights: any[];
}

const SearchFlight = (props: SearchFlightProps) => {
  const [from, setFrom] = useState<string>("");
  const [to, setTo] = useState<string>("");

  const createSearchContent = (from: string, to: string, list: IFlight[]) => {
    let searchedFlights = list && list.length ? list.filter((el) => (el.from === from || from === "") && (el.to === to || to === "")) : [];

    return searchedFlights.map((el) => ({
      ...el,
      seatClasses: el.seatClasses?.size,
    }));
  };

  const header = "Search Flights";

  return (
    <div className="ui segment">
      <h4 className="ui dividing header">{header}</h4>
      <div className="two fields">
        <Dropdown label="From Airport" list={props.airports} onChange={setFrom} />

        <Dropdown label="To Airport" list={props.airports} onChange={setTo} />
      </div>

      <div className="ui segment">
        <h4 className="ui dividing grey header">Search Results:</h4>
        <TableViewer content={createSearchContent(from, to, props.flights)} />
      </div>
    </div>
  );
};

const mapStateToProps = (state: typeof store) => {
  const airports = selectAirports(state).map((el: any) => el.name);
  const flights = selectFlights(state);

  return { airports, flights };
};

export default connect(mapStateToProps)(SearchFlight);

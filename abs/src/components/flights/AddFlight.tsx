import React, { useState } from "react";
import Dropdown from "../_common/Dropdown";
import TableViewer from "../_common/TableViewer";
import store from "../../_redux/store";
import { connect } from "react-redux";
import { createFlight, deleteFlight } from "../../_redux/actions/flightActions";
import { selectAirlines, selectAirports, selectFlights } from "../../utils/selectors";
import { years, months, days } from "../../utils/constants";

interface AddFlightProps {
  airports: any[];
  airlines: any[];
  flights: any[];
  createFlight(airline: string, from: string, to: string, date: Date): void;
  deleteFlight(id: number): void;
}

const AddFlight = (props: AddFlightProps) => {
  const [airline, setAirline] = useState<string>("");
  const [from, setFrom] = useState<string>("");
  const [to, setTo] = useState<string>("");

  const [day, setDay] = useState<number | null>(null);
  const [month, setMonth] = useState<number | null>(null);
  const [year, setYear] = useState<number | null>(null);

  const [defaultOption, setDefaultOption] = useState<boolean>(false);

  let isAddFlightButtonEnabled =
    airline !== "" && from !== "" && to !== "" && day !== null && month !== null && year !== null;

  const resetValues = () => {
    setAirline("");
    setFrom("");
    setTo("");
    setDay(null);
    setMonth(null);
    setYear(null);
    setDefaultOption(true);
  };

  return (
    <>
      {/* header */}
      <h4 className="ui dividing header">Manage Flights</h4>

      <div className="ui segment">
        <h5 className="ui dividing header">Add Flights</h5>

        {/* first three selectors */}
        <div className="three fields">
          <Dropdown
            label="Airline Name:"
            list={props.airlines}
            onChange={setAirline}
            defaultOption={defaultOption}
            setDefaultOption={setDefaultOption}
          />
          <Dropdown
            label="From Airport:"
            list={props.airports}
            onChange={setFrom}
            defaultOption={defaultOption}
            setDefaultOption={setDefaultOption}
          />
          <Dropdown
            label="Destination Airport:"
            list={props.airports}
            onChange={setTo}
            defaultOption={defaultOption}
            setDefaultOption={setDefaultOption}
          />
        </div>

        {/* second three selectors */}
        <div className="three fields">
          <Dropdown
            label="Day:"
            list={days()}
            onChange={setDay}
            defaultOption={defaultOption}
            setDefaultOption={setDefaultOption}
          />
          <Dropdown
            label="Month:"
            list={months()}
            onChange={setMonth}
            defaultOption={defaultOption}
            setDefaultOption={setDefaultOption}
          />
          <Dropdown
            label="Year:"
            list={years()}
            onChange={setYear}
            defaultOption={defaultOption}
            setDefaultOption={setDefaultOption}
          />
        </div>

        {/* button for adding a flight */}
        <button
          className={`ui ${isAddFlightButtonEnabled ? "" : "disabled"} button`}
          onClick={() => {
            props.createFlight(airline, from, to, new Date(year!, month!, day!));
            resetValues();
          }}
        >
          Add Flight
        </button>

        {/* table of all of the flights in the store */}
        <div className="ui segment">
          <h4 className="ui dividing grey header">Flights</h4>
          <TableViewer
            content={props.flights.map((el) => ({
              ...el,
              seatClasses: el.seatClasses.size,
            }))}
            onDelete={(el: { id: number }) => props.deleteFlight(el.id)}
          />
        </div>
      </div>
    </>
  );
};

const mapStateToProps = (state: typeof store) => {
  const airports = selectAirports(state).map((el: any) => el.name);
  const airlines = selectAirlines(state).map((el: any) => el.name);
  const flights = selectFlights(state);

  return { airports, airlines, flights };
};

export default connect(mapStateToProps, { createFlight, deleteFlight })(AddFlight);

import React, { useState } from "react";
import Dropdown from "../_common/Dropdown";
import TableViewer from "../_common/TableViewer";
import { RootState } from "../../_redux/store";
import { connect } from "react-redux";
import { createFlight, deleteFlight } from "../../_redux/slices/flightsSlice";
import { selectAirlines, selectAirports, selectFlights } from "../../utils/selectors";
import { years, months, days } from "../../utils/constants";
import { AddFlightProps, FlightInfo } from "../../interfaces/propsInterfaces";
import { IFlight } from "../../interfaces/flightModel";

const AddFlight = (props: AddFlightProps) => {
  const [flightInfo, setFlightInfo] = useState<FlightInfo>({
    airline: "",
    from: "",
    to: "",
    day: undefined,
    month: undefined,
    year: undefined,
  });

  const [defaultOption, setDefaultOption] = useState<boolean>(false);

  let isAddFlightButtonEnabled =
    flightInfo.airline !== "" &&
    flightInfo.from !== "" &&
    flightInfo.to !== "" &&
    flightInfo.day !== undefined &&
    flightInfo.month !== undefined &&
    flightInfo.year !== undefined;

  const resetValues = () => {
    setFlightInfo({ airline: "", from: "", to: "", day: undefined, month: undefined, year: undefined });
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
            onChange={(value) => setFlightInfo({ ...flightInfo, airline: value })}
            defaultOption={defaultOption}
            setDefaultOption={setDefaultOption}
          />
          <Dropdown
            label="From Airport:"
            list={props.airports}
            onChange={(value) => setFlightInfo({ ...flightInfo, from: value })}
            defaultOption={defaultOption}
            setDefaultOption={setDefaultOption}
          />
          <Dropdown
            label="Destination Airport:"
            list={props.airports}
            onChange={(value) => setFlightInfo({ ...flightInfo, to: value })}
            defaultOption={defaultOption}
            setDefaultOption={setDefaultOption}
          />
        </div>

        {/* second three selectors */}
        <div className="three fields">
          <Dropdown
            label="Day:"
            list={days()}
            onChange={(value) => setFlightInfo({ ...flightInfo, day: value })}
            defaultOption={defaultOption}
            setDefaultOption={setDefaultOption}
          />
          <Dropdown
            label="Month:"
            list={months()}
            onChange={(value) => setFlightInfo({ ...flightInfo, month: value })}
            defaultOption={defaultOption}
            setDefaultOption={setDefaultOption}
          />
          <Dropdown
            label="Year:"
            list={years()}
            onChange={(value) => setFlightInfo({ ...flightInfo, year: value })}
            defaultOption={defaultOption}
            setDefaultOption={setDefaultOption}
          />
        </div>

        {/* button for adding a flight */}
        <button
          className={`ui ${isAddFlightButtonEnabled ? "" : "disabled"} button`}
          onClick={() => {
            props.createFlight({
              airline: flightInfo.airline,
              from: flightInfo.from,
              to: flightInfo.to,
              date: new Date(flightInfo.year!, flightInfo.month!, flightInfo.day!),
            });
            resetValues();
          }}
        >
          Add Flight
        </button>

        {/* table of all of the flights in the store */}
        <div className="ui segment">
          <h4 className="ui dividing grey header">Flights</h4>
          <TableViewer
            content={props.flights.map((el) => {
              return {
                ...el,
                seatClasses: el.seatClasses.size,
                date: `${el.date.getDay()}/${el.date.getMonth()}/${el.date.getFullYear()}`,
              };
            })}
            onDelete={(el) => props.deleteFlight({ id: el.id })}
          />
        </div>
      </div>
    </>
  );
};

const mapStateToProps = (state: RootState) => {
  const airports: string[] = selectAirports(state).map((el: any) => el.name);
  const airlines: string[] = selectAirlines(state).map((el: any) => el.name);
  const flights: IFlight[] = selectFlights(state);

  return { airports, airlines, flights };
};

export default connect(mapStateToProps, { createFlight, deleteFlight })(AddFlight);

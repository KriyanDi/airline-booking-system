import React, { useState } from "react";
import { RootState } from "../../_redux/store";
import Dropdown from "../_common/Dropdown";
import { connect } from "react-redux";
import { IFlight, ISeatClasses } from "../../interfaces/flightModel";
import { selectFlightIds, selectAirports, selectFlightByFlightId } from "../../utils/selectors";
import { colsListChar, rowsList } from "../../utils/constants";
import ShowSeats from "./ShowSeats";
import { bookSeat } from "../../_redux/slices/flightsSlice";
import { BookSeatProps } from "../../interfaces/propsInterfaces";

const BookSeat = (props: BookSeatProps) => {
  const [flightId, setFlightId] = useState<string>("");
  const [seatClass, setSeatClass] = useState<string>("");
  const [row, setRow] = useState<number | null>(0);
  const [col, setCol] = useState<number | null>(0);

  const [defaultOption, setDefaultOption] = useState(false);

  const extractSeatClasses = (flight: IFlight) =>
    flight !== undefined && flight.seatClasses !== undefined ? Array.from(flight.seatClasses.keys()) : [];

  const extractSeats = (flightId: string) => {
    if (flightId !== "" && seatClass !== "") {
      let flight = props.getFlightById(flightId);
      if (flight) {
        let section: ISeatClasses = flight.seatClasses.get(seatClass);
        return section ? section.seats : undefined;
      }
    }

    return undefined;
  };

  const resetValues = () => {
    setRow(null);
    setCol(null);
    setDefaultOption(true);
  };

  let isBookSeatButtonEnabled = row !== null && col !== null && props.getFlightById(flightId) !== undefined;

  return (
    <div className="ui form field segment container">
      <h4 className="ui dividing header">"Book Seat"</h4>
      <div className="two fields">
        <Dropdown label="Flight Id:" list={props.flightIds} onChange={setFlightId} />
        <Dropdown
          label="Seat class:"
          list={extractSeatClasses(props.getFlightById(flightId))}
          onChange={setSeatClass}
        />
      </div>

      {console.log("VEFORE")}
      {console.log(seatClass)}

      <div className="two fields">
        <Dropdown
          label="Number of Rows:"
          list={rowsList(props.getRowsForFlightSection(flightId, seatClass))}
          onChange={setRow}
          defaultOption={defaultOption}
          setDefaultOption={setDefaultOption}
        />
        <Dropdown
          label="Number of Cols:"
          list={colsListChar(props.getColsForFlightSection(flightId, seatClass))}
          onChange={setCol}
          defaultOption={defaultOption}
          setDefaultOption={setDefaultOption}
        />
      </div>
      <button
        className={`ui ${isBookSeatButtonEnabled ? "" : "disabled"} button`}
        onClick={() => {
          let flight = props.getFlightById(flightId);

          console.log("AFTER");
          console.log(`${row}${col}`);
          console.log(seatClass);

          let tempSeatId = `${row}${col}`;

          props.bookSeat({ id: flight?.id, seatClass: seatClass, seatId: tempSeatId });
          resetValues();
        }}
      >
        Book Seat
      </button>

      {/* shows seats */}
      <ShowSeats title={seatClass} seats={extractSeats(flightId)} />
    </div>
  );
};

const mapStateToProps = (state: RootState) => {
  const airports: string[] = selectAirports(state).map((el: any) => el.name);
  const flightIds: string[] = selectFlightIds(state);
  const getFlightById = (flightId: string): IFlight | undefined =>
    flightId !== "" ? selectFlightByFlightId(state, flightId) : undefined;

  const getColsForFlightSection = (flightId: string, seatClass: string) => {
    let flight = selectFlightByFlightId(state, flightId);
    let section = flight ? flight.seatClasses.get(seatClass) : undefined;
    return section ? section.cols : 0;
  };

  const getRowsForFlightSection = (flightId: string, seatClass: string) => {
    let flight = selectFlightByFlightId(state, flightId);
    let section = flight ? flight.seatClasses.get(seatClass) : undefined;
    return section ? section.rows : 0;
  };

  return {
    airports,
    flightIds,
    getFlightById,
    getColsForFlightSection,
    getRowsForFlightSection,
  };
};

export default connect(mapStateToProps, { bookSeat })(BookSeat);

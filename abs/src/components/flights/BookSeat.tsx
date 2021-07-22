import React, { useState } from "react";
import store from "../../store";
import Dropdown from "../_common/Dropdown";
import { connect } from "react-redux";
import { IFlight, ISeatClasses, SEATCLASS } from "../../interfaces/flightModel";
import { selectFlightIds, selectAirports, selectFlightByFlightId } from "../../utils/selectors";
import { colsListNumber, rowsList } from "../../utils/constants";
import ShowSeats from "./ShowSeats";
import { bookSeat } from "../../actions/flightActions";

interface BookSeatProps {
  airports: string[];
  flightIds: string[];
  bookSeat(id: number, seatClass: string, seatId: string): void;
  getFlightById(flightId: string): any;
  getColsForFlightSection(flightId: string, seatClass: string): number;
  getRowsForFlightSection(flightId: string, seatClass: string): number;
}

const BookSeat = (props: BookSeatProps) => {
  const [flightId, setFlightId] = useState<string>("");
  const [seatClass, setSeatClass] = useState<string>("");
  const [row, setRow] = useState<number>(0);
  const [col, setCol] = useState<number>(0);

  const [defaultOption, setDefaultOption] = useState(false);

  const extractSeatClasses = (flight: IFlight) =>
    flight !== undefined && flight.seatClasses !== undefined ? Array.from(flight.seatClasses.keys()) : [];

  const extractSeats = (flightId: string): any => {
    let flight = props.getFlightById(flightId);
    if (flight) {
      let section: ISeatClasses | undefined = flight.seatClasses!.get(seatClass!);
      return section?.seats?.values();
    }

    return [];
  };

  const resetValues = () => {
    setRow(0);
    setCol(0);
    setDefaultOption(true);
  };

  let isBookSeatButtonEnabled = row !== null && col !== null && props.getFlightById(flightId) !== undefined;

  return (
    <div className="ui form field segment container">
      <h4 className="ui dividing header">"Book Seat"</h4>

      <div className="two fields">
        <Dropdown label="Flight Id:" list={props.flightIds} onChange={setFlightId} />
        <Dropdown label="Seat class:" list={extractSeatClasses(props.getFlightById(flightId))} onChange={setSeatClass} />
      </div>

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
          list={colsListNumber(props.getColsForFlightSection(flightId, seatClass))}
          onChange={setCol}
          defaultOption={defaultOption}
          setDefaultOption={setDefaultOption}
        />
      </div>

      <button
        className={`ui ${isBookSeatButtonEnabled ? "" : "disabled"} button`}
        onClick={() => {
          let flight = props.getFlightById(flightId);
          props.bookSeat(flight?.id, seatClass, `${row}${col}`);
          resetValues();
        }}
      >
        Book Seat
      </button>

      <ShowSeats seats={extractSeats(flightId)} />
    </div>
  );
};

const mapStateToProps = (state: typeof store) => {
  const airports = selectAirports(state).map((el: any) => el.name);
  const flightIds = selectFlightIds(state);
  const getFlightById = (flightId: string): IFlight | null => (flightId !== "" ? selectFlightByFlightId(state, flightId) : null);

  const getColsForFlightSection = (flightId: string, seatClass: SEATCLASS) => {
    let flight = selectFlightByFlightId(state, flightId);
    let section = flight ? flight.seatClasses.get(seatClass) : {};
    return section ? section.cols : 0;
  };

  const getRowsForFlightSection = (flightId: string, seatClass: SEATCLASS) => {
    let flight = selectFlightByFlightId(state, flightId);
    let section = flight ? flight.seatClasses.get(seatClass) : {};
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

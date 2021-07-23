import store from "../../_redux/store";
import Dropdown from "../_common/Dropdown";
import TableViewer from "../_common/TableViewer";
import { IFlight, SEATCLASS } from "../../interfaces/flightModel";
import { connect } from "react-redux";
import { createSection, deleteSection } from "../../_redux/actions/flightActions";
import { selectFlightIds, selectFlightByFlightId } from "../../utils/selectors";
import { colsList, rowsList } from "../../utils/constants";
import { useState } from "react";

interface AddSectionProps {
  flightIds: string[];
  getFlightById(flightId: string): IFlight;
  createSection(id: number, seatClass: SEATCLASS, rows: number, cols: number): void;
  deleteSection(id: number, seatClass: SEATCLASS): void;
}

const AddSection = (props: AddSectionProps) => {
  const [seatClass, setSeatClass] = useState<SEATCLASS | null>(null);
  const [rows, setRows] = useState<number>(0);
  const [cols, setCols] = useState<number>(0);
  const [flight, setFlight] = useState<IFlight | null>(null);

  const [defaultOption, setDefaultOption] = useState(false);

  const resetValues = () => {
    setSeatClass(null);
    setRows(0);
    setCols(0);
    setDefaultOption(true);
  };

  const FlightIdChangeHandler = (flightId: string) => {
    setFlight(props.getFlightById(flightId));
  };

  const AddNewSectionHandler = () => {
    if (
      flight !== null &&
      flight!.seatClasses !== undefined &&
      seatClass !== null &&
      flight.seatClasses.get(seatClass) === undefined
    ) {
      props.createSection(flight.id!, seatClass, rows, cols);
    }
  };

  const ExtractAvailableSeatClasses = () => {
    let seatClasses = ["FIRST", "BUSINESS", "ECONOMY"];

    let currentSeatClasses = flight ? Array.from(flight.seatClasses!.keys()) : [];

    let availableseatClasses = seatClasses.filter((el: any) => !currentSeatClasses.includes(el));

    return availableseatClasses;
  };

  let isAddSectionEnabled = flight !== null && rows !== 0 && cols !== 0 && seatClass !== null;

  return (
    <div className="ui segment">
      {/* header */}
      <h5 className="ui dividing header">"Add Section To Flight"</h5>

      <div className="one field">
        <Dropdown label="Flight Id:" list={props.flightIds} onChange={FlightIdChangeHandler} />
      </div>

      {/* first three selectors */}
      <div className="three fields">
        <Dropdown
          label="Section:"
          list={ExtractAvailableSeatClasses()}
          onChange={setSeatClass}
          defaultOption={defaultOption}
          setDefaultOption={setDefaultOption}
        />
        <Dropdown
          label="Number of Rows:"
          list={rowsList()}
          onChange={setRows}
          defaultOption={defaultOption}
          setDefaultOption={setDefaultOption}
        />
        <Dropdown
          label="Number of Cols:"
          list={colsList()}
          onChange={setCols}
          defaultOption={defaultOption}
          setDefaultOption={setDefaultOption}
        />
      </div>

      <button
        className={`ui ${isAddSectionEnabled ? "" : "disabled"} button`}
        onClick={() => {
          AddNewSectionHandler();
          resetValues();
        }}
      >
        Add Section
      </button>

      <div className="ui segment">
        <h4 className="ui dividing grey header">All Seat Classes For Selected Flight</h4>
        <TableViewer
          content={
            flight
              ? Array.from(flight.seatClasses!.values()).map((el) => {
                  let elCopy = { ...el };
                  delete elCopy.seats;
                  return elCopy;
                })
              : null
          }
          onDelete={(el: any) => props.deleteSection(flight!.id!, el.seatClass)}
        />
      </div>
    </div>
  );
};

const mapStateToProps = (state: typeof store) => {
  const flightIds = selectFlightIds(state);
  const getFlightById = (flightId: string) => (flightId !== "" ? selectFlightByFlightId(state, flightId) : null);

  return { flightIds, getFlightById };
};

export default connect(mapStateToProps, { createSection, deleteSection })(AddSection);

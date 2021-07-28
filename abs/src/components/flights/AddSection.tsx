import store, { RootState } from "../../_redux/store";
import Dropdown from "../_common/Dropdown";
import TableViewer from "../_common/TableViewer";
import { IFlight } from "../../interfaces/flightModel";
import { connect } from "react-redux";
import { createSection, deleteSection } from "../../_redux/slices/flightsSlice";
import { selectFlightIds, selectFlightByFlightId } from "../../utils/selectors";
import { colsList, rowsList } from "../../utils/constants";
import { useState } from "react";
import { AddSectionProps } from "../../interfaces/propsInterfaces";

const AddSection = (props: AddSectionProps) => {
  const [flight, setFlight] = useState<IFlight | undefined>(undefined);
  const [sectionInfo, setSectionInfo] = useState<{
    seatClass: string;
    rows: number;
    cols: number;
  }>({ seatClass: "", rows: 0, cols: 0 });

  const [defaultOption, setDefaultOption] = useState(false);

  const resetValues = () => {
    setSectionInfo({ seatClass: "", rows: 0, cols: 0 });
    setDefaultOption(true);
  };

  const FlightIdChangeHandler = (flightId: string) => {
    setFlight(props.getFlightById(flightId));
  };

  const AddNewSectionHandler = () => {
    props.createSection({
      id: flight!.id,
      seatClass: sectionInfo.seatClass,
      rows: sectionInfo.rows,
      cols: sectionInfo.cols,
    });
  };

  const ExtractAvailableSeatClasses = () => {
    let seatClasses = ["FIRST", "BUSINESS", "ECONOMY"];

    let currentSeatClasses = flight ? Array.from(flight.seatClasses!.keys()) : [];

    let availableseatClasses = seatClasses.filter((el: any) => !currentSeatClasses.includes(el));

    return availableseatClasses;
  };

  let isAddSectionEnabled =
    flight !== undefined && sectionInfo.rows !== 0 && sectionInfo.cols !== 0 && sectionInfo.seatClass !== "";

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
          onChange={(value) => setSectionInfo({ ...sectionInfo, seatClass: value })}
          defaultOption={defaultOption}
          setDefaultOption={setDefaultOption}
        />
        <Dropdown
          label="Number of Rows:"
          list={rowsList()}
          onChange={(value) => setSectionInfo({ ...sectionInfo, rows: value })}
          defaultOption={defaultOption}
          setDefaultOption={setDefaultOption}
        />
        <Dropdown
          label="Number of Cols:"
          list={colsList()}
          onChange={(value) => setSectionInfo({ ...sectionInfo, cols: value })}
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
          onDelete={(el) => props.deleteSection({ id: flight!.id!, seatClass: el.seatClass })}
        />
      </div>
    </div>
  );
};

const mapStateToProps = (state: RootState) => {
  const flightIds: string[] = selectFlightIds(state);
  const getFlightById = (flightId: string): IFlight | undefined =>
    flightId !== "" ? selectFlightByFlightId(state, flightId) : undefined;

  return { flightIds, getFlightById };
};

export default connect(mapStateToProps, { createSection, deleteSection })(AddSection);

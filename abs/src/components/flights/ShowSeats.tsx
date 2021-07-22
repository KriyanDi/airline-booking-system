import React from "react";
import { ISeat } from "../../interfaces/flightModel";
import TableViewer from "../_common/TableViewer";

interface ShowSeatsProps {
  seats: Map<string, ISeat>;
}

const ShowSeats = (props: ShowSeatsProps) => {
  const createSeatsContent = () => {
    if (props.seats) {
      let seats = Array.from(props.seats.values());
      return <TableViewer content={seats} />;
    }

    return null;
  };

  return <div className="ui segment">{createSeatsContent()}</div>;
};

export default ShowSeats;

import React from "react";
import TableViewer from "../_common/TableViewer";

const ShowSeats = (props) => {
  const createSeatsContent = () => {
    let seats = Array.from(props.seats.values());

    return <TableViewer content={seats} />;
  };

  return <div className="ui segment">{createSeatsContent()}</div>;
};

export default ShowSeats;

import React from "react";
import { ShowSeatsProps } from "../../interfaces/propsInterfaces";
import TableViewer from "../_common/TableViewer";

const ShowSeats = (props: ShowSeatsProps) => {
  const createSeatsContent = () => {
    console.log("SEATS");
    if (props.seats !== undefined) {
      console.log(props.seats!.values());
      let seats = Array.from(props.seats.values());
      return <TableViewer content={seats} />;
    }

    return null;
  };

  return <div className="ui segment">{createSeatsContent()}</div>;
};

export default ShowSeats;

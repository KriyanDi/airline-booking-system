import React from "react";
import TableViewer from "../_common/TableViewer";

const ShowSeats = (props) => {
  const createSeatsContent = () => {
    let seats = Array.from(props.seats.values());
    let content = seats.map((el) => ({
      seatId: el.seatId,
      booked: el.isBooked,
    }));
    //

    // return seats.map((el) => (
    //   <div className="ui">{`${el.seat}  -  ${el.isBooked}`}</div>
    // ));

    return <TableViewer content={seats} />;
  };

  return <div className="ui segment">{createSeatsContent()}</div>;
};

export default ShowSeats;

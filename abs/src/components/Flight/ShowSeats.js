import React from "react";

const ShowSeats = (props) => {
  const createSeatsContent = () => {
    let seats = Array.from(props.seats.values());

    return seats.map((el) => (
      <div className="ui">{`${el.seat}  -  ${el.isBooked}`}</div>
    ));
  };

  return <div className="ui segment">{createSeatsContent()}</div>;
};

export default ShowSeats;

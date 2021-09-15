import axios from "axios";
import React, { useState } from "react";
import { Button, Segment } from "semantic-ui-react";
import FlightSectionsList from "../../_common/FlightSectionsList";
import OriginDestinationFlightsList from "../../_common/OriginDestinationFlightsList";
import SectionSeatsList from "../../_common/SectionSeatsList";

const UserBook = () => {
  const [originId, setOriginId] = useState(-1);
  const [destinationId, setDestinationId] = useState(-1);
  const [takeOffDate, setTakeOffDate] = useState(new Date("1970-01-01Z00:00:00:000"));
  const [returnDate, setReturnDate] = useState(-1);
  const [flightId, setFlightId] = useState(-1);
  const [sectionId, setSectionId] = useState("");
  const [seatId, setSeatId] = useState(-1);
  const [selectedSeat, setSelectedSeat] = useState(false);
  const [book, setBook] = useState(true);

  const bookSeat = async (id: number) => {
    let seat = await axios.get(`https://localhost:44318/api/Seat/${id}`);

    const seatUpdated = {
      row: seat.data.row,
      column: seat.data.column,
      isBooked: true,
      flightSectionId: seat.data.flightSection.id,
    };

    const response = await axios.put(`https://localhost:44318/api/Seat/${id}`, seatUpdated);
    return response;
  };

  return (
    <Segment>
      <OriginDestinationFlightsList
        originId={originId}
        setOriginId={setOriginId}
        destinationId={destinationId}
        setDestinationId={setDestinationId}
        takeOffDate={takeOffDate}
        setTakeOffDate={setTakeOffDate}
        returnDate={returnDate}
        setReturnDate={setReturnDate}
        flightId={flightId}
        setFlightId={setFlightId}
      />

      <FlightSectionsList flightId={flightId} setSectionId={setSectionId} />

      <SectionSeatsList
        flightId={flightId}
        sectionId={sectionId}
        setSeatId={setSeatId}
        book={book}
        setSelectedSeat={setSelectedSeat}
      />

      <button
        className={`ui ${selectedSeat ? null : "disabled"} button`}
        onClick={() => {
          bookSeat(seatId);
          setBook(!book);
          setSelectedSeat(false);
        }}
      >
        Book Seat
      </button>
    </Segment>
  );
};

export default UserBook;

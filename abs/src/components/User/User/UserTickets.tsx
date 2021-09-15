import axios from "axios";
import React, { useEffect, useState } from "react";
import { Header, Segment } from "semantic-ui-react";
import { useAppDispatch, useAppSelector } from "../../../redux/hooks";
import { selectFlightById } from "../../../redux/slices/flight/flightSlice";
import { selectUser } from "../../../redux/slices/user/userSlice";
import TableViewerControl from "../../_common/TableViewerControl";

const UserTickets = (props: any) => {
  const dispatch = useAppDispatch();
  const selector = useAppSelector;
  const [tickets, setTickets] = useState([{ flightId: -1, flightSectionId: -1, seatId: -1, userId: -1 }]);
  const [flight, setFlight] = useState(null);

  const token = selector(selectUser).token;

  const getTickets = async () => {
    await axios
      .get("https://localhost:44318/api/Ticket", { headers: { Authorization: `Bearer ${token}` } })
      .then((res) => setTickets(res.data));
  };

  useEffect(() => {
    getTickets();
  }, [dispatch]);

  return (
    <Segment>
      <Header as="h3" dividing>
        Your Tickets
      </Header>

      <TableViewerControl headers={["Flight Id", "Section", "Seat"]} data={[]} />
    </Segment>
  );
};

export default UserTickets;

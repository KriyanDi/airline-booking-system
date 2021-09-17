import axios from "axios";
import React, { useEffect, useState } from "react";
import { Segment } from "semantic-ui-react";
import { useAppDispatch, useAppSelector } from "../../../redux/hooks";
import { selectUser } from "../../../redux/slices/user/userSlice";
import ListViewerControl from "../../_common/ListViewerControl";

const ManageTickets = (props: any) => {
  const dispatch = useAppDispatch();
  const selector = useAppSelector;

  const [tickets, setTickets] = useState<any>(null);

  const token = selector(selectUser).token;

  const getTickets = async () => {
    await axios
      .get("https://localhost:44318/api/Ticket", { headers: { Authorization: `Bearer ${token}` } })
      .then((res) => setTickets(res.data));
  };

  const deleteTicketById = async (id: number) => {
    await axios.delete(`https://localhost:44318/api/Ticket/${id}`, { headers: { Authorization: `Bearer ${token}` } });
    getTickets();
  };

  useEffect(() => {
    getTickets();
  }, [dispatch]);

  return (
    <Segment>
      <ListViewerControl
        objectName={`Tickets`}
        data={
          tickets === null
            ? []
            : tickets.map((t: any) => ({
                id: t.id,
                name: `U: ${t.apiUser.email} ---- FN: ${t.flight.flightNumber} ---- SC: ${t.flightSection.seatClass} ---- ST: ${t.seat.row}-${t.seat.column}`,
              }))
        }
        deleteObjectMethod={deleteTicketById}
      />
    </Segment>
  );
};

export default ManageTickets;

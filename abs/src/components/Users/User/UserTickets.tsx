// import axios from "axios";
// import React, { useEffect, useState } from "react";
// import { Header, Segment } from "semantic-ui-react";
// import { useAppDispatch, useAppSelector } from "../../../redux/hooks";
// import { selectUser } from "../../../redux/slices/user/userSlice";
// import TableViewerControl from "../../_common/TableViewerControl";

// const UserTickets = (props: any) => {
//   const dispatch = useAppDispatch();
//   const selector = useAppSelector;

//   const [tickets, setTickets] = useState<any>(null);

//   const token = selector(selectUser).token;

//   const getTickets = async () => {
//     await axios
//       .get("https://localhost:44318/api/Ticket", { headers: { Authorization: `Bearer ${token}` } })
//       .then((res) => setTickets(res.data));
//   };

//   useEffect(() => {
//     getTickets();
//   }, [dispatch]);

//   return (
//     <Segment>
//       <Header as="h3" dividing>
//         Your Tickets
//       </Header>

//       <TableViewerControl
//         headers={["Flight Number", "Section", "Seat", "Date"]}
//         data={
//           tickets === null
//             ? []
//             : tickets.map((ticket: any) => ({
//                 flightNumber: ticket.flight.flightNumber,
//                 section: ticket.flightSection.seatClass,
//                 saet: `${ticket.seat.row}${ticket.seat.column}`,
//                 date: new Date(ticket.flight.date).toISOString().split("T")[0],
//               }))
//         }
//       />
//     </Segment>
//   );
// };

// export default UserTickets;
export {};

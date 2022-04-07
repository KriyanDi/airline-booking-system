export {};
// import React, { useEffect, useState } from "react";
// import axios from "axios";
// import { Dropdown, Form, Header, Segment } from "semantic-ui-react";
// import { useAppDispatch } from "../../redux/hooks";

// const SectionSeatsList = (props: any) => {
//   const dispatch = useAppDispatch();

//   const [seats, setSeats] = useState([{ id: null, row: null, column: null }]);
//   const { sectionId, setSeatId, book, setSelectedSeat } = props;

//   const getSectionById = async (obj: { id: number }) => {
//     const response = await axios.get(`https://localhost:44318/api/FlightSection/${obj.id}`);
//     return response.data;
//   };

//   useEffect(() => {
//     getSectionById({ id: sectionId }).then((res) => setSeats(res.seats?.filter((s: any) => s.isBooked === false)));

//     seatsOptions =
//       seats !== undefined
//         ? seats.map((seat) => ({
//             key: seat.id,
//             text: `${seat.row} --- ${seat.column}`,
//             value: seat.id,
//           }))
//         : null;
//   }, [dispatch, sectionId, book]);

//   let seatsOptions =
//     seats !== undefined
//       ? seats.map((seat) => ({
//           key: seat.id,
//           text: `${seat.row} --- ${seat.column}`,
//           value: seat.id,
//         }))
//       : null;

//   return (
//     <Segment>
//       <Header as="h3" dividing>
//         Select Seat
//       </Header>

//       <Form>
//         <Form.Group widths="equal">
//           <Form.Field
//             control={Dropdown}
//             label="Available Seats"
//             options={seatsOptions}
//             selection
//             onChange={(e: any, data: any) => {
//               console.log(data.value);
//               setSeatId(data.value);
//               if (data.value !== "") {
//                 setSelectedSeat(true);
//               }
//             }}
//           />
//         </Form.Group>
//       </Form>
//     </Segment>
//   );
// };

// export default SectionSeatsList;

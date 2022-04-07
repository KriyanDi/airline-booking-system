export {};
// import React, { useEffect } from "react";
// import { Dropdown, Form, Header, Input, Segment } from "semantic-ui-react";
// import { useAppDispatch, useAppSelector } from "../../_redux/hooks";
// import {
//   fetchFlights,
//   selectFlights,
// } from "../../redux/slices/flight/flightSlice";

// const OriginDestinationFlightsList = (props: any) => {
//   const dispatch = useAppDispatch();
//   const selector = useAppSelector;

//   // const currentDate = new Date();
//   // let year = `${currentDate.getFullYear()}`;
//   // let month = `${currentDate.getMonth() > 10 ? currentDate.getMonth() : `0${currentDate.getMonth()}`}`;
//   // let day = `${currentDate.getDay() > 10 ? currentDate.getDay() : `0${currentDate.getDay()}`}`;
//   // const calendarDateLimit = `${year}-${month}-${day}`;

//   const {
//     originId,
//     setOriginId,
//     destinationId,
//     setDestinationId,
//     takeOffDate,
//     setTakeOffDate,
//     // returnDate,
//     // setReturnDate,
//     // flightId,
//     setFlightId,
//   } = props;

//   useEffect(() => {
//     // dispatch(fetchAirports());
//     // dispatch(fetchFlights());
//   }, [dispatch]);

//   // let airportsOptions = selector(selectAirports).map((airport: any) => ({
//   //   key: airport.id,
//   //   text: airport.name,
//   //   value: airport.id,
//   // }));

//   let flights = selector(selectFlights).map((flight: any) => ({
//     key: flight.id,
//     text: flight.flightNumber,
//     value: {
//       id: flight.id,
//       orig: flight.originId,
//       dest: flight.destinationId,
//       date: new Date(Date.parse(flight.date.toString())),
//     },
//   }));

//   return (
//     <div>
//       <Segment>
//         <Header as="h3" dividing>
//           Select Flight
//         </Header>
//         <Form>
//           <Form.Group widths="equal">
//             <Form.Field
//               control={Dropdown}
//               label="Originate Airport"
//               clearable
//               options={airportsOptions}
//               selection
//               onChange={(e: any, data: any) => {
//                 setOriginId(data.value);
//               }}
//             />

//             <Form.Field
//               control={Dropdown}
//               label="Destination Airport"
//               clearable
//               options={airportsOptions.filter(
//                 (airport) => airport.value !== originId
//               )}
//               selection
//               onChange={(e: any, data: any) => {
//                 setDestinationId(data.value);
//               }}
//             />
//           </Form.Group>

//           <Form.Group widths="equal">
//             <Form.Field
//               control={Input}
//               label="Take Off Date:"
//               type="date"
//               id="start"
//               name="trip-start"
//               //   min={calendarDateLimit}
//               onChange={(e: any) => {
//                 setTakeOffDate(new Date(e.target.value));
//               }}
//             />

//             {/* <Form.Field
//               control={Input}
//               label="Return Date:"
//               type="date"
//               id="start"
//               name="trip-start"
//               min={calendarDateLimit}
//               onChange={(e: any) => {
//                 setDate(e.target.value);
//               }}
//             /> */}
//           </Form.Group>

//           <Form.Group widths="equal">
//             <Form.Field
//               control={Dropdown}
//               label="Choose Available Flight"
//               clearable
//               options={flights.filter(
//                 (flight) =>
//                   flight.value.orig === originId &&
//                   flight.value.dest === destinationId &&
//                   flight.value.date.getFullYear() ===
//                     takeOffDate.getFullYear() &&
//                   flight.value.date.getMonth() === takeOffDate.getMonth() &&
//                   flight.value.date.getDay() === takeOffDate.getDay()
//               )}
//               selection
//               onChange={(e: any, data: any) => {
//                 setFlightId(data.value.id);
//               }}
//             />
//           </Form.Group>
//         </Form>
//       </Segment>
//     </div>
//   );
// };

// export default OriginDestinationFlightsList;

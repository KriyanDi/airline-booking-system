// import React from "react";
// import ManageElement from "../_common/ManageElement";
// import { connect } from "react-redux";
// import { selectAirports } from "../../utils/selectors";
// import { IAirport } from "../../interfaces/airportModel";
// import { ManageAirportProps } from "../../interfaces/propsInterfaces";
// import { createAirport, deleteAirport } from "../../_redux/slices/airportsSlice";
// import { deleteFlightsOnDeletedAirport } from "../../_redux/slices/flightsSlice";
// import { RootState } from "../../_redux/store";

// const ManageAirports = (props: ManageAirportProps) => {
//   const onAirportDeleteHandler = (el: IAirport) => {
//     props.deleteAirport({ id: el.id });
//     props.deleteFlightsOnDeletedAirport({ name: el.name });
//   };

//   return (
//     <ManageElement
//       elementName="Airports"
//       list={props.airportValues}
//       onAdd={props.createAirport}
//       onDelete={onAirportDeleteHandler}
//     />
//   );
// };

// const mapStateToProps = (state: RootState) => {
//   let airportValues = selectAirports(state);
//   return { airportValues };
// };

// export default connect(mapStateToProps, {
//   createAirport,
//   deleteAirport,
//   deleteFlightsOnDeletedAirport,
// })(ManageAirports);
export {};

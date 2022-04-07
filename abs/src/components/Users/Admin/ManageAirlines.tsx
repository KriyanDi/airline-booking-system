// import axios from "axios";
// import React, { useEffect } from "react";
// import { useAppDispatch, useAppSelector } from "../../../redux/hooks";
// import { deleteAirline, fetchAirlines, postAirline, selectAirlines } from "../../../redux/slices/airline/airlineSlice";

// import ManageObject from "../../_common/ManageObject";

// const ManageAirlines = (props: any) => {
//   const dispatch = useAppDispatch();
//   const selector = useAppSelector;

//   useEffect(() => {
//     dispatch(fetchAirlines());
//   }, [dispatch]);

//   let data = selector(selectAirlines);

//   const deleteAirlineMethod = async (id: number) => {
//     await axios.delete(`https://localhost:44318/api/Airline/${id}`);

//     dispatch(fetchAirlines());
//     // dispatch(deleteAirline({ id: id }));
//   };

//   const postObjectMethod = async (name: string) => {
//     await axios.post(`https://localhost:44318/api/Airline`, {
//       name: name,
//     });

//     dispatch(fetchAirlines());
//     // dispatch(postAirline({ name: name }));
//   };

//   return (
//     <ManageObject
//       objectName="Airlines"
//       data={data}
//       deleteObjectMethod={deleteAirlineMethod}
//       postObjectMethod={postObjectMethod}
//     />
//   );
// };

// export default ManageAirlines;
export {};

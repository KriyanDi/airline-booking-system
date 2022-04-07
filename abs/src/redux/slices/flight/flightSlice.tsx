// import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
// import axios from "axios";
// import { useAppSelector } from "../../hooks";
// import type { RootState } from "../../store";
// import { selectUser } from "../user/userSlice";
// import { IFlightState } from "./flightInterfaces";

// export const fetchFlights = createAsyncThunk("abs/fetchFlights", async () => {
//   const response = await axios.get("https://localhost:44318/api/Flight");
//   return response.data;
// });

// export const postFlight = createAsyncThunk(
//   "abs/postFlight",
//   async (
//     obj: { flightNumber: string; date: Date; airlineId: number; originId: number; destinationId: number },
//     { dispatch }
//   ) => {
//     const token = useAppSelector(selectUser).token;

//     const response = await axios.post(`https://localhost:44318/api/Flight`, {
//       flightNumber: obj.flightNumber,
//       date: obj.date,
//       airlineId: obj.airlineId,
//       originId: obj.originId,
//       destinationId: obj.destinationId,
//       headers: {
//         Authorization: `Bearer ${token}`,
//       },
//     });

//     dispatch(fetchFlights());

//     return response;
//   }
// );

// export const deleteFlight = createAsyncThunk("abs/deleteFlight", async (obj: { id: number }, { dispatch }) => {
//   const response = await axios.delete(`https://localhost:44318/api/Flight/${obj.id}`);
//   dispatch(fetchFlights());
//   return response;
// });

// const initialState: IFlightState = {
//   flights: [],
//   status: "idle",
//   error: null,
// };

// export const flightSlice = createSlice({
//   name: "flights",
//   initialState,
//   reducers: {},
//   extraReducers: (builder) => {
//     builder
//       .addCase(fetchFlights.pending, (state, action) => {
//         state.status = "loading";
//       })
//       .addCase(fetchFlights.fulfilled, (state, action) => {
//         state.flights = action.payload;
//         state.status = "succeeded";
//       })
//       .addCase(fetchFlights.rejected, (state, action) => {
//         state.status = "failed";
//       })
//       .addCase(postFlight.pending, (state, action) => {
//         state.status = "loading";
//       })
//       .addCase(postFlight.fulfilled, (state, action) => {
//         state.status = "succeeded";
//       })
//       .addCase(postFlight.rejected, (state, action) => {
//         state.status = "failed";
//       })
//       .addCase(deleteFlight.pending, (state, action) => {
//         state.status = "loading";
//       })
//       .addCase(deleteFlight.fulfilled, (state, action) => {
//         state.status = "succeeded";
//       })
//       .addCase(deleteFlight.rejected, (state, action) => {
//         state.status = "failed";
//       });
//   },
// });

// export const selectFlights = (state: RootState) => state.flightReducer.flights;

// export function selectFlightById(flightId: number): any {
//   return (state: RootState) => state.flightReducer.flights.find((flight) => flight.id === flightId);
// }

// export default flightSlice.reducer;
export {};

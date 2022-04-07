// import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
// import axios from "axios";
// import { useAppSelector } from "../../hooks";
// import type { RootState } from "../../store";
// import { selectUser } from "../user/userSlice";
// import { IAirportState } from "./airportInterfaces";

// export const fetchAirports = createAsyncThunk("abs/fetchAirports", async () => {
//   const response = await axios.get("https://localhost:44318/api/Airport");
//   return response.data;
// });

// export const postAirport = createAsyncThunk("abs/postAirport", async (obj: { name: string }, { dispatch }) => {
//   const token = useAppSelector(selectUser).token;

//   const response = await axios.post(`https://localhost:44318/api/Airport`, {
//     name: obj.name,
//     headers: {
//       Authorization: `Bearer ${token}`,
//     },
//   });

//   dispatch(fetchAirports());

//   return response;
// });

// export const deleteAirport = createAsyncThunk("abs/deleteAirport", async (obj: { id: number }, { dispatch }) => {
//   const token = useAppSelector(selectUser).token;

//   const response = await axios.delete(`https://localhost:44318/api/Airport/${obj.id}`, {
//     headers: {
//       Authorization: `Bearer ${token}`,
//     },
//   });

//   dispatch(fetchAirports());
//   return response;
// });

// const initialState: IAirportState = {
//   airports: [],
//   status: "idle",
//   error: null,
// };

// export const airportSlice = createSlice({
//   name: "airports",
//   initialState,
//   reducers: {},
//   extraReducers: (builder) => {
//     builder
//       .addCase(fetchAirports.pending, (state, action) => {
//         state.status = "loading";
//       })
//       .addCase(fetchAirports.fulfilled, (state, action) => {
//         state.airports = action.payload;
//         state.status = "succeeded";
//       })
//       .addCase(fetchAirports.rejected, (state, action) => {
//         state.status = "failed";
//       })
//       .addCase(postAirport.pending, (state, action) => {
//         state.status = "loading";
//       })
//       .addCase(postAirport.fulfilled, (state, action) => {
//         state.status = "succeeded";
//       })
//       .addCase(postAirport.rejected, (state, action) => {
//         state.status = "failed";
//       })
//       .addCase(deleteAirport.pending, (state, action) => {
//         state.status = "loading";
//       })
//       .addCase(deleteAirport.fulfilled, (state, action) => {
//         state.status = "succeeded";
//       })
//       .addCase(deleteAirport.rejected, (state, action) => {
//         state.status = "failed";
//       });
//   },
// });

// export const selectAirports = (state: RootState) => state.airportReducer.airports;

// export const selectAirportStateStatus = (state: RootState) => state.airportReducer.status;

// export const selectAirportById = (state: RootState, airportId: number) =>
//   state.airportReducer.airports.find((airport) => airport.id === airportId);

// export default airportSlice.reducer;
export {};

import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import type { RootState } from "../../store";
import { IFlightState, IFlight } from "./flightInterfaces";

export const fetchFlights = createAsyncThunk("abs/fetchFlights", async () => {
  const response = await axios.get("https://localhost:44318/api/Flight");
  return response.data;
});

export const deleteAirport = createAsyncThunk("abs/deleteFlight", async (obj: { id: string }, { dispatch }) => {
  const response = await axios.delete(`https://localhost:44318/api/Flight/${obj.id}`);
  dispatch(fetchFlights());
  return response;
});

const initialState: IFlightState = {
  flights: [],
  status: "idle",
  error: null,
};

export const flightSlice = createSlice({
  name: "flights",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchFlights.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(fetchFlights.fulfilled, (state, action) => {
        state.flights = action.payload;
        state.status = "succeeded";
      })
      .addCase(fetchFlights.rejected, (state, action) => {
        state.status = "failed";
      });
  },
});

export const {} = flightSlice.actions;

export const selectFlights = (state: RootState) => state.flightReducer.flights;

export function selectFlightById(flightId: number): any {
  return (state: RootState) => state.flightReducer.flights.find((flight) => flight.id === flightId);
}

export default flightSlice.reducer;

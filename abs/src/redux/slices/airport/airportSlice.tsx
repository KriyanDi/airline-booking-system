import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import type { RootState } from "../../store";
import { IAirportState, IAirport } from "./airportInterfaces";

export const fetchAirports = createAsyncThunk("abs/fetchAirports", async () => {
  const response = await axios.get("https://localhost:44318/api/Airport");
  return response.data;
});

export const deleteAirport = createAsyncThunk("abs/deleteAirport", async (obj: { id: string }, { dispatch }) => {
  const response = await axios.delete(`https://localhost:44318/api/Airport/${obj.id}`);
  dispatch(fetchAirports());
  return response;
});

const initialState: IAirportState = {
  airports: [],
  status: "idle",
  error: null,
};

export const airportSlice = createSlice({
  name: "airports",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchAirports.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(fetchAirports.fulfilled, (state, action) => {
        state.airports = action.payload;
        state.status = "succeeded";
      })
      .addCase(fetchAirports.rejected, (state, action) => {
        state.status = "failed";
      });
  },
});

export const {} = airportSlice.actions;

export const selectAirports = (state: RootState) => state.airportReducer.airports;

export const selectAirportById = (state: RootState, airportId: string) =>
  state.airportReducer.airports.find((airport) => airport.id === airportId);

export default airportSlice.reducer;

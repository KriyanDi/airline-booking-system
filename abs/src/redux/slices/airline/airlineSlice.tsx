import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import type { RootState } from "../../store";
import { IAirlineState, IAirline } from "./airlineInterfaces";

export const fetchAirlines = createAsyncThunk("abs/fetchAirlines", async () => {
  const response = await axios.get("https://localhost:44318/api/Airlines");
  return response.data;
});

export const deleteAirline = createAsyncThunk("abs/deleteAirline", async (obj: { id: string }, { dispatch }) => {
  const response = await axios.delete(`https://localhost:44318/api/Airline/${obj.id}`);
  dispatch(fetchAirlines());
  return response;
});

const initialState: IAirlineState = {
  airlines: [],
  status: "idle",
  error: null,
};

export const airlineSlice = createSlice({
  name: "airlines",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchAirlines.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(fetchAirlines.fulfilled, (state, action) => {
        state.airlines = action.payload;
        state.status = "succeeded";
      })
      .addCase(fetchAirlines.rejected, (state, action) => {
        state.status = "failed";
      });
  },
});

export const {} = airlineSlice.actions;

export const selectAirlines = (state: RootState) => state.airlineReducer;

export const selectAirlineById = (state: RootState, airlineId: string) =>
  state.airlineReducer.airlines.find((airline) => airline.id === airlineId);

export default airlineSlice.reducer;

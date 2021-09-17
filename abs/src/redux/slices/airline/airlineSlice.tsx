import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import { useAppSelector } from "../../hooks";
import type { RootState } from "../../store";
import { selectUser } from "../user/userSlice";
import { IAirlineState } from "./airlineInterfaces";

export const fetchAirlines = createAsyncThunk("abs/fetchAirlines", async () => {
  const response = await axios.get("https://localhost:44318/api/Airline");
  return response.data;
});

export const postAirline = createAsyncThunk("abs/postAirline", async (obj: { name: string }, { dispatch }) => {
  const token = useAppSelector(selectUser).token;

  const response = await axios.post(`https://localhost:44318/api/Airline`, {
    name: obj.name,
    headers: { Authorization: `Bearer ${token}` },
  });

  dispatch(fetchAirlines());

  return response;
});

export const deleteAirline = createAsyncThunk("abs/deleteAirline", async (obj: { id: number }, { dispatch }) => {
  const token = useAppSelector(selectUser).token;

  const response = await axios.delete(`https://localhost:44318/api/Airline/${obj.id}`, {
    headers: { Authorization: `Bearer ${token}` },
  });

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
      })
      .addCase(postAirline.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(postAirline.fulfilled, (state, action) => {
        state.status = "succeeded";
      })
      .addCase(postAirline.rejected, (state, action) => {
        state.status = "failed";
      })
      .addCase(deleteAirline.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(deleteAirline.fulfilled, (state, action) => {
        state.status = "succeeded";
      })
      .addCase(deleteAirline.rejected, (state, action) => {
        state.status = "failed";
      });
  },
});

export const selectAirlines = (state: RootState) => state.airlineReducer.airlines;

export const selectAirlineById = (state: RootState, airlineId: number) =>
  state.airlineReducer.airlines.find((airline) => airline.id === airlineId);

export default airlineSlice.reducer;

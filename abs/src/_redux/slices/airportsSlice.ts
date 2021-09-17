// import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

// const fetchAirportNames = createAsyncThunk("airports/fetchAllAirportNamesStatus", async () => {
//   const response = await fetch("https://localhost:44350/api/Airports").then((response) => response.json());
//   return response.data;
// });

// const airportsSlice = createSlice({
//   name: "airports",
//   initialState: { airports: [], loading: "idle", error: `` },
//   reducers: {},
//   extraReducers: {
//     [fetchAirportNames.pending]: (state, action) => {},
//   },
// });

import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IAirport } from "../../interfaces/airportModel";
import axios from "axios";
import { apiAddress } from "../../utils/constants";
import { useState } from "react";

let counter = 0;

export interface AirportState {
  airports: Map<number, IAirport>;
}

async function setAirports() {
  let dataAirports: any = [];

  await axios
    .get(`${apiAddress}/Airports`)
    .then((res) => res)
    .then((info) => {
      dataAirports = info.data;
    })
    .catch(function (error) {
      console.log(error);
    });

  let initialState: AirportState = { airports: new Map() };

  dataAirports.forEach((airport: any) => initialState.airports.set(airport.id, { name: airport.name, id: airport.id }));

  console.log(initialState);

  return initialState;
}

export const airportsSlice = createSlice({
  name: "airports",
  initialState: setAirports(),
  reducers: {
    createAirport: async (state, action: PayloadAction<{ name: string }>) => {
      await axios.post(`${apiAddress}/Airports`, { name: action.payload.name });

      return state;
    },

    deleteAirport: async (state, action: PayloadAction<{ id: number }>) => {
      await axios.delete(`${apiAddress}/Airports/${action.payload.id}`);

      return state;
    },
  },
});

export const { createAirport, deleteAirport } = airportsSlice.actions;

export default airportsSlice.reducer;

import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IAirport } from "../../interfaces/airportModel";

export interface AirportState {
  airports: Map<number, IAirport>;
}

const initialState: AirportState = {
  airports: new Map()
    .set(100, { name: "DTC", id: 100 })
    .set(101, { name: "BGN", id: 101 })
    .set(102, { name: "UTS", id: 102 })
    .set(103, { name: "WEQ", id: 103 })
    .set(104, { name: "POS", id: 104 }),
};

export const airportsSlice = createSlice({
  name: "airports",
  initialState: initialState,
  reducers: {
    createAirport: (state, action: PayloadAction<{ id: number; name: string }>) => {
      state.airports.set(action.payload.id, {
        name: action.payload.name,
        id: action.payload.id,
      });

      return {
        ...state,
      };
    },

    deleteAirport: (state, action: PayloadAction<{ id: number }>) => {
      state.airports.delete(action.payload.id);

      return {
        ...state,
      };
    },
  },
});

export const { createAirport, deleteAirport } = airportsSlice.actions;

export default airportsSlice.reducer;

import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IAirline } from "../../interfaces/airlineModel";

let counter = 0;

export interface AirlineState {
  airlines: Map<number, IAirline>;
}

const initialState: AirlineState = {
  airlines: new Map()
    .set(100, { name: "DTC", id: 100 })
    .set(101, { name: "BGN", id: 101 })
    .set(102, { name: "UTS", id: 102 })
    .set(103, { name: "WEQ", id: 103 })
    .set(104, { name: "POS", id: 104 }),
};

export const airlinesSlice = createSlice({
  name: "airlines",
  initialState: initialState,
  reducers: {
    createAirline: (state, action: PayloadAction<{ name: string }>) => {
      const airlineId = counter++;

      state.airlines.set(airlineId, {
        name: action.payload.name,
        id: airlineId,
      });

      return state;
    },

    deleteAirline: (state, action: PayloadAction<{ id: number }>) => {
      state.airlines.delete(action.payload.id);

      return state;
    },
  },
});

export const { createAirline, deleteAirline } = airlinesSlice.actions;

export default airlinesSlice.reducer;

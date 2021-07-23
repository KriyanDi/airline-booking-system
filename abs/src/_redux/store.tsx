import { configureStore } from "@reduxjs/toolkit";
import airlinesReducer from "./slices/airlinesSlice";
import airportsReducer from "./slices/airportsSlice";
import flightsReducer from "./slices/flightsSlice";

export const store = configureStore({
  reducer: {
    airlines: airlinesReducer,
    airports: airportsReducer,
    flights: flightsReducer,
  },
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;

export default store;

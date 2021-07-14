import { AIRPORT } from "./actionTypes";

let counter = 0;

export const createAirport = (name) => ({
  type: AIRPORT.ADD_AIRPORT,
  payload: {
    name,
    id: ++counter,
  },
});

export const deleteAirport = (id) => ({
  type: AIRPORT.DELETE_AIRPORT,
  payload: {
    id,
  },
});
import { AIRLINE } from "./actionTypes";

let counter = 0;

export const createAirline = (name) => ({
  type: AIRLINE.ADD_AIRLINE,
  payload: {
    name,
    id: ++counter,
  },
});

export const deleteAirline = (name, id) => ({
  type: AIRLINE.DELETE_AIRLINE,
  payload: {
    name,
    id,
  },
});

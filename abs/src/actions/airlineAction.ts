import { Action, AIRLINE } from "../interfaces/actionTypes";
import { IAirline } from "../interfaces/airlineModel";

let counter: number = 0;

export const createAirline = (name: string): Action<AIRLINE, IAirline> => ({
  type: "ADD_AIRLINE",
  payload: {
    id: counter++,
    name: name,
  },
});

export const deleteAirline = (id: number): Action<AIRLINE, IAirline> => ({
  type: "DELETE_AIRLINE",
  payload: {
    id: id,
  },
});

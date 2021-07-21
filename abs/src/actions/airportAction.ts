import { Action, AIRPORT } from "../interfaces/actionTypes";
import { IAirport } from "../interfaces/airportModel";

let counter: number = 0;

export const createAirport = (name: string): Action<AIRPORT, IAirport> => ({
  type: "ADD_AIRPORT",
  payload: {
    id: counter++,
    name: name,
  },
});

export const deleteAIrport = (id: number): Action<AIRPORT, IAirport> => ({
  type: "DELETE_AIRPORT",
  payload: {
    id: id,
  },
});

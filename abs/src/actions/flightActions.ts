import { Action, FLIGHT } from "../interfaces/actionTypes";
import { IFlight, SEATCLASS } from "../interfaces/flightModel";

let counter = 0;

// FLIGHT
export const createFlight = (
  airline: string,
  from: string,
  to: string,
  date: Date
): Action<FLIGHT, IFlight> => ({
  type: "ADD_FLIGHT",
  payload: {
    id: counter++,
    airline: airline,
    from: from,
    to: to,
    date: date,
  },
});

export const deleteFlight = (id: number): Action<FLIGHT, { id: number }> => ({
  type: "DELETE_FLIGHT",
  payload: {
    id: id,
  },
});

export const deleteFlightsOnDeletedAirport = (name: string): Action<FLIGHT, { name: string }> => ({
  type: "DELETE_FLIGHTS_ON_DELETED_AIRLINE",
  payload: {
    name: name,
  },
});

export const deleteFlightsOnDeletedAirline = (name: string): Action<FLIGHT, { name: string }> => ({
  type: "DELETE_FLIGHTS_ON_DELETED_AIRLINE",
  payload: {
    name: name,
  },
});

// SECTIONS
export const createSection = (
  id: number,
  seatClass: SEATCLASS,
  rows: number,
  cols: number
): Action<FLIGHT, { id: number; seatClass: SEATCLASS; rows: number; cols: number }> => ({
  type: "ADD_SECTION",
  payload: {
    id: id,
    seatClass: seatClass,
    rows: rows,
    cols: cols,
  },
});

export const deleteSection = (
  id: number,
  seatClass: SEATCLASS
): Action<FLIGHT, { id: number; seatClass: SEATCLASS }> => ({
  type: "DELETE_SECTION",
  payload: {
    id: id,
    seatClass: seatClass,
  },
});

//BOOK SEAT
export const bookSeat = (
  id: number,
  seatClass: SEATCLASS,
  seatId: string
): Action<FLIGHT, { id: number; seatClass: SEATCLASS; seatId: string }> => ({
  type: "BOOK_SEAT",
  payload: {
    id: id,
    seatClass: seatClass,
    seatId: seatId,
  },
});

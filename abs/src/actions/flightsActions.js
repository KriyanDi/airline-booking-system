import { FLIGHT } from "./actionTypes";

let counter = 0;

export const createFlight = (airline, from, to) => ({
  type: FLIGHT.ADD_FLIGHT,
  payload: {
    airline,
    from,
    to,
    id: ++counter,
  },
});

export const deleteFlight = (id) => ({
  type: FLIGHT.DELETE_FLIGHT,
  payload: {
    id,
  },
});

export const createSection = (id, seatClass, rows, cols) => ({
  type: FLIGHT.ADD_SECTION,
  payload: {
    id,
    seatClass,
    rows,
    cols,
  },
});

export const deleteSection = (id, seatClass) => ({
  type: FLIGHT.DELETE_SECTION,
  payload: {
    id,
    seatClass,
  },
});

export const bookSeat = (id, seatClass, seatId) => ({
  type: FLIGHT.BOOK_SEAT,
  payload: {
    id,
    seatClass,
    seatId,
  },
});

export const unbookSeat = (id, seatClass, seatId) => ({
  type: FLIGHT.UNBOOK_SEAT,
  payload: {
    id,
    seatClass,
    seatId,
  },
});

export interface Action<IType, IPayload> {
  type: IType;
  payload: IPayload;
}

export type AIRPORT = "ADD_AIRPORT" | "DELETE_AIRPORT";

export type AIRLINE = "ADD_AIRLINE" | "DELETE_AIRLINE";

export type FLIGHT =
  | "ADD_FLIGHT"
  | "DELETE_FLIGHT"
  | "DELETE_FLIGHTS_ON_DELETED_AIRPORT"
  | "DELETE_FLIGHTS_ON_DELETED_AIRLINE"
  | "ADD_SECTION"
  | "DELETE_SECTION"
  | "BOOK_SEAT";

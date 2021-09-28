export interface IFlight {
  id: number;
  flightNumber: string;
  date: Date;
  airlineId: string;
  originId: string;
  destinationId: string;
}

export interface IFlightState {
  flights: IFlight[];
  status: "idle" | "loading" | "succeeded" | "failed";
  error: string | null;
}

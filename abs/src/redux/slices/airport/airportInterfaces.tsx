export interface IAirport {
  id: string;
  name: string;
}

export interface IAirportState {
  airports: IAirport[];
  status: "idle" | "loading" | "succeeded" | "failed";
  error: string | null;
}

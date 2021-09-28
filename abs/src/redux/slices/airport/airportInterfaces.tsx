export interface IAirport {
  id: number;
  name: string;
}

export interface IAirportState {
  airports: IAirport[];
  status: "idle" | "loading" | "succeeded" | "failed";
  error: string | null;
}

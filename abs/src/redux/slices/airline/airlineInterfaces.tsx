export interface IAirline {
  id: string;
  name: string;
}

export interface IAirlineState {
  airlines: IAirline[];
  status: "idle" | "loading" | "succeeded" | "failed";
  error: string | null;
}

export interface IFlightSection {
  Flight_Section_Id: string;
  Flight_Id: string;
  Seatclass_Id: string;
  Rows: number;
  Cols: number;
}

export interface ISeatclass {
  Seatclass_Id: string;
  Type: string;
}

export interface ISeat {
  Booked: boolean;
  Seat_Id: string;
  Row: number;
  Col: string;
}

export interface ICreateFlightSection {
  flight_Id: string;
  seatclass_Id: string;
  rows: number;
  cols: number;
}

export interface IFlight {
  Flight_Id: string;
  Airline_Id: string;
  Orig_Airport_Id: string;
  Dest_Airport_Id: string;
  Flight_Number: string;
  Take_Off: Date;
}

export interface IFlightInfo {
  Flight_Id: string;
  Flight_Number: string;
  Airline: string;
  Orig: string;
  Dest: string;
  Take_Off: Date;
  Seatclass: string;
  Booked_Seats: number;
  Free_Seats: number;
}

export interface ICreateFlight {
  airline_Id: string;
  orig_Airport_Id: string;
  dest_Airport_Id: string;
  take_Off: Date;
}

export interface IUpdateFlight {
  airline_Id: string;
  orig_Airport_Id: string;
  dest_Airport_Id: string;
  take_Off: Date;
}

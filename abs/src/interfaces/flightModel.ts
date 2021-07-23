export interface IFlight {
  id: number;
  flightId: string;
  airline: string;
  from: string;
  to: string;
  seatClasses: Map<string, ISeatClasses>;
  date: Date;
}

export interface ISeatClasses {
  seatClass: string;
  rows: number;
  cols: number;
  seats: Map<string, ISeat>;
  maxCapacity: number;
  currOcuppation: number;
}

export interface ISeat {
  seatId: string;
  isBooked: boolean;
}

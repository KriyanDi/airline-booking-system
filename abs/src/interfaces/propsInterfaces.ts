import { ActionCreatorWithPayload } from "@reduxjs/toolkit/dist/createAction";
import { IAirport } from "./airportModel";
import { IAirline } from "./airlineModel";
import { IFlight, ISeat } from "./flightModel";

// AIRPORT
export interface ManageAirportProps {
  airportValues: IAirport[];
  createAirport: ActionCreatorWithPayload<{ name: string }, string>;
  deleteAirport: ActionCreatorWithPayload<{ id: number }, string>;
  deleteFlightsOnDeletedAirport: ActionCreatorWithPayload<{ name: string }, string>;
}

// AIRLINE
export interface ManageAirlinesProps {
  airlineValues: IAirline[];
  createAirline: ActionCreatorWithPayload<{ name: string }, string>;
  deleteAirline: ActionCreatorWithPayload<{ id: number }, string>;
  deleteFlightsOnDeletedAirline: ActionCreatorWithPayload<{ name: string }, string>;
}

//FLIGHT
export interface AddFlightProps {
  airports: string[];
  airlines: string[];
  flights: IFlight[];
  createFlight: ActionCreatorWithPayload<
    {
      airline: string;
      from: string;
      to: string;
      date: Date;
    },
    string
  >;
  deleteFlight: ActionCreatorWithPayload<
    {
      id: number;
    },
    string
  >;
}

export interface FlightInfo {
  airline: string;
  from: string;
  to: string;
  day: number | undefined;
  month: number | undefined;
  year: number | undefined;
}

// COMPONENTS
export interface AddElementProps {
  elementName: string;
  onAdd: ActionCreatorWithPayload<{ name: string }, string>;
}

export interface TableViewerProps {
  content: any;
  onDelete?(el: any): void;
}

export interface AddSectionProps {
  flightIds: string[];
  getFlightById(flightId: string): IFlight | undefined;
  createSection: ActionCreatorWithPayload<
    {
      id: number;
      seatClass: string;
      rows: number;
      cols: number;
    },
    string
  >;
  deleteSection: ActionCreatorWithPayload<
    {
      id: number;
      seatClass: string;
    },
    string
  >;
}

export interface SearchFlightProps {
  airports: string[];
  flights: IFlight[];
}

export interface BookSeatProps {
  airports: string[];
  flightIds: string[];
  bookSeat: ActionCreatorWithPayload<
    {
      id: number;
      seatClass: string;
      seatId: string;
    },
    string
  >;
  getFlightById(flightId: string): any;
  getColsForFlightSection(flightId: string, seatClass: string): number;
  getRowsForFlightSection(flightId: string, seatClass: string): number;
}

export interface ShowSeatsProps {
  seats: Map<string, ISeat> | undefined;
}

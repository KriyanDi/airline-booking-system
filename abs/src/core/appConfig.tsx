export interface AppConfig {
  basicApiBase: string;
  airportApiBase: string;
  airlineApiBase: string;
  flightApiBase: string;
  flightSectionApiBase: string;
  seatApiBase: string;
}

const appConfig: AppConfig = {
  basicApiBase: "https://localhost:5001/api",
  airportApiBase: "/Airports",
  airlineApiBase: "/Airlines",
  flightApiBase: "/Flights",
  flightSectionApiBase: "/FlightSections",
  seatApiBase: "/Seat",
};

export default appConfig;

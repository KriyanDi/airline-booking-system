import { IApiClient } from "../../api/ApiClient";
import appConfig from "../../appConfig";
import { ICreateFlight, IFlight, IFlightInfo, IUpdateFlight } from "./types";

export interface IFlightApiClient {
  getFlights(): Promise<IFlight[] | undefined>;
  getFlightsInfo(): Promise<IFlightInfo[] | undefined>;
  getFlightInfoById(Flight_Id: string): Promise<IFlightInfo | undefined>;
  getAvailableFlights(): Promise<IFlightInfo[] | undefined>;
  SearchFlights(orig: string, dest: string): Promise<IFlightInfo[] | undefined>;
  createFlight(object: ICreateFlight): Promise<boolean>;
  updateFlight(Flight_Id: string, object: IUpdateFlight): Promise<boolean>;
  deleteFlight(Flight_Id: string): Promise<boolean>;
}

export class FlightApiClient implements IFlightApiClient {
  apiBase: string;
  flightApiClient: IApiClient;

  constructor(flightApiClient: IApiClient) {
    this.apiBase = appConfig.flightApiBase;
    this.flightApiClient = flightApiClient;
  }

  async getFlights(): Promise<IFlight[] | undefined> {
    try {
      const response = await this.flightApiClient.get<IFlight[]>(
        `${this.apiBase}`
      );
      return response;
    } catch (error) {
      console.error(error);
    }
  }

  async getFlightsInfo(): Promise<IFlightInfo[] | undefined> {
    try {
      const response = await this.flightApiClient.get<IFlightInfo[]>(
        `${this.apiBase}/Info`
      );
      return response;
    } catch (error) {
      console.error(error);
    }
  }

  async getFlightInfoById(Flight_Id: string): Promise<IFlightInfo | undefined> {
    try {
      const response = await this.flightApiClient.get<IFlightInfo>(
        `${this.apiBase}/Info/${Flight_Id}`
      );
      return response;
    } catch (error) {
      console.error(error);
    }
  }

  async getAvailableFlights(): Promise<IFlightInfo[] | undefined> {
    try {
      const response = await this.flightApiClient.get<IFlightInfo[]>(
        `${this.apiBase}/Available`
      );
      return response;
    } catch (error) {
      console.error(error);
    }
  }

  async SearchFlights(
    orig: string,
    dest: string
  ): Promise<IFlightInfo[] | undefined> {
    try {
      const response = await this.flightApiClient.get<IFlightInfo[]>(
        `${this.apiBase}/Search?origin=${orig}&destination=${dest}`
      );
      return response;
    } catch (error) {
      console.error(error);
    }
  }

  async createFlight(object: ICreateFlight): Promise<boolean> {
    try {
      await this.flightApiClient.post<ICreateFlight, any>(
        `${this.apiBase}`,
        object
      );
      return true;
    } catch (error) {
      console.error(error);
      return false;
    }
  }

  async updateFlight(
    Flight_Id: string,
    object: IUpdateFlight
  ): Promise<boolean> {
    try {
      await this.flightApiClient.put<IUpdateFlight, any>(
        `${this.apiBase}/${Flight_Id}`,
        object
      );
      return true;
    } catch (error) {
      console.error(error);
      return false;
    }
  }

  async deleteFlight(Flight_Id: string): Promise<boolean> {
    try {
      await this.flightApiClient.delete<any>(`${this.apiBase}/${Flight_Id}`);
      return true;
    } catch (error) {
      console.error(error);
      return false;
    }
  }
}

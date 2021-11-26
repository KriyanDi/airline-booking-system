import { IAirport, ICreateAirport, IUpdateAirport } from "./types";
import appConfig from "../../appConfig";
import { IApiClient } from "../../api/ApiClient";

export interface IAirportApiClient {
  getAirports(): Promise<IAirport[] | undefined>;
  getAirport(Airport_Id: string): Promise<IAirport | undefined>;
  createAirport(object: ICreateAirport): Promise<boolean>;
  updateAirport(Airport_Id: string, object: IUpdateAirport): Promise<boolean>;
  deleteAirport(Airport_Id: string): Promise<boolean>;
}

export class AirportApiClient implements IAirportApiClient {
  apiBase: string;
  airportApiClient: IApiClient;

  constructor(airportApiClient: IApiClient) {
    this.apiBase = appConfig.airportApiBase;
    this.airportApiClient = airportApiClient;
  }

  async getAirports(): Promise<IAirport[] | undefined> {
    try {
      const response = await this.airportApiClient.get<IAirport[]>(
        `${this.apiBase}`
      );
      return response;
    } catch (error) {
      console.error(error);
    }
  }

  async getAirport(Airport_Id: string): Promise<IAirport | undefined> {
    try {
      const response = await this.airportApiClient.get<IAirport>(
        `${this.apiBase}/${Airport_Id}`
      );
      return response;
    } catch (error) {
      console.error(error);
    }
  }

  async createAirport(object: ICreateAirport): Promise<boolean> {
    try {
      await this.airportApiClient.post<ICreateAirport, any>(
        `${this.apiBase}`,
        object
      );
      return true;
    } catch (error) {
      console.error(error);
      return false;
    }
  }

  async updateAirport(
    Airport_Id: string,
    object: IUpdateAirport
  ): Promise<boolean> {
    try {
      await this.airportApiClient.put<IUpdateAirport, any>(
        `${this.apiBase}/${Airport_Id}`,
        object
      );
      return true;
    } catch (error) {
      console.error(error);
      return false;
    }
  }

  async deleteAirport(Airport_Id: string): Promise<boolean> {
    try {
      await this.airportApiClient.delete<any>(`${this.apiBase}/${Airport_Id}`);
      return true;
    } catch (error) {
      console.error(error);
      return false;
    }
  }
}

import { IAirline, ICreateAirline, IUpdateAirline } from "./types";
import appConfig from "../../appConfig";
import { IApiClient } from "../../api/ApiClient";

export interface IAirlineApiClient {
  getAirlines(): Promise<IAirline[] | undefined>;
  getAirline(Airline_Id: string): Promise<IAirline | undefined>;
  createAirline(object: ICreateAirline): Promise<boolean>;
  updateAirline(Airline_Id: string, object: IUpdateAirline): Promise<boolean>;
  deleteAirline(Airline_Id: string): Promise<boolean>;
}

export class AirlineApiClient implements IAirlineApiClient {
  apiBase: string;
  airlineApiClient: IApiClient;

  constructor(airlineApiClient: IApiClient) {
    this.apiBase = appConfig.airlineApiBase;
    this.airlineApiClient = airlineApiClient;
  }

  async getAirlines(): Promise<IAirline[] | undefined> {
    try {
      const response = await this.airlineApiClient.get<IAirline[]>(
        `${this.apiBase}`
      );
      return response;
    } catch (error) {
      console.error(error);
    }
  }

  async getAirline(Airline_Id: string): Promise<IAirline | undefined> {
    try {
      const response = await this.airlineApiClient.get<IAirline>(
        `${this.apiBase}/${Airline_Id}`
      );
      return response;
    } catch (error) {
      console.error(error);
    }
  }

  async createAirline(object: ICreateAirline): Promise<boolean> {
    try {
      await this.airlineApiClient.post<ICreateAirline, any>(
        `${this.apiBase}`,
        object
      );
      return true;
    } catch (error) {
      console.error(error);
      return false;
    }
  }

  async updateAirline(
    Airline_Id: string,
    object: IUpdateAirline
  ): Promise<boolean> {
    try {
      await this.airlineApiClient.put<IUpdateAirline, any>(
        `${this.apiBase}/${Airline_Id}`,
        object
      );
      return true;
    } catch (error) {
      console.error(error);
      return false;
    }
  }

  async deleteAirline(Airline_Id: string): Promise<boolean> {
    try {
      await this.airlineApiClient.delete<any>(`${this.apiBase}/${Airline_Id}`);
      return true;
    } catch (error) {
      console.error(error);
      return false;
    }
  }
}

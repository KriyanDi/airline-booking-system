import { IApiClient } from "../../api/ApiClient";
import appConfig from "../../appConfig";
import {
  ICreateFlightSection,
  IFlightSection,
  ISeatclass,
  ISeat,
} from "./types";

export interface IFlightSectionApiClient {
  getFlightSection(
    Flight_Id: string,
    Seatclass_Id: string
  ): Promise<IFlightSection | undefined>;

  getAddedSeatclasses(Flight_Id: string): Promise<ISeatclass | undefined>;
  getRemainingSeatclasses(Flight_Id: string): Promise<ISeatclass | undefined>;

  getAllSeats(
    Flight_Id: string,
    Seatclass_Id: string
  ): Promise<ISeat | undefined>;

  getFreeSeats(
    Flight_Id: string,
    Seatclass_Id: string
  ): Promise<ISeat | undefined>;

  createFlightSection(object: ICreateFlightSection): Promise<boolean>;

  deleteFlightSection(
    Flight_Id: string,
    Seatclass_Id: string
  ): Promise<boolean>;
}

export class FlighSectionApiClient implements IFlightSectionApiClient {
  apiBase: string;
  flightSectionApiClient: IApiClient;

  constructor(flightSectionApiClient: IApiClient) {
    this.apiBase = appConfig.flightSectionApiBase;
    this.flightSectionApiClient = flightSectionApiClient;
  }

  async getFlightSection(
    Flight_Id: string,
    Seatclass_Id: string
  ): Promise<IFlightSection | undefined> {
    try {
      const response = await this.flightSectionApiClient.get<IFlightSection>(
        `${this.apiBase}?flight_id=${Flight_Id}&seatclass_id=${Seatclass_Id}`
      );
      return response;
    } catch (error) {
      console.log(error);
    }
  }

  async getAddedSeatclasses(
    Flight_Id: string
  ): Promise<ISeatclass | undefined> {
    try {
      const response = await this.flightSectionApiClient.get<ISeatclass>(
        `${this.apiBase}/AddedSeatclasses/${Flight_Id}`
      );
      return response;
    } catch (error) {
      console.log(error);
    }
  }

  async getRemainingSeatclasses(
    Flight_Id: string
  ): Promise<ISeatclass | undefined> {
    try {
      const response = await this.flightSectionApiClient.get<ISeatclass>(
        `${this.apiBase}/NotAddedSeatclasses/${Flight_Id}`
      );
      return response;
    } catch (error) {
      console.log(error);
    }
  }

  async getAllSeats(
    Flight_Id: string,
    Seatclass_Id: string
  ): Promise<ISeat | undefined> {
    try {
      const response = await this.flightSectionApiClient.get<ISeat>(
        `${this.apiBase}/AllSeats?flight_id=${Flight_Id}&seatclass_id=${Seatclass_Id}`
      );
      return response;
    } catch (error) {
      console.log(error);
    }
  }

  async getFreeSeats(
    Flight_Id: string,
    Seatclass_Id: string
  ): Promise<ISeat | undefined> {
    try {
      const response = await this.flightSectionApiClient.get<ISeat>(
        `${this.apiBase}/FreeSeats?flight_id=${Flight_Id}&seatclass_id=${Seatclass_Id}`
      );
      return response;
    } catch (error) {
      console.log(error);
    }
  }

  async createFlightSection(object: ICreateFlightSection): Promise<boolean> {
    try {
      await this.flightSectionApiClient.post<ICreateFlightSection, any>(
        `${this.apiBase}`,
        object
      );
      return true;
    } catch (error) {
      console.log(error);
      return false;
    }
  }

  async deleteFlightSection(
    Flight_Id: string,
    Seatclass_Id: string
  ): Promise<boolean> {
    try {
      await this.flightSectionApiClient.delete<any>(
        `${this.apiBase}?flight_id=${Flight_Id}&seatclass_id=${Seatclass_Id}`
      );
      return true;
    } catch (error) {
      console.log(error);
      return false;
    }
  }
}

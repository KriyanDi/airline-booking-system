import { IApiClient } from "../../api/ApiClient";
import appConfig from "../../appConfig";
import { ISeat } from "./types";

export interface ISeatApiClient {
  bookSeat(object: ISeat): Promise<boolean>;
  unbookSeat(object: ISeat): Promise<boolean>;
}

export class SeatApiClient implements ISeatApiClient {
  apiBase: string;
  seatApiClient: IApiClient;

  constructor(seatApiClient: IApiClient) {
    this.apiBase = appConfig.seatApiBase;
    this.seatApiClient = seatApiClient;
  }

  async bookSeat(object: ISeat): Promise<boolean> {
    try {
      await this.seatApiClient.post<ISeat, any>(`${this.apiBase}/Book`, object);
      return true;
    } catch (error) {
      console.log(error);
      return false;
    }
  }

  async unbookSeat(object: ISeat): Promise<boolean> {
    try {
      await this.seatApiClient.post<ISeat, any>(
        `${this.apiBase}/Unbook`,
        object
      );
      return true;
    } catch (error) {
      console.log(error);
      return false;
    }
  }
}

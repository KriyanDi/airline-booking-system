import Axios, { AxiosInstance } from "axios";
import appConfig from "../appConfig";

export interface IApiClient {
  get<TResponse>(path: string): Promise<TResponse>;

  post<TRequest, TResponse>(
    path: string,
    object: TRequest,
    config?: any
  ): Promise<TResponse>;

  put<TRequest, TResponse>(path: string, object: TRequest): Promise<TResponse>;

  delete<TResponse>(path: string): Promise<TResponse>;
}

export default class ApiClient implements IApiClient {
  private client: AxiosInstance;

  protected createAxiosClient(): AxiosInstance {
    return Axios.create({
      baseURL: appConfig.basicApiBase,
      headers: {
        "Content-type": "application/json",
      },
    });
  }

  constructor() {
    this.client = this.createAxiosClient();
  }

  async get<TResponse>(path: string): Promise<TResponse> {
    try {
      const response = await this.client.get<TResponse>(path);
      return response.data;
    } catch (error) {
      console.log(error);
    }
    return {} as TResponse;
  }

  async post<TRequest, TResponse>(
    path: string,
    object: TRequest,
    config?: any
  ): Promise<TResponse> {
    try {
      const response = config
        ? await this.client.post<TResponse>(path, object, config)
        : await this.client.post<TResponse>(path, object);
      return response.data;
    } catch (error) {
      console.log(error);
    }
    return {} as TResponse;
  }

  async put<TRequest, TResponse>(
    path: string,
    object: TRequest
  ): Promise<TResponse> {
    try {
      const response = await this.client.put<TResponse>(path, object);
      return response.data;
    } catch (error) {
      console.log(error);
    }
    return {} as TResponse;
  }

  async delete<TResponse>(path: string): Promise<TResponse> {
    try {
      const response = await this.client.delete<TResponse>(path);
      return response.data;
    } catch (error) {
      console.log(error);
    }
    return {} as TResponse;
  }
}

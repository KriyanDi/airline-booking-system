import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import ApiClient, { IApiClient } from "../../core/api/ApiClient";
import {
  AirportApiClient,
  IAirportApiClient,
} from "../../core/services/airport/AirportApiClient";

const apiClient: IApiClient = new ApiClient();
const airportApiClient: IAirportApiClient = new AirportApiClient(apiClient);

const getAirports = createAsyncThunk("airports/getAirports", async () => {
  const response = await airportApiClient.getAirports();
  return response;
});

const airportSlice = createSlice({
  name: `airports`,
  initialState: {},
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(getAirports.fulfilled, (state, action) => {});
    builder.addCase(getAirports.pending, (state, action) => {});
    builder.addCase(getAirports.rejected, (state, action) => {});
  },
});

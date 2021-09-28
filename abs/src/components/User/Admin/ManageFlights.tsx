import axios from "axios";
import React, { useEffect, useState } from "react";
import { Button, Dropdown, Form, Header, Input, Segment } from "semantic-ui-react";
import { useAppDispatch, useAppSelector } from "../../../redux/hooks";
import { fetchAirlines, selectAirlines } from "../../../redux/slices/airline/airlineSlice";
import { fetchAirports, selectAirports } from "../../../redux/slices/airport/airportSlice";
import {
  fetchFlights,
  postFlight,
  selectFlights,
  deleteFlight,
  selectFlightById,
} from "../../../redux/slices/flight/flightSlice";
import ListViewerControl from "../../_common/ListViewerControl";
// import ListViewerControl from "../../_common/ListViewerControl";

const ManageFlights = (props: any) => {
  const dispatch = useAppDispatch();
  const selector = useAppSelector;

  useEffect(() => {
    dispatch(fetchAirports());
    dispatch(fetchAirlines());
    dispatch(fetchFlights());
  }, [dispatch]);

  const [flightId, setFlightId] = useState(-1);
  const [flightNumber, setFlightNumber] = useState("");
  const [airlineId, setAirlineId] = useState(-1);
  const [origAirportId, setOrigAirportId] = useState(-1);
  const [destAirportId, setDestAirportId] = useState(-1);
  const [takeOffDate, setTakeOffDate] = useState(new Date("1970-01-01Z00:00:00:000"));
  const [rows, setRows] = useState(-1);
  const [columns, setColumns] = useState(-1);

  const currentDate = new Date();
  let year = `${currentDate.getFullYear()}`;
  let month = `${currentDate.getMonth() > 10 ? currentDate.getMonth() : `0${currentDate.getMonth()}`}`;
  let day = `${currentDate.getDay() > 10 ? currentDate.getDay() : `0${currentDate.getDay()}`}`;
  const calendarDateLimit = `${year}-${month}-${day}`;

  let airportsOptions = selector(selectAirports).map((airport) => ({
    key: airport.id,
    text: airport.name,
    value: airport.id,
  }));

  let airlinesOptions = selector(selectAirlines).map((airlines) => ({
    key: airlines.id,
    text: airlines.name,
    value: airlines.id,
  }));

  let flightsOptions = selector(selectFlights).map((flight) => ({
    key: flight.id,
    text: flight.flightNumber,
    value: flight.id,
  }));

  let rowsOptions = Array.from({ length: 100 }, (_, i) => i + 1).map((n) => ({
    key: n,
    text: n,
    value: n,
  }));

  let sectionsOptions = selector(selectFlightById(flightId));
  console.log(sectionsOptions);

  const deleteFlightById = (id: number) => dispatch(deleteFlight({ id: id }));

  return (
    <Segment>
      <Segment>
        <Header as="h3" dividing>
          Add Flight
        </Header>
        <Form>
          <Form.Group widths="equal">
            <Form.Field
              control={Input}
              label="Flight Number"
              onChange={(e: any) => {
                setFlightNumber(e.target.value);
              }}
            />
          </Form.Group>

          <Form.Group widths="equal">
            <Form.Field
              control={Dropdown}
              label="Originate Airport"
              clearable
              options={airportsOptions}
              selection
              onChange={(e: any, data: any) => {
                setOrigAirportId(data.value);
              }}
            />

            <Form.Field
              control={Dropdown}
              label="Destination Airport"
              clearable
              options={airportsOptions.filter((airport) => airport.value !== origAirportId)}
              selection
              onChange={(e: any, data: any) => {
                setDestAirportId(data.value);
              }}
            />
          </Form.Group>
          <Form.Group widths="equal">
            <Form.Field
              control={Dropdown}
              label="With Airline"
              clearable
              options={airlinesOptions}
              selection
              onChange={(e: any, data: any) => {
                setAirlineId(data.value);
              }}
            />

            <Form.Field
              control={Input}
              label="Take Off Date:"
              type="date"
              id="start"
              name="trip-start"
              min={calendarDateLimit}
              onChange={(e: any) => {
                setTakeOffDate(new Date(e.target.value));
              }}
            />
          </Form.Group>

          <Button
            onClick={async () => {
              await axios.post(`https://localhost:44318/api/Flight`, {
                flightNumber: flightNumber,
                date: takeOffDate,
                airlineId: airlineId,
                originId: origAirportId,
                destinationId: destAirportId,
              });

              dispatch(fetchFlights());

              // dispatch(
              //   postFlight({
              //     flightNumber: flightNumber,
              //     date: takeOffDate,
              //     airlineId: airlineId,
              //     originId: origAirportId,
              //     destinationId: destAirportId,
              //   })
              // );
            }}
          >
            Add Flight
          </Button>
        </Form>
      </Segment>
      <Segment>
        <Header as="h3" dividing>
          Manage Flights
        </Header>
        <Form>
          <Form.Group widths="equal">
            <Form.Field
              control={Dropdown}
              label="Flight Number"
              clearable
              options={flightsOptions}
              selection
              onChange={(e: any, data: any) => {
                setFlightId(data.value);
              }}
            />
          </Form.Group>

          <Form.Group widths="equal">
            <Form.Field
              control={Dropdown}
              label="Section"
              clearable
              options={[{}]}
              selection
              onChange={(e: any, data: any) => {
                setOrigAirportId(data.value);
              }}
            />
          </Form.Group>

          <Form.Group widths="equal">
            <Form.Field
              control={Dropdown}
              label="Rows"
              clearable
              options={rowsOptions}
              selection
              onChange={(e: any, data: any) => {
                setRows(data.value);
              }}
            />

            <Form.Field
              control={Dropdown}
              label="Columns"
              clearable
              options={colum}
              selection
              onChange={(e: any, data: any) => {
                setColumns(data.value);
              }}
            />
          </Form.Group>

          <Button onClick={async () => {}}>Add Section</Button>
        </Form>
      </Segment>
      <Segment>
        <ListViewerControl
          objectName={`Flights`}
          data={selector(selectFlights).map((flight) => ({ id: flight.id, name: flight.flightNumber }))}
          deleteObjectMethod={deleteFlightById}
        />
      </Segment>
    </Segment>
  );
};

export default ManageFlights;

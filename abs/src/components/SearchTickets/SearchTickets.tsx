import {
  Button,
  Dropdown,
  DropdownItemProps,
  Form,
  Grid,
  Header,
  Icon,
  Label,
  Radio,
} from "semantic-ui-react";
import ApiClient from "../../core/api/ApiClient";
import { AirportApiClient } from "../../core/services/airport/AirportApiClient";
import { AirlineApiClient } from "../../core/services/airline/AirlineApiClient";
import { FlighSectionApiClient } from "../../core/services/flightSection/FlightSectionApiClient";
import { useEffect, useState } from "react";

const SearchTickets = () => {
  const apiClient = new ApiClient();
  const airportApiClient = new AirportApiClient(apiClient);
  const airlineApiClient = new AirlineApiClient(apiClient);
  const flightSectionApiClient = new FlighSectionApiClient(apiClient);

  const [airportsOptions, setAirportsOptions] = useState<DropdownItemProps[] | undefined>([]);
  const [airlinesOptions, setAirlinesOptions] = useState<DropdownItemProps[] | undefined>([]);
  const [seatclassesOptions, setSeatclassesOptions] = useState<DropdownItemProps[] | undefined>([]);

  useEffect(() => {
    airportApiClient
      .getAirports()
      .then((res) =>
        setAirportsOptions(
          res ? res.map((el) => ({ key: el.Airport_Id, value: el.Name, text: el.Name })) : undefined
        )
      );

    airlineApiClient
      .getAirlines()
      .then((res) =>
        setAirlinesOptions(
          res ? res.map((el) => ({ key: el.Airline_Id, value: el.Name, text: el.Name })) : undefined
        )
      );

    flightSectionApiClient
      .getAllSeatclasses()
      .then((res) =>
        setSeatclassesOptions(
          res
            ? res.map((el) => ({ key: el.Seatclass_Id, value: el.Type, text: el.Type }))
            : undefined
        )
      );
  }, []);

  let dummy = [{ key: "", value: "" }];

  return (
    <div>
      <Form>
        <Grid columns={4}>
          <Grid.Row>
            <Grid.Column right>
              <Radio label="One way" />
            </Grid.Column>
            <Grid.Column>
              <Radio label="Two way" />
            </Grid.Column>
            <Grid.Column>
              <Header as="h5">Seatclass:</Header>
              <Dropdown placeholder="" fluid search selection options={seatclassesOptions} />
            </Grid.Column>
          </Grid.Row>

          <Grid.Row>
            <Grid.Column>
              <Header as="h5">Depart from:</Header>
              <Dropdown placeholder="" fluid search selection options={airportsOptions} />
            </Grid.Column>
            <Grid.Column>
              <Header as="h5">Flying to:</Header>
              <Dropdown placeholder="" fluid search selection options={airportsOptions} />
            </Grid.Column>
            <Grid.Column>
              <Header as="h5">Departure date</Header>
              <input type="date" id="takeoff" name="takeoff" />
            </Grid.Column>
            <Grid.Column>
              <Header as="h5">Return date:</Header>
              <input type="date" id="takeoff" name="takeoff" />
            </Grid.Column>
          </Grid.Row>
          <Grid.Row>
            <Grid.Column>
              <Button animated color="blue">
                <Button.Content visible>Search</Button.Content>
                <Button.Content hidden>
                  <Icon name="search" />
                </Button.Content>
              </Button>
            </Grid.Column>
          </Grid.Row>
        </Grid>
      </Form>
    </div>
  );
};

export default SearchTickets;

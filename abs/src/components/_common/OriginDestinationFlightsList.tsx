import React, { useEffect, useState } from "react";
import { Dropdown, Segment } from "semantic-ui-react";
import { useAppDispatch, useAppSelector } from "../../redux/hooks";
import { fetchAirports, selectAirports } from "../../redux/slices/airport/airportSlice";

const OriginDestinationFlightsList = (props: any) => {
  const dispatch = useAppDispatch();
  const selector = useAppSelector;

  let { originId, setOriginId, destinationId, setDestinationId } = props;

  useEffect(() => {
    dispatch(fetchAirports());
  }, [dispatch]);

  let airportsOptions = selector(selectAirports).map((airport) => ({
    key: airport.id,
    text: airport.name,
    value: airport.id,
  }));

  return (
    <div>
      <Segment>
        <h4>Originate Airport</h4>
        <Dropdown
          clearable
          options={airportsOptions}
          selection
          onChange={(e, data) => {
            setOriginId(data.value);
          }}
        />

        <h4>Destination Airport</h4>
        <Dropdown
          clearable
          options={airportsOptions.filter((airport) => airport.value !== originId)}
          selection
          onChange={(e, data) => {
            setOriginId(data.originvalue);
          }}
        />
      </Segment>
    </div>
  );
};

export default OriginDestinationFlightsList;

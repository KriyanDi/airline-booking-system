import axios from "axios";
import * as React from "react";
import { useEffect } from "react";
import { apiAddress } from "./utils/constants";

const Test = () => {
  const [airports, setAirport] = React.useState([]);

  useEffect(() => {
    fetch("https://localhost:44350/api/Airports")
      .then((response) => response.json())
      .then((data) => setAirport(data));
  }, []);

  console.log(airports);

  airports.forEach((airport: any) => console.log(airport));

  return <div>Test</div>;
};

export default Test;

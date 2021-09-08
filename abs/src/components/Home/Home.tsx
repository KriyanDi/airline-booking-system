import React from "react";
import { Link } from "react-router-dom";
import { Button, Segment } from "semantic-ui-react";

const Home = (props: any) => {
  return (
    <div>
      <Segment>
        <h4>Welcome to the Airline Booking System - please proceed to the next step:</h4>
        <Link to="/login">
          <Button primary>Login</Button>
        </Link>

        <Link to="/register">
          <Button secondary>Register</Button>
        </Link>
      </Segment>
    </div>
  );
};

export default Home;

import React, { useState } from "react";
import { Button, Form, Grid, Segment } from "semantic-ui-react";

const Home = ({ handleItemClick }: any) => {
  return (
    <Grid middle aligned centered className="grid">
      <Grid.Column>
        <h2 className="ui image header">
          <div className="content">Welcome to Airline Booking System!</div>
        </h2>

        <Segment stacked secondary>
          <Form>
            <div>
              <h5>Please proceed to the next step:</h5>

              <div className="field">
                <Button
                  fluid
                  large
                  primary
                  onClick={() => handleItemClick("login")}
                >
                  Login
                </Button>
              </div>

              <div className="field">
                <Button
                  fluid
                  large
                  secondary
                  onClick={() => handleItemClick("registration")}
                >
                  Register
                </Button>
              </div>
            </div>
          </Form>
        </Segment>
      </Grid.Column>
    </Grid>
  );
};

export default Home;

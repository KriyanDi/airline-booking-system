import React, { useState } from "react";
import { Link } from "react-router-dom";
import { Button, Form, Grid, Segment } from "semantic-ui-react";
import { useAppDispatch } from "../../../redux/hooks";
import { loginUser } from "../../../redux/slices/user/userSlice";
import "../../User/Login/LoginPage";

const LoginPage = (props: any) => {
  const dispatch = useAppDispatch();

  let { setActiveItem } = props;

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  return (
    <Grid middle aligned centered className="grid">
      <Grid.Column>
        <h2 className="ui image header">
          <div className="content">Login</div>
        </h2>

        <Form>
          <Segment stacked secondary>
            <div className="field">
              <div className="ui left icon input">
                <i className="user icon"></i>
                <input
                  type="text"
                  name="email"
                  placeholder="E-mail address"
                  onChange={(e) => {
                    setEmail(e.target.value);
                  }}
                />
              </div>
            </div>

            <div className="field">
              <div className="ui left icon input">
                <i className="lock icon"></i>
                <input
                  type="password"
                  name="password"
                  placeholder="Password"
                  onChange={(e) => {
                    setPassword(e.target.value);
                  }}
                />
              </div>
            </div>

            <Button fluid large submit onClick={() => dispatch(loginUser({ email: email, password: password }))}>
              Login
            </Button>
          </Segment>

          <div className="ui error message"></div>
        </Form>

        <div className="ui message">
          New to us?{" "}
          <Link to="/register">
            <a href="" onClick={() => setActiveItem("register")}>
              Register
            </a>
          </Link>
        </div>
      </Grid.Column>
    </Grid>
  );
};

export default LoginPage;

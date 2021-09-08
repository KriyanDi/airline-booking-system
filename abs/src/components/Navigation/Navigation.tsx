import React from "react";
import { Menu, Segment } from "semantic-ui-react";
import { Link } from "react-router-dom";

interface NavigationProps {
  activeItem: string;
  setActiveItem: React.Dispatch<React.SetStateAction<string>>;
}

const Navigation = (props: NavigationProps) => {
  let { activeItem, setActiveItem } = props;
  return (
    <Segment inverted>
      <Menu right inverted secondary>
        <Link to="/">
          <Menu.Item
            name="home"
            active={activeItem === "home"}
            onClick={() => {
              setActiveItem("home");
            }}
          />
        </Link>

        <Link to="/login">
          <Menu.Item
            name="login"
            active={activeItem === "login"}
            onClick={() => {
              setActiveItem("login");
            }}
          />
        </Link>

        <Link to="/register">
          <Menu.Item
            name="register"
            active={activeItem === "register"}
            onClick={() => {
              setActiveItem("register");
            }}
          />
        </Link>
      </Menu>
    </Segment>
  );
};

export default Navigation;

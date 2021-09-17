import React from "react";
import { Button, Menu, Segment } from "semantic-ui-react";
import { Link } from "react-router-dom";
import { logout } from "../../redux/slices/user/userSlice";
import { useAppDispatch } from "../../redux/hooks";

const AdminNavigation = (props: any) => {
  const dispatch = useAppDispatch();
  const { activeItem, setActiveItem } = props;

  return (
    <Segment inverted>
      <Menu right inverted secondary>
        <Link to="/manageAirports">
          <Menu.Item
            name="manage airports"
            active={activeItem === "manageAirports"}
            onClick={() => {
              setActiveItem("manageAirports");
            }}
          />
        </Link>

        <Link to="/manageAirlines">
          <Menu.Item
            name="manage arilines"
            active={activeItem === "manageAirlines"}
            onClick={() => {
              setActiveItem("manageAirlines");
            }}
          />
        </Link>

        <Link to="/manageFlights">
          <Menu.Item
            name="manage flights"
            active={activeItem === "manageFlights"}
            onClick={() => {
              setActiveItem("manageFlights");
            }}
          />
        </Link>

        <Link to="/manageTickets">
          <Menu.Item
            name="manage tickets"
            active={activeItem === "manageTickets"}
            onClick={() => {
              setActiveItem("manageTickets");
            }}
          />
        </Link>

        <Menu.Menu position="right">
          <Link to="/">
            <Button
              inverted
              onClick={() => {
                dispatch(logout());
              }}
            >
              Log out
            </Button>
          </Link>
        </Menu.Menu>
      </Menu>
    </Segment>
  );
};

export default AdminNavigation;

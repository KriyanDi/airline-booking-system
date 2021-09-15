import React, { useState } from "react";
import { Button, Menu, Segment } from "semantic-ui-react";
import { Link } from "react-router-dom";
import { logout } from "../../redux/slices/user/userSlice";
import { useAppDispatch } from "../../redux/hooks";

const UserNavigation = (props: any) => {
  const dispatch = useAppDispatch();
  const { activeItem, setActiveItem } = props;

  return (
    <Segment inverted>
      <Menu right inverted secondary>
        <Link to="/book">
          <Menu.Item
            name="book"
            active={activeItem === "book"}
            onClick={() => {
              setActiveItem("book");
            }}
          />
        </Link>

        <Link to="/tickets">
          <Menu.Item
            name="tickets"
            active={activeItem === "tickets"}
            onClick={() => {
              setActiveItem("tickets");
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

export default UserNavigation;

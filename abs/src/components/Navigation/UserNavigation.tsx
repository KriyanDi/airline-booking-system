import React, { useState } from "react";
import { Menu, Segment } from "semantic-ui-react";
import { Link } from "react-router-dom";

const UserNavigation = (props: any) => {
  const { activeItem, setActiveItem } = props;

  setActiveItem("book");

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

        <Link to="/flights">
          <Menu.Item
            name="flights"
            active={activeItem === "flights"}
            onClick={() => {
              setActiveItem("flights");
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
      </Menu>
    </Segment>
  );
};

export default UserNavigation;

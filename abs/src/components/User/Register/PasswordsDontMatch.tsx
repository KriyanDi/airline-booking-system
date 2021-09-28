import React from "react";
import { Message } from "semantic-ui-react";

const PasswordsDontMatch = () => {
  return (
    <Message negative>
      <Message.Header>Passwords do not match</Message.Header>
      <p>Please, make them match!</p>
    </Message>
  );
};

export default PasswordsDontMatch;

import React, { useState } from "react";
import { Button, Form, Header, Input, Segment } from "semantic-ui-react";
import { useAppDispatch } from "../../redux/hooks";

const AddObject = (props: any) => {
  const dispatch = useAppDispatch();
  const { objectName, postMethod } = props;

  const [input, setInput] = useState("");
  const [inputPlaceholder, setPlaceholder] = useState(`Add ${objectName} ...`);

  return (
    <Segment>
      <Header as="h3" dividing>
        Add {objectName}
      </Header>

      <div className="ui fluid action input">
        <input
          type="text"
          placeholder={inputPlaceholder}
          onChange={(e) => {
            setInput(e.target.value);
          }}
        />
        <div
          className="ui button"
          onClick={() => {
            dispatch(postMethod);
            setPlaceholder(`Add ${objectName} ...`);
          }}
        >
          Add
        </div>
      </div>
    </Segment>
  );
};

export default AddObject;

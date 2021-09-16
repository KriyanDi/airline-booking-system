import React, { useState } from "react";
import { Header, Segment } from "semantic-ui-react";

const AddObject = (props: any) => {
  const { objectName, postMethod, postObjectMethod } = props;

  const [input, setInput] = useState("");
  const [inputPlaceholder, setInputPlaceholder] = useState(`Add ${objectName} ...`);

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
            postObjectMethod(input);
            setInputPlaceholder(`Add ${objectName} 111...`);
          }}
        >
          Add
        </div>
      </div>
    </Segment>
  );
};

export default AddObject;

import React from "react";
import { useState } from "react";

const AddElement = ({ elementName, onAdd }: any) => {
  const [inputValue, setInputValue] = useState<string>("");

  const onAddHandler = (): void => {
    onAdd({ name: inputValue });
    setInputValue("");
  };

  let isAddInputValueEnabled = inputValue ? "" : "disabled";

  return (
    <div className="ui form field =">
      <div className="ui action input">
        <input
          type="text"
          value={inputValue}
          placeholder={`${elementName} ...`}
          onChange={(event) => setInputValue(event.target.value)}
        />
        <button
          className={`ui ${isAddInputValueEnabled} button`}
          onClick={() => onAddHandler()}
        >
          Add {elementName}
        </button>
      </div>
    </div>
  );
};

export default AddElement;

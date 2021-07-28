import React from "react";
import { useState } from "react";
import { AddElementProps } from "../../interfaces/propsInterfaces";

const AddElement = ({ elementName, onAdd }: AddElementProps) => {
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
        <button className={`ui ${isAddInputValueEnabled} button`} onClick={() => onAddHandler()}>
          Add {elementName}
        </button>
      </div>
    </div>
  );
};

export default AddElement;

import React, { useState } from "react";

const AddField = ({ objectName, buttonName, onAdd }) => {
  const [inputValue, setInputValue] = useState("");

  const onAddHandler = () => {
    onAdd(inputValue);
    setInputValue("");
  };

  let isAddInputValueEnabled = inputValue ? "" : "disabled";

  return (
    <div className="ui form field =">
      <div className="ui action input">
        <input
          type="text"
          value={inputValue}
          placeholder={`${objectName} ...`}
          onChange={(event) => setInputValue(event.target.value)}
        />
        <button
          className={`ui ${isAddInputValueEnabled} button`}
          onClick={() => onAddHandler()}
        >
          {buttonName}
        </button>
      </div>
    </div>
  );
};

export default AddField;

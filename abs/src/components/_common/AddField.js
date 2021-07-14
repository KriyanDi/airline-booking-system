import React, { useState } from "react";

const AddField = ({ objectName, buttonName, onClick }) => {
  const [value, setValue] = useState("");

  const onClickHandler = () => {
    onClick(value);
    setValue("");
  };

  return (
    <div className="ui form field =">
      <h4 className="ui dividing header">Manage {objectName}</h4>
      <div className="ui action input">
        <input
          type="text"
          placeholder={`${objectName} ...`}
          onChange={(event) => setValue(event.target.value)}
          value={value}
        />
        <button
          className="ui button"
          onClick={value ? () => onClickHandler() : () => {}}
        >{`Add ${buttonName}`}</button>
      </div>
    </div>
  );
};

export default AddField;

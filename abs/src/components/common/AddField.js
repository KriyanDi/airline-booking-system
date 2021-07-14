import React, { useState } from "react";

const AddField = ({ objectName, buttonName, onClick }) => {
  const [value, setValue] = useState("");
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
          onClick={() => {
            onClick(value);
            setValue("");
          }}
        >{`Add ${buttonName}`}</button>
      </div>
    </div>
  );
};

export default AddField;

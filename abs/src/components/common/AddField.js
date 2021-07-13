import React from "react";

const AddField = ({ objectName, buttonName }) => {
  return (
    <div className="ui segment container">
      <div className="ui form field =">
        <h4 class="ui dividing header">Manage {objectName}</h4>
        <div className="ui action input">
          <input type="text" placeholder={`${objectName} ...`} />
          <button className="ui button">{`Add ${buttonName}`}</button>
        </div>
      </div>
    </div>
  );
};

export default AddField;

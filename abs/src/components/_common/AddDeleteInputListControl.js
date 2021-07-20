import React from "react";
import AddField from "../_common/AddField";
import ListViewer from "../_common/ListViewer";

const AddDeleteInputListControl = (props) => {
  const objectName = props.objectName;
  const buttonName = `Add ${props.buttonName}`;

  return (
    <div className="ui segment container">
      <h4 className="ui dividing header">Manage {objectName}</h4>
      <AddField
        objectName={objectName}
        buttonName={buttonName}
        onAdd={props.onAdd}
      />

      <ListViewer
        list={props.list}
        objectName={objectName}
        onDelete={props.onDelete}
      />
    </div>
  );
};

export default AddDeleteInputListControl;

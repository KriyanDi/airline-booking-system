import React from "react";
import AddField from "./AddField";
import ListViewer from "./ListViewer";

const WrapAddFieldListViewer = (props) => {
  return (
    <div className="ui segment container">
      <AddField
        objectName={props.objectName}
        buttonName={props.buttonName}
        onClick={props.onAddClick}
      />
      <ListViewer
        list={props.list}
        objectName={props.objectName}
        onClick={props.onDeleteClick}
      />
    </div>
  );
};

export default WrapAddFieldListViewer;

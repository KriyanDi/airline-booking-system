import React from "react";
import WrapAddFieldListViewer from "./common/WrapAddFieldListViewer";

const AddAirline = (props) => {
  return (
    <WrapAddFieldListViewer
      objectName="Airline"
      buttonName="Airline"
      onAddClick={() => {}}
      onDeleteClick={() => {}}
      list={{}}
    />
  );
};

export default AddAirline;

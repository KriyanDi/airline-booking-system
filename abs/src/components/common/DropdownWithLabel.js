import React from "react";
import Dropdown from "./Dropdown";

const DropdownWithLabel = ({ label }) => {
  return (
    <div className="field">
      <label>{label}</label>
      <Dropdown />
    </div>
  );
};

export default DropdownWithLabel;

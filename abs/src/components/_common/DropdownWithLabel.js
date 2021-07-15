import React from "react";
import Dropdown from "./Dropdown";

const DropdownWithLabel = ({ label, list, onChange }) => {
  return (
    <div className="field">
      <label>{label}</label>
      <Dropdown list={list} onChange={onChange} />
    </div>
  );
};

export default DropdownWithLabel;

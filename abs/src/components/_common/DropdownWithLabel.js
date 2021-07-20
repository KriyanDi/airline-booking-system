import React from "react";
import Dropdown from "./Dropdown";

const DropdownWithLabel = ({
  label,
  list,
  onChange,
  setDefault,
  setSetDefault,
}) => {
  return (
    <div className="field">
      <label>{label}</label>
      <Dropdown
        list={list}
        onChange={onChange}
        setDefault={setDefault}
        setSetDefault={setSetDefault}
      />
    </div>
  );
};

export default DropdownWithLabel;

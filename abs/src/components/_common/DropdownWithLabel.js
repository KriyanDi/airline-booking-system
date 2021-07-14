import React from "react";
import Dropdown from "./Dropdown";

const DropdownWithLabel = ({ label, list }) => {
  console.log("DROP with");
  console.log(list);
  return (
    <div className="field">
      <label>{label}</label>
      <Dropdown list={list} />
    </div>
  );
};

export default DropdownWithLabel;

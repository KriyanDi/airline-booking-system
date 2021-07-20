import React from "react";

const Dropdown = ({ list, onChange, setDefault, setSetDefault }) => {
  setDefault = setDefault === undefined ? false : setDefault;
  setSetDefault = setSetDefault === undefined ? (el) => {} : setSetDefault;

  return (
    <select
      className="ui search dropdown"
      onChange={(event) => {
        onChange(event.target.value ? event.target.value : "");
        setSetDefault(false);
      }}
    >
      <option selected={setDefault ? "selected" : ""} value=""></option>
      {list && list.length
        ? list.map((el, index) => {
            return (
              <option key={index} value={el}>
                {el}
              </option>
            );
          })
        : null}
    </select>
  );
};

export default Dropdown;

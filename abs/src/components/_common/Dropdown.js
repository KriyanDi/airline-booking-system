import React from "react";

const Dropdown = ({ list, onChange }) => {
  return (
    <select
      className="ui search dropdown"
      onChange={(event) => {
        onChange(event.target.value);
      }}
    >
      <option value=""></option>
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

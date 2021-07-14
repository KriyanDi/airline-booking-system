import React from "react";

const Dropdown = ({ defaultName, list }) => {
  console.log(list);
  return (
    <select class="ui search dropdown">
      {list && list.length ? (
        list.map((el) => {
          return <option value={el}>{el}</option>;
        })
      ) : (
        <option value="">empty</option>
      )}
    </select>
  );
};

export default Dropdown;

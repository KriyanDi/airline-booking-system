import React from "react";

const Dropdown = ({ defaultName, list }) => {
  return (
    <div class="ui selection dropdown">
      <input type="hidden" name={defaultName} />
      <i class="dropdown icon"></i>
      <div class="default text">{defaultName}</div>
      <div class="menu">
        {list && list.length
          ? list.map((el) => {
              return (
                <div key={`${el.name}${el.id}`} class="item">
                  {el.name}
                </div>
              );
            })
          : null}
      </div>
    </div>
  );
};

export default Dropdown;

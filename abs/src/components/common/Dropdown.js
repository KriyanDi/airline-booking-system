import React from "react";

const Dropdown = ({ defaultName, list }) => {
  return (
    <div className="ui selection dropdown">
      <input type="hidden" name={defaultName} />
      <i className="dropdown icon"></i>
      <div className="default text">{defaultName}</div>
      <div className="menu">
        {list && list.length
          ? list.map((el) => {
              return (
                <div key={`${el.name}${el.id}`} className="item">
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

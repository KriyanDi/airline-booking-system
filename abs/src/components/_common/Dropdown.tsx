import React from "react";

interface DropdownProps {
  label: string;
  list: any[];
  onChange(value: any): any;
  defaultOption?: boolean;
  setDefaultOption?(value: boolean): void;
}

const Dropdown = ({ label, list, onChange, defaultOption, setDefaultOption }: DropdownProps) => {
  defaultOption = defaultOption ? defaultOption : false;

  return (
    <div className="field">
      <label>{label}</label>
      <select
        className="ui search dropdown"
        onChange={(event) => {
          onChange(event.target.value ? event.target.value : "");
          if (setDefaultOption !== undefined) setDefaultOption(false);
        }}
      >
        <option selected={defaultOption} value=""></option>
        {list && list.length
          ? list.map((el: any, index: number) => {
              return (
                <option key={index} value={el}>
                  {el}
                </option>
              );
            })
          : null}
      </select>
    </div>
  );
};

export default Dropdown;

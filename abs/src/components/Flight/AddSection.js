import React from "react";
import { SEATCLASS } from "../../utils/constants";
import DropdownWithLabel from "../_common/DropdownWithLabel";
import TextInputWithLabel from "../_common/TextInputWithLabel";

const AddSection = (props) => {
  return (
    <div className="ui segment">
      <h5 className="ui dividing header">Add Section</h5>
      <div className="four fields">
        <DropdownWithLabel label="Flight Id:" list={Object.keys(SEATCLASS)} />
        <DropdownWithLabel label="Section:" list={Object.keys(SEATCLASS)} />
        <TextInputWithLabel
          label={"Number of Rows:"}
          placeholder={"Rows ..."}
        />
        <TextInputWithLabel
          label={"Number of Cols:"}
          placeholder={"Cols ..."}
        />
      </div>
      <button className="ui button">Add Section to Flight</button>
    </div>
  );
};

export default AddSection;

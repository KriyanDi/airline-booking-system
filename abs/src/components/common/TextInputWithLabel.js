import React from "react";

const TextInputWithLabel = ({ label, placeholder }) => {
  return (
    <div className="field">
      <label>{label}</label>
      <input type="text" placeholder={placeholder} />
    </div>
  );
};

export default TextInputWithLabel;

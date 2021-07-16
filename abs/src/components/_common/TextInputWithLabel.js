import React from "react";

const TextInputWithLabel = ({ label, placeholder, onChange }) => {
  return (
    <div className="field">
      <label>{label}</label>
      <input
        type="text"
        placeholder={placeholder}
        onChange={(event) => {
          onChange(event.target.value);
        }}
      />
    </div>
  );
};

export default TextInputWithLabel;

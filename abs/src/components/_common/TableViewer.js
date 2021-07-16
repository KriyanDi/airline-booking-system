import React from "react";

const setTableHead = (list) =>
  list && list.length
    ? list.map((el, index) => <th key={index}>{el.toUpperCase()}</th>)
    : null;

const setTableContent = (content, onClick) =>
  content && content.length
    ? content.map((el) => (
        <tr>
          {setRowContent(el)}
          <td className="right aligned">
            <div className="right floated content">
              <div
                className="ui red button"
                onClick={() => {
                  onClick(el.id);
                }}
              >
                Delete
              </div>
            </div>
          </td>
        </tr>
      ))
    : null;

const setRowContent = (data) => {
  let keys = Object.keys(data);
  return keys.map((key) => <td>{data[`${key}`]}</td>);
};

const getObjectKeys = (object) => (object ? Object.keys(object) : null);

const TableViewer = ({ content, onClick }) => {
  let keys = content ? getObjectKeys(content[0]) : null;

  return (
    <table className="ui unstackable table">
      <thead>
        <tr>
          {setTableHead(keys)}
          <th key="button" className="right aligned"></th>
        </tr>
      </thead>
      <tbody>{setTableContent(content, onClick)}</tbody>
    </table>
  );
};

export default TableViewer;

import React from "react";

const setTableHead = (list) =>
  list && list.length
    ? list.map((el, index) => <th key={index}>{el.toUpperCase()}</th>)
    : null;

const setTableContent = (content, onDelete) =>
  content && content.length
    ? content.map((el, index) => (
        <tr key={index}>
          {setRowContent(el)}
          {onDelete !== undefined ? (
            <td key={index} className="right aligned">
              <div className="right floated content">
                <div
                  className="ui red button"
                  onClick={() => {
                    onDelete(el);
                  }}
                >
                  Delete
                </div>
              </div>
            </td>
          ) : null}
        </tr>
      ))
    : null;

const setRowContent = (data) => {
  let keys = Object.keys(data);
  return keys.map((key, index) => <td key={index}>{data[`${key}`]}</td>);
};

const getObjectKeys = (object) => (object ? Object.keys(object) : null);

const TableViewer = ({ content, onDelete }) => {
  let keys = content ? getObjectKeys(content[0]) : null;

  return (
    <table className="ui unstackable table">
      <thead>
        <tr key="head">
          {setTableHead(keys)}
          <th key="button" className="right aligned"></th>
        </tr>
      </thead>
      <tbody>{setTableContent(content, onDelete)}</tbody>
    </table>
  );
};

export default TableViewer;

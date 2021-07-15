import React from "react";

const tableHeadList = (list) =>
  list && list.length
    ? list.map((el) => <th key={el.id}>{el.toUpperCase()}</th>)
    : null;

const tableContentList = (content, onClick) =>
  content && content.length
    ? content.map((el) => (
        <tr>
          {tableRowContent(el)}
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

const tableRowContent = (data) => {
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
          {tableHeadList(keys)}
          <th key="button" className="right aligned"></th>
        </tr>
      </thead>
      <tbody>{tableContentList(content, onClick)}</tbody>
    </table>
  );
};

export default TableViewer;

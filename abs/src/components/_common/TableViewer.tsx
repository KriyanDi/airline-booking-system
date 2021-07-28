import React from "react";
import { TableViewerProps } from "../../interfaces/propsInterfaces";

const getObjectKeys = (object: any) => (object ? Object.keys(object) : null);

const setTableHead = (list: any) =>
  list && list.length ? list.map((el: any, index: number) => <th key={index}>{el.toUpperCase()}</th>) : null;

const setRowContent = (data: any) => {
  let keys = Object.keys(data);
  return keys.map((key, index) => <td key={index}>{data[`${key}`]}</td>);
};

const setTableContent = (content: any, onDelete?: (el: any) => void) =>
  content && content.length
    ? content.map((el: any, index: number) => (
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

const TableViewer = ({ content, onDelete }: TableViewerProps) => {
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

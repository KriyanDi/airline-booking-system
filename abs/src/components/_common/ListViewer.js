import React from "react";

const contentResult = (objectName, el) => {
  if (objectName === "Airport") return `🏡 ${el.name}`;
  else if (objectName === "Airline") return `✈️ ${el.name}`;
  else if (objectName === "Flight Id") return `📋 ${el.name}`;
  else return `${el}`;
};

const ListViewer = ({ list, objectName, onClick }) => {
  return (
    <div className="ui segment">
      <h4 className="ui dividing grey header">{objectName}s</h4>
      <div className="ui middle aligned divided list">
        {list && list.length
          ? list.map((el) => {
              return (
                <div key={el.id} className="item">
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
                  <div className="content">{contentResult(objectName, el)}</div>
                </div>
              );
            })
          : null}
      </div>
    </div>
  );
};

export default ListViewer;

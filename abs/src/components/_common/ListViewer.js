import React from "react";

const contentResult = (objectName, el) => {
  if (objectName === "Airports") return `🏡 ${el.name}`;
  else if (objectName === "Airlines") return `✈️ ${el.name}`;
  else if (objectName === "Flight Ids") return `📋 ${el.name}`;
  else return `${el}`;
};

const createListItemWithDeleteButton = (objectName, el, onDelete) => {
  return (
    <div key={el.id} className="item">
      <div className="right floated content">
        <div
          className="ui red button"
          onClick={() => {
            onDelete(el.id);
          }}
        >
          Delete
        </div>
      </div>
      <div className="content">{contentResult(objectName, el)}</div>
    </div>
  );
};

const ListViewer = ({ list, objectName, onDelete }) => {
  return (
    <div className="ui segment">
      <h4 className="ui dividing grey header">{objectName}</h4>
      <div className="ui middle aligned divided list">
        {list && list.length
          ? list.map((el) => {
              return createListItemWithDeleteButton(objectName, el);
            })
          : null}
      </div>
    </div>
  );
};

export default ListViewer;

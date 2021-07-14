import React from "react";

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
                  <div className="content">
                    {objectName === "Airport" ? "🏡" : "✈️"} {el.name}
                  </div>
                </div>
              );
            })
          : null}
      </div>
    </div>
  );
};

export default ListViewer;

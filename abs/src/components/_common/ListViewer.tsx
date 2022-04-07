import React from "react";

interface ListViewerProps {
  list: any[];
  title: string;
  onDelete?(el: any): void;
}

const contentResult = (title: string, el: { name: string }) => {
  switch (title) {
    case "Airports":
      return `🏡 ${el.name}`;
    case "Airlines":
      return `✈️ ${el.name}`;
    case "Flight Ids":
      return `📋 ${el.name}`;
    default:
      return `${el}`;
  }
};

const createListItem = (
  title: string,
  el: any,
  onDelete?: (el: any) => void
) => {
  return (
    <div key={el.id} className="item">
      {onDelete ? (
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
      ) : null}
      <div className="content">{contentResult(title, el)}</div>
    </div>
  );
};

const ListViewer = ({ list, title, onDelete }: ListViewerProps) => {
  return (
    <div className="ui segment">
      <h4 className="ui dividing grey header">{title} List</h4>
      <div className="ui middle aligned divided list">
        {list && list.length
          ? list.map((el: any) => {
              return (
                <div key={el.id} className="item">
                  {onDelete ? (
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
                  ) : null}
                  <div className="content">{contentResult(title, el)}</div>
                </div>
              );
            })
          : null}
      </div>
    </div>
  );
};

export default ListViewer;

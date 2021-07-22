import React from "react";
import AddElement from "../_common/AddElement";
import ListViewer from "../_common/ListViewer";

interface ManageElementProps {
  elementName: string;
  list: any[];
  onAdd(name: string): void;
  onDelete(el: any): void;
}

const ManageElement = ({ elementName, list, onAdd, onDelete }: ManageElementProps) => {
  return (
    <div className="ui segment container">
      <h4 className="ui dividing header">Manage {elementName}</h4>
      <AddElement elementName={elementName} onAdd={onAdd} />
      <ListViewer list={list} title={elementName} onDelete={onDelete} />
    </div>
  );
};

export default ManageElement;

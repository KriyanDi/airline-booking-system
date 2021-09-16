import React from "react";
import Segment from "semantic-ui-react/dist/commonjs/elements/Segment";
import AddObject from "./AddObject";
import ListViewerControl from "./ListViewerControl";

const ManageObject = (props: any) => {
  const { objectName, data, deleteObjectMethod, postObjectMethod } = props;

  return (
    <Segment>
      <AddObject objectName={`${objectName}`} postObjectMethod={postObjectMethod} />
      <ListViewerControl objectName={`${objectName}`} data={data} deleteObjectMethod={deleteObjectMethod} />
    </Segment>
  );
};

export default ManageObject;

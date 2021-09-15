import React from "react";
import Segment from "semantic-ui-react/dist/commonjs/elements/Segment";
import { useAppSelector } from "../../../redux/hooks";
import AddObject from "../../_common/AddObject";
import ListViewerControl from "../../_common/ListViewerControl";

const ManageAirports = (props: any) => {
  const selector = useAppSelector;

  return (
    <Segment>
      <AddObject objectName="Airports" />
      <ListViewerControl />
    </Segment>
  );
};

export default ManageAirports;

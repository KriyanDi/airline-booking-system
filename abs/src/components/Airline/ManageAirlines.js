import React from "react";
import AddField from "../_common/AddField";
import ListViewer from "../_common/ListViewer";
import { connect } from "react-redux";
import { selectAirlines } from "../../utils/selectors";
import { createAirline, deleteAirline } from "../../actions/airlineActions";

const ManageAirlines = (props) => {
  const objectName = "Airlines";
  const buttonName = `Add ${objectName}`;

  return (
    <div className="ui segment container">
      <h4 className="ui dividing header">Manage {objectName}</h4>
      <AddField
        objectName={objectName}
        buttonName={buttonName}
        onAdd={props.createAirline}
      />

      <ListViewer
        list={props.airlines}
        objectName={objectName}
        onDelete={props.deleteAirline}
      />
    </div>
  );
};

const mapStateToProps = (state) => {
  const airlines = selectAirlines(state);
  return { airlines };
};

export default connect(mapStateToProps, { createAirline, deleteAirline })(
  ManageAirlines
);

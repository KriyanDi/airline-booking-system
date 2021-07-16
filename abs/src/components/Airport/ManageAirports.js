import React from "react";
import AddField from "../_common/AddField";
import ListViewer from "../_common/ListViewer";
import { connect } from "react-redux";
import { selectAirports } from "../../utils/selectors";
import { createAirport, deleteAirport } from "../../actions/airportActions";

const ManageAirports = (props) => {
  const objectName = "Airports";
  const buttonName = `Add ${objectName}`;

  return (
    <div className="ui segment container">
      <h4 className="ui dividing header">Manage {objectName}</h4>
      <AddField
        objectName={objectName}
        buttonName={buttonName}
        onAdd={props.createAirport}
      />

      <ListViewer
        list={props.airports}
        objectName={objectName}
        onDelete={props.deleteAirport}
      />
    </div>
  );
};

const mapStateToProps = (state) => {
  const airports = selectAirports(state);
  return { airports };
};

export default connect(mapStateToProps, { createAirport, deleteAirport })(
  ManageAirports
);

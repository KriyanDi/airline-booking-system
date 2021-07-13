import React from 'react';

const AddField = ({objectName, buttonName}) => {
    return (
        <div className="ui form field segment">
            <h3 className="ui header">Manage {objectName}</h3>
            <div className="ui action input">
                <input type="text" placeholder={`${objectName} ...`} />
                <button className="ui button">{`Add ${buttonName}`}</button>
            </div>
        </div>
    );
}

export default AddField;
import React from 'react';
import AddAirline from './components/AddAirline';
import AddAirport from './components/AddAirport';

const App = () => {
    return (
        <div className="ui form attached segment">
            <AddAirport />
            <AddAirline />
        </div>
    );
}

export default App;
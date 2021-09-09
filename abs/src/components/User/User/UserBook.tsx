import React, { useState } from "react";
import OriginDestinationFlightsList from "../../_common/OriginDestinationFlightsList";

const UserBook = () => {
  const [originId, setOriginId] = useState(-1);
  const [destinationId, setDestinationId] = useState(-1);

  return (
    <OriginDestinationFlightsList
      originId={originId}
      setOriginId={setOriginId}
      destinationId={destinationId}
      setDestinationId={setDestinationId}
    />
  );
};

export default UserBook;

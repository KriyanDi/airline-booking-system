import React, { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../../../redux/hooks";
import { selectAirports, deleteAirport, postAirport, fetchAirports } from "../../../redux/slices/airport/airportSlice";

import ManageObject from "../../_common/ManageObject";

const ManageAirports = (props: any) => {
  const dispatch = useAppDispatch();
  const selector = useAppSelector;

  useEffect(() => {
    dispatch(fetchAirports());
  }, [dispatch]);

  let data = selector(selectAirports);

  const deleteAirportMethod = (id: number) => dispatch(deleteAirport({ id: id }));
  const postObjectMethod = (name: string) => dispatch(postAirport({ name: name }));

  return (
    <ManageObject
      objectName="Airports"
      data={data}
      deleteObjectMethod={deleteAirportMethod}
      postObjectMethod={postObjectMethod}
    />
  );
};

export default ManageAirports;

import axios from "axios";
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

  const deleteAirportMethod = async (id: number) => {
    const response = await axios.delete(`https://localhost:44318/api/Airport/${id}`);

    dispatch(fetchAirports());
    // dispatch(deleteAirport({ id: id }));
  };

  const postObjectMethod = async (name: string) => {
    const response = await axios.post(`https://localhost:44318/api/Airport`, {
      name: name,
    });

    dispatch(fetchAirports());
    // dispatch(postAirport({ name: name }));
  };

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

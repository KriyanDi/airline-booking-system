import React, { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../../redux/hooks";
import { IAirport } from "../../redux/slices/airport/airportInterfaces";
import { deleteAirport, fetchAirports, selectAirports } from "../../redux/slices/airport/airportSlice";
import ObjectListControl from "./ObjectListControl";

const AirportsListManage = (props: any) => {
  const dispatch = useAppDispatch();
  const selector = useAppSelector;

  useEffect(() => {
    dispatch(fetchAirports());
  }, [dispatch]);

  let list = selector(selectAirports);

  const onDelete = (element: { id: number }): void => {
    dispatch(deleteAirport({ id: element.id }));
  };

  return (
    <div>
      <ObjectListControl list={list} onDelete={onDelete} />
    </div>
  );
};

export default AirportsListManage;

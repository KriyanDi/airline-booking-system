import React, { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../../../redux/hooks";
import { deleteAirline, fetchAirlines, postAirline, selectAirlines } from "../../../redux/slices/airline/airlineSlice";

import ManageObject from "../../_common/ManageObject";

const ManageAirlines = (props: any) => {
  const dispatch = useAppDispatch();
  const selector = useAppSelector;

  useEffect(() => {
    dispatch(fetchAirlines());
  }, [dispatch]);

  let data = selector(selectAirlines);

  const deleteAirlineMethod = (id: number) => dispatch(deleteAirline({ id: id }));
  const postObjectMethod = (name: string) => dispatch(postAirline({ name: "TEST" }));

  return (
    <ManageObject
      objectName="Airlines"
      data={data}
      deleteObjectMethod={deleteAirlineMethod}
      postObjectMethod={postObjectMethod}
    />
  );
};

export default ManageAirlines;

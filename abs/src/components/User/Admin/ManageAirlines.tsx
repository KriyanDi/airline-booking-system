import React, { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../../../redux/hooks";
import { deleteAirline, postAirline, selectAirlines } from "../../../redux/slices/airline/airlineSlice";

import ManageObject from "../../_common/ManageObject";

const ManageAirlines = (props: any) => {
  const dispatch = useAppDispatch();
  const selector = useAppSelector;

  let data = selector(selectAirlines);
  const deleteAirlineMethod = (id: number) => dispatch(deleteAirline({ id: id }));
  const postObjectMethod = (name: string) => dispatch(postAirline({ name: name }));

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

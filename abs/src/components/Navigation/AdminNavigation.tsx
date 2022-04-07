import React from "react";
import Navigation from "./Navigation";

const AdminNavigation = () => {
  return Navigation(
    ["manage airports", "manage airlines", "manage flights", "manage sections"],
    null
  );
};

export default AdminNavigation;

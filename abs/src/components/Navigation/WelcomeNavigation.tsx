import React from "react";
import Navigation from "./Navigation";

const WelcomeNavigation = () => {
  return Navigation(["home", "registration", "login"], null);
};

export default WelcomeNavigation;

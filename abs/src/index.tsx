import React from "react";
import { render } from "react-dom";
import App from "./App";
import Test from "./test";

import { enableMapSet } from "immer";
enableMapSet();

//render(<App />, document.getElementById("root"));
render(<Test />, document.getElementById("root"));

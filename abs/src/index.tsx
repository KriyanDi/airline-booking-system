import React from "react";
import { render } from "react-dom";
import AppTest from "./test";

import { enableMapSet } from "immer";
enableMapSet();

render(<AppTest />, document.getElementById("root"));

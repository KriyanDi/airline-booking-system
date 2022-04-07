import React from "react";
import { render } from "react-dom";

import { enableMapSet } from "immer";
import App from "./App";
import { Provider } from "react-redux";
import store from "./_redux/store";
enableMapSet();

render(
  <Provider store={store}>
    <App />
  </Provider>,
  document.getElementById("root")
);

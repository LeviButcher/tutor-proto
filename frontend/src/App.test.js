import React from "react";
import { render, cleanup } from "react-testing-library";
import App from "./App";

afterEach(cleanup);

test("renders without crashing", () => {
  const div = document.createElement("div");
  render(<App />);
});

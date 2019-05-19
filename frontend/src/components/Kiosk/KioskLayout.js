import React from "react";
import styled from "styled-components";
import { AppBar, Typography } from "@material-ui/core";

const KioskLayout = styled.main`
  display: grid;
  grid-template-rows: 1fr 90%;
  grid-gap: 10px;
  height: 100vh;
`;

const Layout = ({ children }) => {
  return (
    <KioskLayout>
      <AppBar position="static">
        <Typography variant="h2" align="center" gutterBottom>
          Welcome to the tutoring center
        </Typography>
      </AppBar>
      {children}
    </KioskLayout>
  );
};

export default Layout;

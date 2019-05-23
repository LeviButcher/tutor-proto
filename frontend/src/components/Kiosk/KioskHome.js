import React from "react";
import { Link } from "@reach/router";
import { Typography } from "@material-ui/core";
import styled from "styled-components";

const CenterContent = styled.div`
  display: grid;
  grid-template-rows: auto;
  grid-template-columns: 1fr 1fr;
  grid-gap: 10px;
  align-items: center;
  justify-content: center;
`;

const HomePage = () => {
  return (
    <CenterContent>
      <Typography variant="h3" align="center">
        <Link to="signin">SignIn</Link>
      </Typography>
      <Typography variant="h3" align="center">
        <Link to="signout">SignOut</Link>
      </Typography>
    </CenterContent>
  );
};

export default HomePage;

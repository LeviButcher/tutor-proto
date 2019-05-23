import React from "react";
import { Drawer, Typography } from "@material-ui/core";
import { Link } from "@reach/router";
import styled from "styled-components";
import PermissionCheck from "../PermissionCheck";

const sideDrawerWidth = "240px";

const DashboardLayout = styled.div`
  display: grid;
  grid-template-columns: ${sideDrawerWidth} 1fr;
`;

const SideDrawer = styled(Drawer)`
  & > div {
    width: ${sideDrawerWidth};
    background: #ccc;
    padding: 10px;
  }
`;

const NavigationGroup = ({ className, children, heading }) => {
  return (
    <div className={className}>
      <Typography variant="h4">{heading}</Typography>
      {children}
      <br />
    </div>
  );
};

const StyledNavigationGroup = styled(NavigationGroup)`
  a {
    display: block;
  }
  text-align: right;
  border-bottom: 1px solid #fff;
  margin-bottom: 20px;
`;

const Layout = ({ children }) => {
  return (
    <DashboardLayout>
      <SideDrawer variant="persistent" anchor="left" open={true}>
        <Typography variant="h2" align="center">
          TCSC
        </Typography>
        <br />
        <StyledNavigationGroup heading="Visits">
          <Link to="#">Sign Ins</Link>
          <Link to="#">Weekly Visits</Link>
        </StyledNavigationGroup>
        <StyledNavigationGroup heading="Reports">
          <Link to="/dashboard/weekly-visists">Weekly Visits</Link>
          <Link to="#">Success Report</Link>
        </StyledNavigationGroup>
        <PermissionCheck userRole="Admin" showError={false}>
          <StyledNavigationGroup heading="Admin">
            <Link to="#">Users</Link>
            <Link to="#">Reasons</Link>
          </StyledNavigationGroup>
        </PermissionCheck>
      </SideDrawer>
      <main>{children}</main>
    </DashboardLayout>
  );
};

export default Layout;

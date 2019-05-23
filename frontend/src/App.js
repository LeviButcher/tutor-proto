import React from "react";
import { Router } from "@reach/router";
import KioskLayout from "./components/Kiosk/KioskLayout";
import KioskHome from "./components/Kiosk/KioskHome";
import SignIn from "./components/Kiosk/SignIn";
import SignOut from "./components/Kiosk/SignOut";
import DashboardLayout from "./components/Dashboard/DashboardLayout";
import PermissionCheck from "./components/PermissionCheck";
import WeeklyVisits from "./components/Dashboard/WeeklyVisits";

function App() {
  return (
    <div className="App">
      <Router>
        <KioskLayout path="/">
          <KioskHome path="/" />
          <SignIn path="/signin" />
          <SignOut path="/signout" />
        </KioskLayout>
        <DashboardLayout path="/dashboard">
          <Intro path="/" />
          <WeeklyVisits path="/weekly-visists" />
          <PermissionCheck path="/admin" userRole="admin">
            <Intro path="/" />
          </PermissionCheck>
        </DashboardLayout>
      </Router>
    </div>
  );
}

function Intro() {
  return <h1>Hello world</h1>;
}

export default App;

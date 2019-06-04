import React from "react";
import { Router } from "@reach/router";
import { KioskLayout, KioskHome, SignIn, SignOut } from "./components/Kiosk/";
import PermissionCheck from "./components/PermissionCheck";
import { DashboardLayout, WeeklyVisits, Home } from "./components/Dashboard/";

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
          <Home path="/" />
          <WeeklyVisits path="/weekly-visists" />
          <PermissionCheck path="/admin" userRole="admin" />
        </DashboardLayout>
      </Router>
    </div>
  );
}

export default App;

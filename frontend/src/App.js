import React from "react";
import { Router } from "@reach/router";
import KioskLayout from "./components/Kiosk/KioskLayout";
import KioskHome from "./components/Kiosk/KioskHome";
import SignIn from "./components/Kiosk/SignIn";
import SignOut from "./components/Kiosk/SignOut";

function App() {
  return (
    <div className="App">
      <Router>
        <KioskLayout path="/">
          <KioskHome path="/" />
          <SignIn path="/signin" />
          <SignOut path="/signout" />
        </KioskLayout>
        <AdminLayout path="/admin">
          <Admin path="/" />
          <Welcome path="/welcome" />
        </AdminLayout>
      </Router>
    </div>
  );
}

function Welcome() {
  return <h1>Hello world</h1>;
}

function Admin() {
  return <h1>secret admin</h1>;
}

function AdminLayout({ children }) {
  return <div>{children}</div>;
}

export default App;

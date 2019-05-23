import React, { useState } from "react";

// Setup for calling backend to check user permissions
const PermissionCheck = ({ children, userRole, showError = true }) => {
  const [permitted] = useState(false);
  if (!permitted)
    return showError ? (
      <div>
        <h1>You do not have access to this part of the site</h1>
      </div>
    ) : (
      <></>
    );

  return <>{children}</>;
};

export default PermissionCheck;

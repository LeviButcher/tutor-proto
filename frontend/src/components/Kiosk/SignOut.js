import React, { useState } from "react";
import { TextField, Typography, Button } from "@material-ui/core";
import { Form, Section } from "../../ui/index.js";
import validateEmail from "../../utils/validateEmail";
import { useIsSignedIn } from "../../hooks";

const SignOut = () => {
  const [email, setEmail] = useState("");
  const [isSignedIn] = useIsSignedIn(email);

  function checkEmail(email) {
    // this should contain what makes sure email is valid, then setEmail in state
    if (validateEmail(email)) {
      setEmail(email);
      console.log(email);
    } else {
      console.log("Invalid email");
    }
  }

  return (
    <Section>
      <Form>
        <header>
          <Typography variant="h3" align="center" gutterBottom>
            Sign Out
          </Typography>
        </header>
        <div>
          <TextField
            name="email"
            label="Email"
            fullWidth
            error={!isSignedIn}
            onChange={e => checkEmail(e.target.value)}
            helperText={
              isSignedIn ? "You are signed in" : "You are not signed in"
            }
            margin="normal"
          />
        </div>
        <Button
          disabled={!isSignedIn}
          color="primary"
          variant="contained"
          align="center"
        >
          Submit
        </Button>
      </Form>
    </Section>
  );
};

export default SignOut;

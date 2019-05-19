import React, { useState } from "react";
import {
  TextField,
  Typography,
  FormControl,
  FormLabel,
  RadioGroup,
  FormControlLabel,
  Radio
} from "@material-ui/core";
import styled from "styled-components";
import { Form } from "../../ui/index.js";
import { useUserInfo, useReasons } from "../../hooks";
import validateEmail from "../../utils/validateEmail";

const CenterContent = styled.div`
  width: 800px;
  margin: auto;
`;

const SignIn = () => {
  const [email, setEmail] = useState("");
  const [user] = useUserInfo(email);
  const [reasons] = useReasons();

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
    <CenterContent>
      <Form>
        <header>
          <Typography variant="h3" align="center" gutterBottom>
            Sign In
          </Typography>
        </header>
        <div>
          <TextField
            name="email"
            label="Email"
            fullWidth
            disabled={user !== undefined}
            helperText="Please type in a valid wvup email"
            margin="normal"
            onChange={e => checkEmail(e.target.value)}
          />
        </div>
        <div>
          <FormControl component="fieldset">
            <FormLabel component="legend">Reason for visiting</FormLabel>
            <RadioGroup aria-label="visitReason" name="reason">
              {reasons &&
                reasons.map(reason => (
                  <FormControlLabel
                    key={reason.id}
                    value={reason.name}
                    control={<Radio />}
                    label={reason.name}
                  />
                ))}
            </RadioGroup>
          </FormControl>
        </div>
        <div>
          {!user && (
            <Typography variant="h5" gutterBottom>
              Enter Email or swipe for class list
            </Typography>
          )}
          {user && (
            <FormControl component="fieldset">
              <FormLabel component="legend">Class visiting for</FormLabel>
              <RadioGroup aria-label="class" name="class">
                {user &&
                  user.courses.map(course => (
                    <FormControlLabel
                      key={course.CRN}
                      value={course.courseName}
                      control={<Radio />}
                      label={course.courseName}
                    />
                  ))}
              </RadioGroup>
            </FormControl>
          )}
        </div>
      </Form>
    </CenterContent>
  );
};

export default SignIn;

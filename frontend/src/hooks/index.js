import { useState, useEffect } from "react";
import {
  getReasons,
  getStudentInfo,
  getIsSignedIn
} from "../services/apicalls";

function useUserInfo(email) {
  const [user, setUser] = useState();
  useEffect(
    () => {
      getStudentInfo(email)
        .then(student => {
          setUser(student);
        })
        .catch(e => {
          setUser();
        });
    },
    [email]
  );
  return [user];
}

function useReasons() {
  const [reasons, setReasons] = useState();
  useEffect(() => {
    getReasons().then(reasons => {
      setReasons(reasons);
    });
  }, []);
  return [reasons];
}

function useIsSignedIn(email) {
  const [isSignedIn, setIsSignedIn] = useState();
  useEffect(
    () => {
      getIsSignedIn(email).then(signedIn => {
        setIsSignedIn(signedIn);
      });
    },
    [email]
  );
  return [isSignedIn];
}

export { useUserInfo, useReasons, useIsSignedIn };

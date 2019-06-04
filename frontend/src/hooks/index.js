import { useState, useEffect, useRef } from "react";
import {
  getReasons,
  getStudentInfo,
  getIsSignedIn
} from "../services/apicalls";
const isEqual = require("lodash.isequal");

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

function useChartOptions(chartOptions, xAxisProp, yAxisProp, data) {
  const [options, setOptions] = useState(chartOptions);
  const [series, setSeries] = useState([]);

  useEffect(
    () => {
      const xaxis = { categories: data.map(datum => datum[xAxisProp]) };
      setSeries([
        {
          name: yAxisProp,
          data: data.map(datum => datum[yAxisProp])
        }
      ]);
      setOptions(o => ({ ...o, xaxis }));
    },
    [chartOptions, xAxisProp, yAxisProp, data]
  );

  return [options, series];
}

function useApiCall(apiCall, args) {
  const [loading, setLoading] = useState(true);
  const [data, setData] = useState();
  const [errors, setErrors] = useState();

  useEffect(() => {
    if (isEqual(previousInputs.current, [apiCall, args])) {
      return;
    }
    apiCall(args)
      .then(data => {
        setData(x => data);
        setLoading(l => false);
      })
      .catch(err => setErrors(err));
    return () => setLoading(true);
  });

  const previousInputs = useRef();
  useEffect(() => {
    previousInputs.current = [apiCall, args];
  });

  return [loading, data, errors];
}

export { useUserInfo, useReasons, useIsSignedIn, useChartOptions, useApiCall };

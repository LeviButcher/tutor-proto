import React, { useState } from "react";
import Chart from "react-apexcharts";
import { getWeeklyVisitsData } from "../../services/apicalls";
import { Section, Form } from "../../ui";
import {
  TextField,
  Button,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow
} from "@material-ui/core";
import { useChartOptions, useApiCall } from "../../hooks";

const chartOptions = {
  options: {
    chart: {
      id: "weekly-visits-line"
    }
  }
};

const WeeklyVisists = () => {
  const [formData, setFormData] = useState({ startDate: "", endDate: "" });
  const [submitted, setSubmitted] = useState(false);

  function handleChange(target) {
    setFormData({
      ...formData,
      [target.name]: target.value
    });
  }

  function handleSubmit(e) {
    console.log(e);
    e.preventDefault();
    setSubmitted(true);
  }

  return (
    <div>
      <div className="mixed-charts">
        <Form color="#fff" onSubmit={handleSubmit}>
          <Section alignItems="Center" justifyContent="space-between">
            <TextField
              label="Start Date"
              value={formData.startDate}
              name="startDate"
              onChange={e => handleChange(e.target)}
              disabled={submitted}
              type="date"
              InputLabelProps={{
                shrink: true
              }}
            />
            <TextField
              label="End Date"
              value={formData.endDate}
              name="endDate"
              onChange={e => handleChange(e.target)}
              disabled={submitted}
              type="date"
              InputLabelProps={{
                shrink: true
              }}
            />
            <Button
              color="primary"
              variant="outlined"
              type="submit"
              disabled={submitted}
            >
              Query Data
            </Button>
          </Section>
        </Form>
        {submitted && (
          <WeeklyVisistsReport
            startDate={formData.startDate}
            endDate={formData.endDate}
          />
        )}
      </div>
    </div>
  );
};

const WeeklyVisistsReport = ({ startDate, endDate }) => {
  const [loading, data, errors] = useApiCall(getWeeklyVisitsData, {
    startDate,
    endDate
  });
  return (
    <Section alignItems="center" justifyContent="space-between">
      {errors && <div>{errors}</div>}
      {!loading && data && (
        <>
          <WeeklyVisistsTable data={data} />
          <WeeklyVisistsChart data={data} />
        </>
      )}
    </Section>
  );
};

const WeeklyVisistsTable = ({ data }) => {
  return (
    <Table>
      <TableHead>
        <TableRow>
          <TableCell>Week</TableCell>
          <TableCell>Visits</TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
        {data.map(datum => (
          <TableRow key={datum.week}>
            <TableCell>{datum.week}</TableCell>
            <TableCell>{datum.visits}</TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
};

const WeeklyVisistsChart = ({ startDate, endDate, data }) => {
  const [options, series] = useChartOptions(
    chartOptions,
    "week",
    "visits",
    data
  );
  return <Chart width="600px" options={options} series={series} type="line" />;
};

export default WeeklyVisists;

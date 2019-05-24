import React from "react";
import Chart from "react-apexcharts";

const chartOptions = {
  options: {
    chart: {
      id: "basic-bar"
    },
    xaxis: {
      categories: [1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999]
    }
  },
  series: [
    {
      name: "series-1",
      data: [30, 40, 45, 50, 49, 60, 70, 91]
    }
  ]
};

const WeeklyVisists = () => {
  return (
    <div>
      <div className="mixed-charts">
        <Chart
          options={chartOptions.options}
          series={chartOptions.series}
          type="line"
        />
      </div>
    </div>
  );
};

export default WeeklyVisists;

"use client";
import React from 'react';
import { Line } from '../../dependencies/chartdeps';

export function LineChartComponent({borderColor = 'rgba(47,97,68, 1)', backgroundColor = 'rgba(47,97,68, 0.3)'}) {
  const labelsary = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

  const data = {
    labels: labelsary,
    datasets: [
      {
        data: labelsary.map(() => Math.floor((Math.random() * 100) + 1)),
      }
    ],
  };

  const options = {
    responsive: true,
    maintainAspectRatio: false,
    updateMode: 'resize',
    plugins: {
      legend: {
        display: false
      },
      title: {
        display: false
      },
      subtitle: {
        display: false
      },
    },
    elements: {
      line: {
        tension: 0,
        borderWidth: 2,
        borderColor: borderColor,
        fill: 'start',
        backgroundColor: backgroundColor
      },
      point: {
        radius: 0,
        hitRadius: 0
      }
    },
    scales: {
      x: {
        display: false
      },
      y: {
        display: false
      }
    }
  };

  return (
    <>
      <Line options={options} data={data} className="mychart mychartline" id="mychartline" />
    </>
  );
}

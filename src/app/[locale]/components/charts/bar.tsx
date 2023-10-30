"use client";
import React from 'react';
import admstyles from '../../styles/admin/admin.module.scss';
import { Bar } from '../../dependencies/chartdeps';

export function BarChartComponent() {
  const labelsary = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

  const data = {
    labels: labelsary,
    datasets: [
      {
        label: 'Websites',
        data: labelsary.map(() => Math.floor((Math.random() * 100) + 1)),
        backgroundColor: 'rgba(220, 53, 69, 0.5)',
      },
      {
        label: 'Softwares',
        data: labelsary.map(() => Math.floor((Math.random() * 100) + 1)),
        backgroundColor: 'rgba(25, 135, 84, 0.5)',
      },
      {
        label: 'Apps',
        data: labelsary.map(() => Math.floor((Math.random() * 100) + 1)),
        backgroundColor: 'rgba(13, 110, 253, 0.5)',
      }
    ],
  };


  const options = {
    responsive: true,
    maintainAspectRatio: false,
    updateMode: 'resize',
    plugins: {
      legend: {
        position: 'top' as const,
      },
      title: {
        display: true,
        text: `Websites, softwares and apps built by long of time (${new Date().getFullYear()})`,
      },
    },
  };

  return (
    <div className={admstyles.subchart}>
      <Bar options={options} data={data} className="mychart" id="mychart" />
    </div>
  );
}

/* eslint-disable @typescript-eslint/no-require-imports */
'use client'
import { useEffect } from "react";

export default function ImportMyPlugins() {
  useEffect(() => {
    require("bootstrap/dist/js/bootstrap.bundle.min.js");
    require("@assets/scripts/popper.min.js");
  }, []);
  return null;
}
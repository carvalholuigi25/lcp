'use client'
import { useEffect } from "react";

export default function ImportMyPlugins() {
  useEffect(() => {
    require("bootstrap/dist/js/bootstrap.bundle.min.js");
    require("public/scripts/popper.min.js");
  }, []);
  return null;
}
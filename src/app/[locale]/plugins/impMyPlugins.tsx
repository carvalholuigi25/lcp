/* eslint-disable @typescript-eslint/no-require-imports */
'use client'
import { useEffect } from "react";

export default function ImportMyPlugins() {
  useEffect(() => {
    async function loadBootstrap() {
      const bootstrap = await import("bootstrap");

      if (typeof window !== "undefined") {
        window.bootstrap = bootstrap;

        // new window.bootstrap.ScrollSpy('.fixpad', {
        //   target: '#mnavbar',
        //   offset: 74,
        //   smoothScroll: true,
        // });

        const elm = document.querySelectorAll('[data-bs-spy="scroll"]');
        
        if(elm) {
          const scspyelmary = [].slice.call(elm);
          scspyelmary.map((scspyelm) => {
            return new window.bootstrap.ScrollSpy(scspyelm, {
              target: elm[0].getAttribute("data-bs-target") || "#mnavbar",
              offset: 74,
              smoothScroll: true,
            });
          });
        }
      }
    }

    async function loadPopper() {
      await import("@popperjs/core");
    }

    loadBootstrap();
    loadPopper();
    require("@assets/scripts/myscripts.js");
    // require("@assets/scripts/popper.min.js");
  }, []);
  return null;
}
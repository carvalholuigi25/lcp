// /** @type {import('next').NextConfig} */
// const nextConfig = {}

// module.exports = nextConfig

// eslint-disable-next-line @typescript-eslint/no-require-imports
const withNextIntl = require('next-intl/plugin')('./src/app/i18n/request.ts');
const ctoutput = process.env.OUTPUTEXP == 0 ? undefined : process.env.OUTPUTEXP == 1 ? 'export' : 'standalone';
const defLocale = process.env.LANG_DEFAULT ?? "en";

const getRedirects = async () => {
  return [
    {
      source: '/',
      destination: '/'+defLocale,
      permanent: true,
    }
  ];
}

const nextConfig = {
    experimental: {
        webpackBuildWorker: true
    },
    reactStrictMode: false,
    output: ctoutput == 'export' ? undefined : ctoutput
}

if(ctoutput !== 'export') {
  nextConfig.redirects = async () => {
    return getRedirects();
  };
}

module.exports = withNextIntl(nextConfig);

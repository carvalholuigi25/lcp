// /** @type {import('next').NextConfig} */
// const nextConfig = {}

// module.exports = nextConfig

// eslint-disable-next-line @typescript-eslint/no-require-imports
const withNextIntl = require('next-intl/plugin')('./src/app/i18n/request.ts');

// eslint-disable-next-line @typescript-eslint/no-require-imports
const myconfig = require('./src/app/myconfig/myconfig.json');
const defLocale = myconfig.languages.langDef ?? "pt";
const ctoutput = process.env.OUTPUTEXP == 0 ? undefined : process.env.OUTPUTEXP == 1 ? 'export' : 'standalone';

const nextConfig = {
    experimental: {
      webpackBuildWorker: true
    },
    reactStrictMode: false,
    output: ctoutput == 'export' ? undefined : ctoutput
}

if(ctoutput !== 'export') {
  nextConfig.redirects = async () => {
    return [
      {
        source: '/(en|en-GB|en-US|es|fr|de|it|pt)/(.*)',
        destination: '/'+defLocale,
        permanent: true,
      }
    ];
  };
}

module.exports = withNextIntl(nextConfig);

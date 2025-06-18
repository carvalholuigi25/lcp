// /** @type {import('next').NextConfig} */
// const nextConfig = {}

// module.exports = nextConfig

// eslint-disable-next-line @typescript-eslint/no-require-imports
const withNextIntl = require('next-intl/plugin')('./src/app/i18n/request.ts');
const defLocale = "en";

module.exports = withNextIntl({
    experimental: {
        webpackBuildWorker: true
    },
    reactStrictMode: false,
    output: process.env.OUTPUTEXP == 0 ? undefined : process.env.OUTPUTEXP == 1 ? 'export' : 'standalone',
    async redirects() {
        return [
          {
            source: '/',
            destination: '/'+defLocale,
            permanent: true,
          }
        ]
    },
});

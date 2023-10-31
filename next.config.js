// /** @type {import('next').NextConfig} */
// const nextConfig = {}

// module.exports = nextConfig

const withNextIntl = require('next-intl/plugin')('./i18n.ts');

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
            destination: '/en',
            permanent: true,
          },
        ]
    },
});

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
          {
            source: '/admin',
            destination: '/en/admin/dashboard',
            permanent: true,
          },
          {
            source: '/admin/dashboard',
            destination: '/en/admin/dashboard',
            permanent: true,
          },
          {
            source: '/admin/projects',
            destination: '/en/admin/projects',
            permanent: true,
          },
          {
            source: '/admin/users',
            destination: '/en/admin/users',
            permanent: true,
          },
          {
            source: '/admin/newsletter',
            destination: '/en/admin/newsletter',
            permanent: true,
          },
          {
            source: '/admin/subscriptions',
            destination: '/en/admin/subscriptions',
            permanent: true,
          },
          {
            source: '/admin/settings',
            destination: '/en/admin/settings',
            permanent: true,
          },
        ]
    },
});

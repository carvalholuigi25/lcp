// /** @type {import('next').NextConfig} */
// const nextConfig = {}

// module.exports = nextConfig

const withNextIntl = require('next-intl/plugin')('./i18n.ts');
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
          },
          {
            source: '/admin',
            destination: '/'+defLocale+'/admin/dashboard',
            permanent: true,
          },
          {
            source: '/admin/dashboard',
            destination: '/'+defLocale+'/admin/dashboard',
            permanent: true,
          },
          {
            source: '/admin/projects',
            destination: '/'+defLocale+'/admin/projects',
            permanent: true,
          },
          {
            source: '/admin/users',
            destination: '/'+defLocale+'/admin/users',
            permanent: true,
          },
          {
            source: '/admin/newsletter',
            destination: '/'+defLocale+'/admin/newsletter',
            permanent: true,
          },
          {
            source: '/admin/subscriptions',
            destination: '/'+defLocale+'/admin/subscriptions',
            permanent: true,
          },
          {
            source: '/admin/settings',
            destination: '/'+defLocale+'/admin/settings',
            permanent: true,
          },
        ]
    },
});

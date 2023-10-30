// /** @type {import('next').NextConfig} */
// const nextConfig = {}

// module.exports = nextConfig

const withNextIntl = require('next-intl/plugin')('./i18n.ts');

module.exports = withNextIntl({
    experimental: {
        webpackBuildWorker: true
    },
    reactStrictMode: false,
    distDir: 'out',
    basePath: process.env.NODE_ENV == 'production' ? '/carvalholuigi25' : '',
    assetPrefix: process.env.NODE_ENV == 'production' ? '/carvalholuigi25/' : '/',
    output: process.env.OUTPUTEXP == 0 ? undefined : process.env.OUTPUTEXP == 1 ? 'export' : 'standalone',
});

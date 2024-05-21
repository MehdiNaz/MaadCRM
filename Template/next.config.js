const nextConfig = {
  reactStrictMode: false,
  swcMinify: true,
  poweredByHeader: false,
  env: {
    API_URL: process.env.API_URL,
  },
  async redirects() {
    return [
      {
        source: '/',
        destination: '/customers',
        permanent: true,
      },
    ]
  },
}

module.exports = nextConfig

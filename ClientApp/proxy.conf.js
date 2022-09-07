const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://[::1]:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://[::1]:7177';

const PROXY_CONFIG = [
  {
    context: [
      "/person",
   ],
    target: target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;

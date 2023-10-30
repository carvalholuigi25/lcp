import createIntlMiddleware from 'next-intl/middleware';
import { NextRequest } from 'next/server';

export default async function middleware(request: NextRequest) {
  const localesary = require('/public/locales/langs.json').langs.map((x: any) => x.value);
  const defaultLocale = request.headers.get('x-default-locale') || 'en';

  const handleI18nRouting = createIntlMiddleware({
    locales: localesary,
    defaultLocale,
    localePrefix: 'always',
    alternateLinks: true,
    localeDetection: true,
  });

  const response = handleI18nRouting(request);
 
  response.headers.set('x-default-locale', defaultLocale);

  return response;
}
 
export const config = {
  // Skip all paths that should not be internationalized. This example skips
  // certain folders and all pathnames with a dot (e.g. favicon.ico)
  // matcher: ['/((?!api|_next|_vercel|.*\\..*).*)']
  matcher: ['/((?!_next|api|backend|_next|_vercel|assets|.*\\..*).*)']
};
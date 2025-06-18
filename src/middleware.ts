import { chain } from '@/middlewares/chain';
import { withI18nMiddleware } from '@/middlewares/withI18nMiddleware';
import { NextRequest, NextResponse } from 'next/server';

export function middleware(request: NextRequest) {
  const headers = new Headers(request.headers);
  headers.set("x-current-path", request.nextUrl.pathname);
  headers.set("x-current-href", request.nextUrl.href);
  return NextResponse.next({
    request: {
      headers: headers,
    },
  });
}

export default chain([withI18nMiddleware]);

export const config = {
  // Match only internationalized pathnames
  matcher: [
    '/',
    '/((?!api|trpc|_next|_vercel|favicon.ico|images|.*\\..*).*)',
    '/(en|pt|en-UK|pt-PT)/:path*',
  ],
};
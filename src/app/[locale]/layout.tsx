import './styles/globals.scss';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-icons/font/bootstrap-icons.min.css';
import 'animate.css';
import ImportMyPlugins from "./plugins/impMyPlugins";
import type { Metadata } from 'next';
import { Inter } from 'next/font/google';
import { notFound } from 'next/navigation';
import { NextIntlClientProvider, useMessages } from 'next-intl';
import { unstable_setRequestLocale } from 'next-intl/server';

const inter = Inter({ subsets: ['latin'] })
const locales = require('/public/locales/langs.json').langs.map((x: any) => x.value);

export const metadata: Metadata = {
  title: 'LCP',
  description: 'Created by Luis Carvalho - &copy; 2023 LCP',
}

export async function generateStaticParams() {
  return require('/public/locales/langs.json').langs.map((x: any) => ({locale: x.value}));
}

export default function RootLayout({
  children,
  params: { locale, theme }
}: {
  children: React.ReactNode,
  params: any
}) {
  const isValidLocale = locales.some((cur: any) => cur === locale);
  if (!isValidLocale) notFound();

  unstable_setRequestLocale(locale);

  return (
    <html lang={locale}>
      <head>
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
      </head>
      <body className={inter.className + " " + `theme theme-${theme ?? 'default'}`} suppressHydrationWarning={true}>
        <NextIntlClientProvider locale={locale} messages={useMessages()}>
          {children}
          <ImportMyPlugins />
        </NextIntlClientProvider>
      </body>
    </html>
  )
}

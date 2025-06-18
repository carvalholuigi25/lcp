/* eslint-disable @typescript-eslint/no-explicit-any */
import './styles/globals.scss';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-icons/font/bootstrap-icons.min.css';
import 'animate.css';
import ImportMyPlugins from "@applocale/plugins/impMyPlugins";
import type { Metadata } from 'next';
import { Inter } from 'next/font/google';
import { notFound } from 'next/navigation';
import { getLocale, getMessages } from 'next-intl/server';
import { NextIntlClientProvider } from 'next-intl';
import { getValueLocales, getValueLocalesWithOnlyLocale } from '../i18n/routing';
import { Suspense } from 'react';
import { getDefLocale } from './helpers/defLocale';

const inter = Inter({ subsets: ['latin'] })
const locales = getValueLocales();

export const metadata: Metadata = {
  title: 'LCP',
  description: 'Created by Luis Carvalho - &copy; 2023 LCP',
}

export async function generateStaticParams() {
  return getValueLocalesWithOnlyLocale();
}

export default async function RootLayout({
  children,
  params
}: Readonly<{
  children: React.ReactNode;
  params: Promise<{ locale: string, theme: string }>;
}>) {
  const alocale = (await params).locale ?? await getLocale() ?? getDefLocale();
  const mytheme = (await params).theme ?? 'default';
  const messages = await getMessages({ locale: alocale });

  const isValidLocale = locales.some((cur: any) => cur === alocale);
  if (!isValidLocale) notFound();

  return (
    <html lang={alocale} suppressHydrationWarning>
      <head>
        <link rel="apple-touch-icon" sizes="180x180" href="/images/favicon/apple-touch-icon.png" />
        <link rel="icon" type="image/png" sizes="32x32" href="/images/favicon/favicon-32x32.png" />
        <link rel="icon" type="image/png" sizes="16x16" href="/images/favicon/favicon-16x16.png" />
        <link rel="manifest" href="/images/favicon/site.webmanifest" />
      </head>
      <body className={inter.className + " " + `theme theme-${mytheme}`} suppressHydrationWarning={true}>
        <NextIntlClientProvider locale={alocale} messages={messages}>
          <Suspense fallback={<div><p>Loading...</p></div>}>
            {children}
          </Suspense>
          <ImportMyPlugins />
        </NextIntlClientProvider>
      </body>
    </html>
  )
}

import './[locale]/styles/globals.scss';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-icons/font/bootstrap-icons.min.css';
import 'animate.css';
import ImportMyPlugins from "./[locale]/plugins/impMyPlugins";
import type { Metadata } from 'next';
import { Inter } from 'next/font/google';
import { notFound } from 'next/navigation';
import { NextIntlClientProvider, useMessages, useNow } from 'next-intl';
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

export default function IndexLayout({
  children,
  params: { locale, theme }
}: {
  children: React.ReactNode,
  params: any
}) {
  const timeZone = 'Europe/Lisbon';
  const isValidLocale = locales.some((cur: any) => cur === locale);
  if (!isValidLocale) notFound();

  unstable_setRequestLocale(locale);

  return (
    <html lang={locale}>
      <body className={inter.className + " " + `theme theme-${theme ?? 'default'}`} suppressHydrationWarning={true}>
        <NextIntlClientProvider locale={locale} messages={useMessages()} timeZone={timeZone} now={useNow()}>
          {children}
          <ImportMyPlugins />
        </NextIntlClientProvider>
      </body>
    </html>
  )
}

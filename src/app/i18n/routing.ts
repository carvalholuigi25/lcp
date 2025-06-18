import { defineRouting } from 'next-intl/routing';
import { Languages } from '@applocale/interfaces/languages';
import langs from '@assets/locales/langs.json';

export const getValueLocales = () => {
  return (langs.langs as Languages[]).map((x: Languages) => x.value);
}

export const getValueLocalesWithOnlyLocale = () => {
  return (langs.langs as Languages[]).map((x: Languages) =>  ({locale: x.value}));
}

export const routing = defineRouting({
  // A list of all locales that are supported
  locales: getValueLocales(),
  // Used when no locale matches
  defaultLocale: "pt",
  localePrefix: {
    mode: 'as-needed'
  },
});
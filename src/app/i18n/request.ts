import {getRequestConfig, GetRequestConfigParams} from 'next-intl/server';
import { routing } from './routing';
 
export default getRequestConfig(async ({requestLocale}: GetRequestConfigParams) => {
  // This typically corresponds to the `[locale]` segment
  let locale = (await requestLocale) ?? "pt";
 
  // Ensure that a valid locale is used
  if (!locale || !routing.locales.includes(locale as string)) {
    locale = routing.defaultLocale;
  }

  const common = (await import(`@assets/locales/${locale}.json`)).default;
 
  return {
    locale,
    messages: {
      ...common
    }
  };
});
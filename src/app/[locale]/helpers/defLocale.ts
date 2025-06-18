import { getFromStorage } from "@applocale/hooks/localstorage";

export const getDefLocale = () => {
    return getFromStorage("lang");
}

export const getLinkLocale = () => {
    return "http://localhost:3000/" + getDefLocale();
}
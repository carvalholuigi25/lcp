export default interface MyConfig {
    general: MyConfigGeneral;
    langs: MyConfigLangs;
}

export interface MyConfigGeneral {
    isAppComingSoon: boolean;
    isAppSecHidden: boolean;
}

export interface MyConfigLangs {
    langDef: string; // "en"
    langMode: string; // specific | all
    langSearchMode: string; // value | region
    langAllowed: string[]; // ["pt", "en", "fr"]
}
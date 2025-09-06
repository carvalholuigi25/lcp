/* eslint-disable @typescript-eslint/no-require-imports */
"use client";

import { useEffect, useState } from 'react';
import myconfig from '@myconfig';

export default function LanguageComponent(seldeflang = "Select the language") {
    const getLang = () => {
        const langs = require('@assets/locales/langs.json');
        const langsMode = myconfig.languages.langMode ?? "all"; // specific | all
        const langsSearchMode = myconfig.languages.langSearchMode ?? "value"; // value | region
        const langsAllowed = myconfig.languages.langAllowed ?? ["pt", "en", "fr"];
        return langsMode == "specific" ? langs.langs.filter(x => langsSearchMode == "value" ? langsAllowed.includes(x.value) : langsAllowed.includes(x.region)) : langs.langs;
    }
    
    const aryLangs = getLang();
    const [lang, setLang] = useState("");

    useEffect(() => {
        if(!location.href.includes(localStorage.getItem("lang"))) {
            setLang(aryLangs[0].value ?? myconfig.languages.langDef ?? "en");
        } else {
            setLang(localStorage.getItem("lang"));
        }
    }, [aryLangs]);

    function changeLanguage(e) {
        localStorage.setItem("lang", e.target.value);
        setLang(e.target.value);
        location.href = "/" + e.target.value;
    }

    const listLangOpts = aryLangs && aryLangs.map((xa) => {
        return ( <option value={xa.value} key={xa.id}>{xa.name}</option> );
    });

    return (
        <select className="lang form-control w-100" name="lang" id="lang" dir="auto" value={lang} onChange={changeLanguage}>
            <option value={""} disabled>{seldeflang ?? "Select the language"}</option>
            {listLangOpts}
        </select>
    );
}
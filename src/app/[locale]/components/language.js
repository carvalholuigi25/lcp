/* eslint-disable @typescript-eslint/no-require-imports */
"use client";

import { useEffect, useState } from 'react';

export default function LanguageComponent() {
    const getLang = () => {
        return require('@assets/locales/langs.json').languages;
    }
    
    const aryLangs = getLang(mylocale);
    const [lang, setLang] = useState("");

    useEffect(() => {
        if(!location.href.includes(localStorage.getItem("lang"))) {
            setLang(aryLangs[0].value ?? process.env.LANG_DEFAULT ?? "en");
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
            <option value={""} disabled>Select the language</option>
            {listLangOpts}
        </select>
    );
}
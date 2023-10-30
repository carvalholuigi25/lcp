"use client";

import React, { useEffect, useState } from 'react';

export function LanguageComponent() {
    const aryLangs = require('/public/locales/langs.json').langs;
    const [lang, setLang] = useState("");

    useEffect(() => {
        if(!location.href.includes(localStorage.getItem("lang"))) {
            setLang(aryLangs[0].value ?? "en");
        } else {
            setLang(localStorage.getItem("lang"));
        }
    }, [aryLangs]);

    function changeLanguage(e) {
        localStorage.setItem("lang", e.target.value);
        setLang(e.target.value);
        location.href = "/" + e.target.value;
    }

    const listLangOpts = aryLangs.map((xa, i) => {
        return ( <option value={xa.value} key={xa.id}>{xa.name}</option> );
    });

    return (
        <select className="lang form-control w-100" name="lang" id="lang" dir="auto" value={lang} onChange={changeLanguage}>
            <option value={""} disabled>Select the language</option>
            {listLangOpts}
        </select>
    );
}
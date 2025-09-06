/* eslint-disable @typescript-eslint/no-require-imports */
"use client";
import Image from 'next/image';
import React, { useEffect, useState } from 'react';
import { getFromStorage, saveToStorage } from '@applocale/hooks/localstorage';
import { useLocale } from 'next-intl';
import myconfig from '@myconfig';

export function FlagsLang({ seldeflang = "Select the language" }) {
    const getLangs = () => {
        const langs = require('@assets/locales/langs.json');
        const langsMode = myconfig.languages.langMode ?? "all"; // specific | all
        const langsSearchMode = myconfig.languages.langSearchMode ?? "value"; // value | region
        const langsAllowed = myconfig.languages.langAllowed ?? ["pt", "en", "fr"];
        return langsMode == "specific" ? langs.langs.filter(x => langsSearchMode == "value" ? langsAllowed.includes(x.value) : langsAllowed.includes(x.region)) : langs.langs;
    }

    const alist = getLangs();

    const [lang, setLang] = useState("");
    const locale = useLocale();

    if(alist) {
        // langs.sort((a, b) => -1 * a.region.localeCompare(b.region)); // it will sort list by descending
        alist.sort((a, b) => a.region.localeCompare(b.region)); // it will sort list by ascending
    }

    useEffect(() => {
        if(!getFromStorage("lang")) {
            saveToStorage("lang", locale);
        }

        var deflang = locale ?? getFromStorage("lang") ?? myconfig.languages.langDef ?? "en";

        if(alist) {
            var curlang = alist.filter(x => x.region == deflang).value ?? deflang;
            setLang(curlang);
        }

        if(document.querySelector('#btnlanglist')) {
            if(document.querySelector('#lang .dropdown-menu .dropdown-item[data-value="'+curlang+'"]')) {
                document.querySelector('#btnlanglist').innerHTML = document.querySelector('#lang .dropdown-menu .dropdown-item[data-value="'+curlang+'"]').innerHTML;
            }
        }
    }, [locale, alist]);

    const changeLanguage = (e) => {
        e.preventDefault();
        var val = e.target.dataset.value;
        localStorage.setItem("lang", val);
        setLang(val);
        location.href = "/" + val;
    }

    const getFlagRegVal = (xa) => {
        const aryusaterms = ['en-US', 'en-us', 'EN-US', 'US', 'us', 'USA', 'usa', 'eua'];
        const aryukterms = ['en-UK', 'en-uk', 'EN-UK', 'UK', 'uk', 'en-GB', 'en-gb', 'EN-GB', 'GB', 'gb'];
        return aryusaterms.includes(xa.region) ? 'us' : aryukterms.includes(xa.region) ? 'gb' : xa.value;
    }

    const listLangOpts = alist.map((xa) => {
        var flagicon = xa.flagimg !== null ? (
            <Image src={xa.flagimg} width={16} height={11} className="image imgflag" alt={xa.name} priority />
        ) : ( 
            <span className={"flag flag-"+(getFlagRegVal(xa))}></span> 
        );

        return (
            <a className={"dropdown-item " + (xa.value == lang ? "active" : "")} href={"/"+xa.value} key={xa.id} dir="auto" data-value={xa.value} onClick={changeLanguage}>
                {flagicon} {xa.name}
            </a>
        );
    });

    return (
        <div id="lang" className="lang">
            <button type="button" className="btn btn-primary dropdown-toggle btnlanglist" id="btnlanglist" dir="auto" data-bs-toggle="dropdown" aria-expanded="false">
                {seldeflang ?? "Select the language"}
            </button>
            <div className="dropdown-menu" aria-labelledby="langlist">
                {listLangOpts}
            </div>
        </div>
    );
}
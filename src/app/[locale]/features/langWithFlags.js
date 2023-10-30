"use client";

import React, { useEffect, useState } from 'react';
import { useLocale } from 'next-intl';
import Image from 'next/image';

export function LanguageWithFlagsComponent() {
    const aryLangs = require('/public/locales/langs.json').langs;
    const [lang, setLang] = useState("");
    const locale = useLocale();

    // aryLangs.sort((a, b) => -1 * a.region.localeCompare(b.region)); // it will sort list by descending
    aryLangs.sort((a, b) => a.region.localeCompare(b.region)); // it will sort list by ascending

    useEffect(() => {
        localStorage.setItem("lang", locale);

        var deflang = localStorage.getItem("lang") ?? locale ?? "en";
        var curlang = aryLangs.filter(x => x.region == deflang).value ?? deflang;
        setLang(curlang);

        if(document.querySelector('#btnlanglist')) {
            if(document.querySelector('#lang .dropdown-menu .dropdown-item[data-value="'+curlang+'"]')) {
                document.querySelector('#btnlanglist').innerHTML = document.querySelector('#lang .dropdown-menu .dropdown-item[data-value="'+curlang+'"]').innerHTML;
            }
        }
    }, [aryLangs, locale]);

    function changeLanguage(e) {
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

    const listLangOpts = aryLangs.map((xa, i) => {
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
                Select the language
            </button>
            <div className="dropdown-menu" aria-labelledby="langlist">
                {listLangOpts}
            </div>
        </div>
    );
}
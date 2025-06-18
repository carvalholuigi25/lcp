/* eslint-disable @typescript-eslint/no-require-imports */
"use client";
import React, { useEffect, useState } from 'react';

export const getThemes = (mylocale) => {
    return require('@assets/themes/data_'+mylocale+'.json').themes;
}

export function ThemeComponent({mylocale, seldeftheme}) {
    const themes = getThemes(mylocale);
    const [theme, setTheme] = useState("default");

    useEffect(() => {
        var deftheme = localStorage.getItem("theme") ?? "default";
        setTheme(deftheme);
        defThemeByClass(deftheme);
    }, []);

    const changeTheme = (e) => {
        localStorage.setItem("theme", e.target.value);
        setTheme(e.target.value);
        defThemeByClass(e.target.value);
    }

    const defThemeByClass = (clname) => {
        if(document.querySelector('.theme')) {
            document.querySelector('.theme').classList.remove("theme-default");
            document.querySelector('.theme').classList.remove("theme-dark");
            document.querySelector('.theme').classList.remove("theme-light");
            document.querySelector('.theme').classList.add("theme-"+clname);
        }
    }

    const listThemeOpts = themes && themes.map((xt) => {
        return (<option value={xt.value} key={xt.id} dir="auto">{xt.name}</option>);
    });

    return (
        <select className="theme form-control w-100" name="theme" id="theme" value={theme} onChange={changeTheme}>
            <option value={""} disabled>{seldeftheme}</option>
            {listThemeOpts}
        </select>
    );
}
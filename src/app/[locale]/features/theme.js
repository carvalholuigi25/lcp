"use client";

import React, { useEffect, useState } from 'react';

export function ThemeComponent({mylocale, seldeftheme}) {
    const aryThemes = require('/public/themes/data_'+mylocale+'.json').themes;
    const [theme, setTheme] = useState("default");

    useEffect(() => {
        var deftheme = localStorage.getItem("theme") ?? "default";
        setTheme(deftheme);
        defThemeByClass(deftheme);
    }, []);

    function changeTheme(e) {
        localStorage.setItem("theme", e.target.value);
        setTheme(e.target.value);
        defThemeByClass(e.target.value);
    }

    function defThemeByClass(clname) {
        if(document.querySelector('.theme')) {
            document.querySelector('.theme').classList.remove("theme-default");
            document.querySelector('.theme').classList.remove("theme-dark");
            document.querySelector('.theme').classList.remove("theme-light");
            document.querySelector('.theme').classList.add("theme-"+clname);
        }
    }

    const listThemeOpts = aryThemes.map((xt, i) => {
        return ( <option value={xt.value} key={xt.id} dir="auto">{xt.name}</option> );
    });

    return (
        <select className="theme form-control w-100" name="theme" id="theme" value={theme} onChange={changeTheme}>
            <option value={""} disabled>{seldeftheme}</option>
            {listThemeOpts}
        </select>
    );
}
"use client";
import React, { useState } from 'react';
import Image from 'next/image';
import { useLocale, useTranslations } from 'next-intl';
import myconfig from '@myconfig';

export default function Navbar() {
    const t = useTranslations('Navbar');

    const [isCollapsed, setIsCollapsed] = useState(false);
    const apphidden = myconfig.general.isAppSecHidden ? " hidden" : "";

    const clickNav = () => {
        setIsCollapsed(!isCollapsed);
    }

    const listLinksNav = [
        { href: "#", label: t('listLinksOpt1'), className: "active", idname: "home" },
        { href: "#features", label: t('listLinksOpt2'), className: "", idname: "features" },
        { href: "#services", label: t('listLinksOpt3'), className: "", idname: "services" },
        { href: "#getourapp", label: t('listLinksOpt4'), className: " " + apphidden, idname: "getourapp" },
        { href: "#about", label: t('listLinksOpt5'), className: "", idname: "about" },
        { href: "#team", label: t('listLinksOpt6'), className: "", idname: "team" },
        { href: "#contacts", label: t('listLinksOpt7'), className: "", idname: "contacts" }
    ];

    return (
        <>
            <nav className="navbar fixed-top navbar-expand-lg bg-body-tertiary mnavbar" id="mnavbar">
                <div className="container-fluid">
                    <a className="navbar-brand" href={`/${useLocale()}`}>
                        <Image
                            className="image mx-auto logosmall"
                            src="/images/logos/logo_compact.svg"
                            alt="LCP"
                            width={100}
                            height={30}
                            priority
                        />
                    </a>
                    <button className="navbar-toggler navtoglinks" type="button" data-bs-toggle="collapse" data-bs-target="#navbarLinks" aria-controls="navbarLinks" aria-expanded="false" aria-label="Toggle navigation" onClick={clickNav}>
                        <i className={`bi bi-${isCollapsed ? "x" : "three-dots"}`}></i>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarLinks">
                        <div className="navbar-nav ms-auto">
                            {listLinksNav && listLinksNav.length > 0 && listLinksNav.map((link, index) => (
                                <a key={index} className={"nav-link " + link.className} id={"lnk" + link.idname} href={link.href} dir="auto">
                                    {link.label}
                                </a>
                            ))}
                        </div>
                    </div>
                </div>
            </nav>
         </>   
    );
}
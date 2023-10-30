"use client";
import React, { useState } from 'react';
import { useTranslations } from 'next-intl';

export default function Navbar() {
    const t = useTranslations('Navbar');

    const [isCollapsed, setIsCollapsed] = useState(false);

    const clickNav = () => {
        setIsCollapsed(!isCollapsed);
    }

    return (
        <>
            <nav className="navbar fixed-top navbar-expand-lg bg-body-tertiary mnavbar" id="mnavbar">
                <div className="container-fluid">
                    <a className="navbar-brand" href="/">LCP</a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarLinks" aria-controls="navbarLinks" aria-expanded="false" aria-label="Toggle navigation" onClick={clickNav}>
                        <i className={`bi bi-${isCollapsed ? "x" : "three-dots"}`}></i>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarLinks">
                        <div className="navbar-nav ms-auto">
                            <a className="nav-link" href="#" dir="auto">{t('listLinksOpt1')}</a>
                            <a className="nav-link" href="#features" dir="auto">{t('listLinksOpt2')}</a>
                            <a className="nav-link" href="#services" dir="auto">{t('listLinksOpt3')}</a>
                            <a className="nav-link" href="#getourapp" dir="auto">{t('listLinksOpt4')}</a>
                            <a className="nav-link" href="#about" dir="auto">{t('listLinksOpt5')}</a>
                            <a className="nav-link" href="#team" dir="auto">{t('listLinksOpt6')}</a>
                            <a className="nav-link" href="#contacts" dir="auto">{t('listLinksOpt7')}</a>
                        </div>
                    </div>
                </div>
            </nav>
         </>   
    );
}
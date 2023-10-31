"use client";
import React, { useState, useEffect } from 'react';
import { useLocale, useTranslations } from 'next-intl';
import { doLogout } from '../../utils/authUtils';

export default function NavbarAdmin() {
    const t = useTranslations('Admin.Navbar');

    const [isCollapsed, setIsCollapsed] = useState(false);
    const [username, setUserName] = useState("");
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    useEffect(() => {
        var jspdataAuth = localStorage.getItem("login") ? JSON.parse(localStorage.getItem("login")) : null;

        if (jspdataAuth !== null) {
            setUserName(jspdataAuth.username);
            setIsLoggedIn(jspdataAuth.isLoggedIn);
        }
    }, [isLoggedIn]);

    const clickNav = () => {
        setIsCollapsed(!isCollapsed);
    }

    const sendLogout = (e) => {
        doLogout(e, username).then((data) => {
            if (localStorage.getItem("login")) {
                localStorage.removeItem("login");
            }

            console.log('Logout succeeded!');
            setUserName("");
            setIsLoggedIn(false);

            location.href = `/${localStorage.getItem("lang")}/admin`;
        }).catch((error) => console.error(error));
    };

    return (
        <>
            <nav className="navbar navbar-expand-lg bg-body-tertiary navbaradm">
                <div className="container-fluid">
                    <button className="btn" type="button" data-bs-toggle="offcanvas" data-bs-target="#menuAdmDashLinks" aria-controls="menuAdmDashLinks">
                        <i className="bi bi-list"></i>
                    </button>
                    <a className="navbar-brand ms-3" href={`/${useLocale()}`} dir="auto">LCP</a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarAdmDash" aria-controls="navbarAdmDash" aria-expanded="false" aria-label="Toggle navigation" onClick={clickNav}>
                        <i className={`bi bi-${isCollapsed ? "x" : "three-dots"}`}></i>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarAdmDash">
                        <div className="navbar-nav ms-auto me-0">
                            <li className="nav-link dropdown" href="#" dir="auto">
                                <button className="btn btn-circle dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i className="bi bi-people"></i>
                                </button>
                                <ul className="dropdown-menu">
                                    <li><span className="dropdown-item" dir="auto">{t('msgLoggedIn', { username: username })}</span></li>
                                    <li><a className="dropdown-item" href="#" dir="auto" onClick={sendLogout}>{t('btnExit')}</a></li>
                                </ul>
                            </li>
                        </div>
                    </div>
                </div>
            </nav>
        </>
    );
}
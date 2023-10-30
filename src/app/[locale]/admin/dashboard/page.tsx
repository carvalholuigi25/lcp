"use client";

import React, { useEffect, useState } from 'react';
import admstyles from '../../styles/admin/admin.module.scss';
import DashboardHome from './home';
import DashboardLogin from './login';

export default function DashboardMain() {
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    useEffect(() => {
        var jspdataAuth = localStorage.getItem("login") ? JSON.parse(localStorage.getItem("login")!) : null;

        if (jspdataAuth !== null) {
            setIsLoggedIn(jspdataAuth.isLoggedIn);
        }

    }, [isLoggedIn]);

    return (
        <main className={admstyles.mainDashboard}>
            {!!isLoggedIn && (
                <DashboardHome />
            )}
            
            {!isLoggedIn && (
                <DashboardLogin />
            )}
        </main>
    )
}
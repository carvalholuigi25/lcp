"use client";

import React, { useEffect, useState } from 'react';
import admstyles from '../../styles/admin/admin.module.scss';
import NavbarAdmin from '../../components/admin/navbar';
import SidebarAdmin from '../../components/admin/sidebar';
import { BarChartComponent, LineChartComponent } from '../../components/charts';
import { useTranslations } from 'next-intl';

export default function DashboardHome() {
    const t = useTranslations('Admin.Dashboard');

    const [username, setUserName] = useState("");
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    function getRandomNumber(min: number, max: number) {
        return (Math.random() * (max - min) + min).toFixed(2);
    }

    useEffect(() => {
        var jspdataAuth = localStorage.getItem("login") ? JSON.parse(localStorage.getItem("login")!) : null;

        if (jspdataAuth !== null) {
            setUserName(jspdataAuth.username);
            setIsLoggedIn(jspdataAuth.isLoggedIn);
        }
    }, [isLoggedIn]);

    const RefreshStats = () => {
        location.reload()
    }

    const calctotalwebsites = getRandomNumber(-100, 100);
    const calctotalsoftwares = getRandomNumber(-100, 100);
    const calctotalapps = getRandomNumber(-100, 100);

    const pstatusweb = parseInt(calctotalwebsites) >= 0 ? "text-success" : "text-danger";
    const pstatussofts = parseInt(calctotalsoftwares) >= 0 ? "text-success" : "text-danger";
    const pstatusapps = parseInt(calctotalapps) >= 0 ? "text-success" : "text-danger";

    return (
        <>
            <NavbarAdmin />
            <SidebarAdmin />
            <div className={admstyles.admdashblk + " p-3"} id={admstyles.admdashblk}>
                <div className={"container-fluid " + admstyles.admcontainer}>
                    <div className="row">
                        <h3 className="mt-3 text-center" dir="auto">{t('title')}</h3>
                        <h4 className="mt-3 text-center">
                            {t('welcome', { 'username': username })}
                        </h4>
                        <div className={admstyles.mcanvas + " mt-3"}>
                            <div className={admstyles.chartcontainer}>
                                <BarChartComponent />
                            </div>
                        </div>
                        <div className={admstyles.admstatsinfo + " my-5 d-block mx-auto text-center"}>
                            <div className="container">
                                <div className="row">
                                    <div className="col-12 col-md-6 col-lg-4 mx-auto">
                                        <div className={"card " + admstyles.mycard + " " + admstyles.cardwebs}>
                                            <div className="card-body">
                                                <div className={admstyles.itemsinfo}>
                                                    <div className={admstyles.txtitems}>
                                                        <span>Websites</span>
                                                        <p className={"percinfo " + pstatusweb}>
                                                            {`${calctotalwebsites+'%'}`}
                                                            <i className={`bi bi-arrow-${parseInt(calctotalwebsites) >= 0 ? 'up' : 'down'}`}></i>
                                                        </p>
                                                    </div>
                                                    <div className={admstyles.numitems}>
                                                        <LineChartComponent borderColor="red" backgroundColor="rgba(255,0,0,.3)" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="col-12 col-md-6 col-lg-4 mx-auto">
                                        <div className={"card " + admstyles.mycard + " " + admstyles.cardsofts}>
                                            <div className="card-body">
                                                <div className={admstyles.itemsinfo}>
                                                    <div className={admstyles.txtitems}>
                                                        <span>Softwares</span> 
                                                        <p className={"percinfo " + pstatussofts}>
                                                            {`${calctotalsoftwares+'%'}`}
                                                            <i className={`bi bi-arrow-${parseInt(calctotalsoftwares) >= 0 ? 'up' : 'down'}`}></i>
                                                        </p>
                                                    </div>
                                                    <div className={admstyles.numitems}>
                                                        <LineChartComponent borderColor="green" backgroundColor="rgba(0,255,0,.3)" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="col-12 col-md-6 col-lg-4 mx-auto">
                                        <div className={"card " + admstyles.mycard + " " + admstyles.cardapps}>
                                            <div className="card-body">
                                                <div className={admstyles.itemsinfo}>
                                                    <div className={admstyles.txtitems}>
                                                        <span>Apps</span> 
                                                        <p className={"percinfo " + pstatusapps}>
                                                            {`${calctotalapps+'%'}`}
                                                            <i className={`bi bi-arrow-${parseInt(calctotalapps) >= 0 ? 'up' : 'down'}`}></i>
                                                        </p>
                                                    </div>
                                                    <div className={admstyles.numitems}>
                                                        <LineChartComponent borderColor="blue" backgroundColor="rgba(0,0,255,.3)" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className={admstyles.admactionbtns}>
                            <button className="btn btn-primary btnref" id="btnref" onClick={RefreshStats}>Refresh</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
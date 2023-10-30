"use client";

import React, { useEffect, useState } from 'react';
import { useTranslations } from 'next-intl';
import Link from 'next/link';
import admstyles from '../../styles/admin/admin.module.scss';
import { doLogin } from '../../utils/authUtils';

export default function DashboardLogin() {
    const t = useTranslations('Admin.Login');

    const [username, setUserName] = useState("");
    const [userpass, setUserPass] = useState("");
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        var jspdataAuth = localStorage.getItem("login") ? JSON.parse(localStorage.getItem("login")!) : null;

        if (jspdataAuth !== null) {
            setUserName(jspdataAuth.username);
            setIsLoggedIn(jspdataAuth.isLoggedIn);
        }

        setIsLoading(false);
    }, [isLoggedIn, isLoading]);

    const handleUserNameChange = (e: any) => {
        setUserName(e.target.value);
    }

    const handleUserPassChange = (e: any) => {
        setUserPass(e.target.value);
    }

    const sendLogin = (e: any) => { 
        doLogin(e, username, userpass).then((data: any) => {
            var mydata = data;
            localStorage.setItem("login", JSON.stringify(mydata.nauthobj));

            if (localStorage.getItem("login")) {
                console.log('Login succeeded!');
                setUserName(mydata.nauthobj.username);
                setUserPass('');
                setIsLoggedIn(true);
                setIsLoading(false);

                location.href = "/admin/dashboard";
            }
        }).catch((error) => console.error(error)) 
    }

    const isAcrylic:number = 2;
    const themeLogBlk = isAcrylic == 1 ? "acrylic" : isAcrylic == 2 ? "mica" : "";

    return (
        <>
            <div className={admstyles.loginblk} id={admstyles.loginblk}>
                <div className={"container " + admstyles.admcontainer}>
                    <div className={"row " + admstyles.sfrm + " " + themeLogBlk}>
                        <div className="col-12">
                            <h3 className="mt-3" dir="auto">{t('title')}</h3>

                            {!!isLoading && (
                                <p className='mt-3 mb-3' dir="auto">{t('txtLoading')}</p>
                            )}

                            {!isLoading && (
                                <>
                                    {!isLoggedIn && (
                                        <form method="post" className={admstyles.frmlogin} id="frmlogin" onSubmit={sendLogin}>
                                            <div className="input-group mt-3">
                                                <label htmlFor="username" dir="auto">{t('lblusername')}</label>
                                                <input type="text" name="username" id="username" dir="auto" className="username form-control w-100" placeholder={t('inpusername')} onChange={handleUserNameChange} value={username} required />
                                            </div>
                                            <div className="input-group mt-3">
                                                <label htmlFor="userpass" dir="auto">{t('lbluserpass')}</label>
                                                <input type="password" name="userpass" id="userpass" dir="auto" className="userpass form-control w-100" placeholder={t('inpuserpass')} onChange={handleUserPassChange} value={userpass} required />
                                            </div>
                                            <div className={"input-group " + admstyles.mbtns}>
                                                <input type="reset" value={t('btnResLog')} dir="auto" className="btn btn-secondary btnResLog" id="btnResLog" />
                                                <input type="submit" value={t('btnSendLog')} dir="auto" className="btn btn-primary btnSendLog ms-2" id="btnSendLog" />
                                            </div>
                                        </form>
                                    )}
                                </>
                            )}

                            <Link className='btn btn-primary btnBack' id='btnBack' dir="auto" href={"/"}>{t('btnBack')}</Link>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
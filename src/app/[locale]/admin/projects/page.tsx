"use client";

import admstyles from '../../styles/admin/admin.module.scss';
import NavbarAdmin from '../../components/admin/navbar';
import SidebarAdmin from '../../components/admin/sidebar';
import { useState, useEffect } from 'react';
import { useTranslations } from 'next-intl';
import DashboardLogin from '../dashboard/login';

export default function AdminProjectsPage() {
  const t = useTranslations('Admin.Projects');

  const [username, setUserName] = useState("");
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  useEffect(() => {
    var jspdataAuth = localStorage.getItem("login") ? JSON.parse(localStorage.getItem("login")!) : null;

    if (jspdataAuth !== null) {
      setUserName(jspdataAuth.username);
      setIsLoggedIn(jspdataAuth.isLoggedIn);
    }
  }, [isLoggedIn]);

  return (
    <>
      {!isLoggedIn && (
        <DashboardLogin />
      )}

      {!!isLoggedIn && (
        <main className={admstyles.mainDashboard}>
          <NavbarAdmin />
          <SidebarAdmin />
          <div className={admstyles.admdashblk + " p-3"} id={admstyles.admdashblk}>
            <div className={"container-fluid " + admstyles.admcontainer}>
              <div className="row">
                <div className="col-12">
                  <p className="hidden">{t('welcome', { 'username': username })}</p>
                  <h1 className='mt-3'><i className="bi bi-kanban me-2"></i>{t('title')}</h1>
                  <p className='mt-3'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Recusandae dolorem quas, distinctio asperiores mollitia ratione dignissimos cumque omnis reiciendis quos veritatis veniam ipsa. Velit illo adipisci, amet corrupti voluptatem laudantium.</p>
                  <a href='/admin/dashboard' className='btn btn-primary btnback mt-3'>{t('btnBack')}</a>
                </div>
              </div>
            </div>
          </div>
        </main>
      )}
    </>
  );
}
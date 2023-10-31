"use client";
import React, { useState } from 'react';
import admstyles from '../../styles/admin/admin.module.scss';
import { usePathname } from 'next/navigation';
import { useTranslations } from 'next-intl';

export default function SidebarAdmin() {
    const lang = localStorage.getItem("lang");
    const t = useTranslations('Admin.Sidebar');

    const pthname = usePathname();
    const aryLinks = [
        { id: 1, name: t('sbaropt1'), href: `/${lang}/admin/projects`, icon: "bi-kanban" },
        { id: 2, name: t('sbaropt2'), href: `/${lang}/admin/users`, icon: "bi-people" },
        { id: 3, name: t('sbaropt3'), href: `/${lang}/admin/newsletter`, icon: "bi-newspaper" },
        { id: 4, name: t('sbaropt4'), href: `/${lang}/admin/subscriptions`, icon: "bi-inbox" },
        { id: 5, name: t('sbaropt5'), href: `/${lang}/admin/settings`, icon: "bi-gear" }
    ];

    const [isCollapsed, setIsCollapsed] = useState(false);

    const clickNav = (e) => {
        e.preventDefault();
        setIsCollapsed(!isCollapsed);
    }

    return (
        <>
            <div className={`offcanvas offcanvas-start ${!!isCollapsed ? "show sidebarCol" : "hiding"} ${admstyles.menuAdmDashLinks}`} tabIndex={-1} id="menuAdmDashLinks" aria-labelledby="menuAdmDashLinksLabel">
                <div className="offcanvas-header">
                    <h5 className="offcanvas-title" id="menuAdmDashLinksLabel" dir="auto"><a href={`${lang}/admin/dashboard`}>LCP</a></h5>
                    <button type="button" className="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                </div>
                <div className="offcanvas-body">
                    <ul className={`nav flex-column ${admstyles.navAdmDashLinks}`}>
                        {
                            aryLinks.map((x, ind) => (
                                <li className="nav-item" key={ind}>
                                    <a className={`nav-link ${!!x.href && pthname.includes(x.href) ? "active" : ""}`} href={x.href} dir="auto" alt={x.name} title={x.name}>
                                        <i className={`bi ${x.icon} me-2`}></i>
                                        <span className="sidelinkname">{x.name}</span>
                                    </a>
                                </li>
                            ))
                        }

                        <li className="nav-item">
                            <a href="#" className="nav-link" onClick={clickNav}>
                                <i className={`bi ${!!isCollapsed ? "bi-chevron-right" : "bi-chevron-left"} me-2`}></i>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </>
    );
}
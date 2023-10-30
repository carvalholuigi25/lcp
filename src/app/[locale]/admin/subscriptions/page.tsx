"use client";

import admstyles from '../../styles/admin/admin.module.scss';
import NavbarAdmin from '../../components/admin/navbar';
import SidebarAdmin from '../../components/admin/sidebar';
import { useState, useEffect } from 'react';
import { useTranslations } from 'next-intl';
import DashboardLogin from '../dashboard/login';

export default function AdminSubscriptionsPage() {
  const t = useTranslations('Admin.Subscriptions');
  const tcur = useTranslations('Currency');
  const cursymb = tcur('symbol') ?? "$";

  const [seltimetype, setSelTimeType] = useState("mo");
  const [username, setUserName] = useState("");
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  useEffect(() => {
    var jspdataAuth = localStorage.getItem("login") ? JSON.parse(localStorage.getItem("login")!) : null;

    if (jspdataAuth !== null) {
      setUserName(jspdataAuth.username);
      setIsLoggedIn(jspdataAuth.isLoggedIn);
    }

    if (localStorage.getItem("selTimeType")) {
      setSelTimeType(localStorage.getItem("selTimeType")!.toString());
    }
  }, [isLoggedIn]);

  const DefSelTimeType = (e: any) => {
    localStorage.setItem("selTimeType", e.target.value);
    setSelTimeType(e.target.value);
  }

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
                  <h1 className='mt-3 text-center'><i className="bi bi-inbox me-2"></i>{t('title')}</h1>

                  <div className={admstyles.membershipblk + " mt-3 p-3"} id="membershipblk">
                    <div className="container">
                      <div className="row">
                        <div className="col-12">
                          <select name="seltimetype" id="seltimetype" className="form-control seltimetype" value={seltimetype} onChange={DefSelTimeType}>
                            <option value="mo">Monthly</option>
                            <option value="an">Annually</option>
                          </select>
                        </div>
                        <div className="col-12 col-md-6 col-lg-4 col-xl-3 mt-3">
                          <div className={"card " + admstyles.cardplan + " " + admstyles.free}>
                            <div className="card-body">
                              <h2 className={"card-title " + admstyles.titleplan}>Free</h2>
                              <h3 className={"card-text " + admstyles.priceplan + " mt-3"}>{cursymb}0,00 / {seltimetype == "mo" ? "month" : "year"}</h3>
                              <p className={"card-text " + admstyles.txtplan + " mt-3"}>This plan includes:</p>
                              <ul className={admstyles.listplan + " mt-3"}>
                                <li><i className={"bi bi-check me-3 " + admstyles.icoplan + " " + admstyles.check}></i><span>Item 1</span></li>
                              </ul>
                              <button className={"btn btn-primary " + admstyles.btnbuyplan + " " + admstyles.btnactive + " mt-3"} id="btnbuyplan1" disabled>You own this plan</button>
                            </div>
                          </div>
                        </div>

                        <div className="col-12 col-md-6 col-lg-4 col-xl-3 mt-3">
                          <div className={"card " + admstyles.cardplan + " " + admstyles.basic}>
                            <div className="card-body">
                              <h2 className={"card-title " + admstyles.titleplan}>Basic</h2>
                              <h3 className={"card-text " + admstyles.priceplan + " mt-3"}>{cursymb}{seltimetype == "mo" ? "5,00 / month" : "10,00 / year"}</h3>
                              <p className={"card-text " + admstyles.txtplan + " mt-3"}>Everthing from free plan, plus this plan includes:</p>
                              <ul className={admstyles.listplan + " mt-3"}>
                                <li><i className={"bi bi-check me-3 " + admstyles.icoplan + " " + admstyles.check}></i><span>Item 1</span></li>
                                <li><i className={"bi bi-check me-3 " + admstyles.icoplan + " " + admstyles.check}></i><span>Item 2</span></li>
                              </ul>
                              <button className={"btn btn-primary " + admstyles.btnbuyplan + " mt-3"} id="btnbuyplan2">Buy</button>
                            </div>
                          </div>
                        </div>

                        <div className="col-12 col-md-6 col-lg-4 col-xl-3 mt-3">
                          <div className={"card " + admstyles.cardplan + " " + admstyles.pro + " " + admstyles.recommendedplan}>
                            <div className="card-body">
                              <h2 className={"card-title " + admstyles.titleplan}>Pro</h2>
                              <h3 className={"card-text " + admstyles.priceplan + " mt-3"}>{cursymb}{seltimetype == "mo" ? "10,00 / month" : "20,00 / year"}</h3>
                              <p className={"card-text " + admstyles.txtplan + " mt-3"}>Everthing from free and basic plans, plus this plan includes:</p>
                              <ul className={admstyles.listplan + " mt-3"}>
                                <li><i className={"bi bi-check me-3 " + admstyles.icoplan + " " + admstyles.check}></i><span>Item 1</span></li>
                                <li><i className={"bi bi-check me-3 " + admstyles.icoplan + " " + admstyles.check}></i><span>Item 2</span></li>
                                <li><i className={"bi bi-check me-3 " + admstyles.icoplan + " " + admstyles.check}></i><span>Item 3</span></li>
                              </ul>
                              <button className={"btn btn-primary " + admstyles.btnbuyplan + " " + admstyles.btnrecommended + " mt-3"} id="btnbuyplan3">Buy</button>
                            </div>
                          </div>
                        </div>

                        <div className="col-12 col-md-6 col-lg-4 col-xl-3 mt-3">
                          <div className={"card " + admstyles.cardplan + " " + admstyles.ultimate}>
                            <div className="card-body">
                              <h2 className={"card-title " + admstyles.titleplan}>Ultimate</h2>
                              <h3 className={"card-text " + admstyles.priceplan + " mt-3"}>{cursymb}{seltimetype == "mo" ? "15,00 / month" : "30,00 / year"}</h3>
                              <p className={"card-text " + admstyles.txtplan + " mt-3"}>Everthing from free, basic and pro plans, plus this plan includes:</p>
                              <ul className={admstyles.listplan + " mt-3"}>
                                <li><i className={"bi bi-check me-3 " + admstyles.icoplan + " " + admstyles.check}></i><span>Item 1</span></li>
                                <li><i className={"bi bi-check me-3 " + admstyles.icoplan + " " + admstyles.check}></i><span>Item 2</span></li>
                                <li><i className={"bi bi-check me-3 " + admstyles.icoplan + " " + admstyles.check}></i><span>Item 3</span></li>
                                <li><i className={"bi bi-check me-3 " + admstyles.icoplan + " " + admstyles.check}></i><span>Item 4</span></li>
                              </ul>
                              <button className={"btn btn-primary " + admstyles.btnbuyplan + " mt-3"} id="btnbuyplan4">Buy</button>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>

                  <div className={admstyles.compareplans + " mt-3 p-3"} id="compareplans">
                    <div className="container">
                      <div className="row">
                        <div className="col-12">
                          <h2 className={admstyles.titleplan}>Compare plans</h2>
                          <div className={"table-responsive " + admstyles.mtblcomplans + " mt-3"}>
                            <table className={"table table-bordered " + admstyles.tblcomplans} id="tblcomplans">
                              <thead className={admstyles.thead}>
                                <tr>
                                  <th>Features</th>
                                  <th>Free</th>
                                  <th>Basic</th>
                                  <th>Pro</th>
                                  <th>Ultimate</th>
                                </tr>
                              </thead>
                              <tbody className={admstyles.tbody}>
                                <tr>
                                  <td>Public</td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                </tr>
                                <tr>
                                  <td>Private</td>
                                  <td><i className={"bi bi-x " + admstyles.icoplan + " " + admstyles.uncheck}></i></td>
                                  <td><i className={"bi bi-x " + admstyles.icoplan + " " + admstyles.uncheck}></i></td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                </tr>
                                <tr>
                                  <td>Permissions</td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                </tr>
                                <tr>
                                  <td>Sharing</td>
                                  <td><i className={"bi bi-x " + admstyles.icoplan + " " + admstyles.uncheck}></i></td>
                                  <td><i className={"bi bi-x " + admstyles.icoplan + " " + admstyles.uncheck}></i></td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                </tr>
                                <tr>
                                  <td>Unlimited members</td>
                                  <td><i className={"bi bi-x " + admstyles.icoplan + " " + admstyles.uncheck}></i></td>
                                  <td><i className={"bi bi-x " + admstyles.icoplan + " " + admstyles.uncheck}></i></td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                </tr>
                                <tr>
                                  <td>Extra security</td>
                                  <td><i className={"bi bi-x " + admstyles.icoplan + " " + admstyles.uncheck}></i></td>
                                  <td><i className={"bi bi-x " + admstyles.icoplan + " " + admstyles.uncheck}></i></td>
                                  <td><i className={"bi bi-x " + admstyles.icoplan + " " + admstyles.uncheck}></i></td>
                                  <td><i className={"bi bi-check2 " + admstyles.icoplan + " " + admstyles.check}></i></td>
                                </tr>
                              </tbody>
                            </table>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>

                  <div className="container mx-auto text-center mt-3">
                    <div className="col-12">
                      <a href='/admin/dashboard' className='btn btn-primary btnback'>{t('btnBack')}</a>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </main>
      )}
    </>
  );
}
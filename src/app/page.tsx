import { useTranslations } from 'next-intl';
import { unstable_setRequestLocale } from 'next-intl/server';
import Image from 'next/image';
import styles from './[locale]/styles/page/page.module.scss';
import Navbar from "./[locale]/components/navbar";
import Header from './[locale]/components/header';
import Footer from './[locale]/components/footer';
import ContactComponent from './[locale]/components/contact';

export default function Index({ params: {locale} }: { params: any }) {
  unstable_setRequestLocale(locale);

  const t = useTranslations('Home');

  return (
    <>
      <Navbar />

      <main className={styles.main + " fixpad "} data-bs-spy="scroll" data-bs-target="#mnavbar" data-bs-root-margin="0px 0px -40%" data-bs-smooth-scroll="true" tabIndex={0}>
        <Header />

        <div className={styles.features} id="features">
          <div className="container">
            <h3 className={styles.featuresTitle}>{t('featuresTitle')}</h3>
            <div className="row mt-3 animate__animated animate__fadeInUp">
              <div className="col-12 col-md-6 col-lg-4 mt-3">
                <div className="card">
                  <Image
                    className="image mx-auto mt-3"
                    src="/icons/features/responsive.svg"
                    alt={t('featuresRespTitle')}
                    width={150}
                    height={100}
                  />
                  <div className="card-body text-center">
                    <h3 className="card-title lngtxt">{t('featuresRespTitle')}</h3>
                    <p className="card-text lngtxt">
                      {t('featuresRespDesc')}
                    </p>
                  </div>
                </div>
              </div>
              <div className="col-12 col-md-6 col-lg-4 mt-3">
                <div className="card">
                  <Image
                    className="image mx-auto mt-3"
                    src="/icons/features/quickSpeed.svg"
                    alt={t('featuresQSpeedTitle')}
                    width={150}
                    height={100}
                  />
                  <div className="card-body text-center">
                    <h3 className="card-title lngtxt">{t('featuresQSpeedTitle')}</h3>
                    <p className="card-text lngtxt">
                      {t('featuresQSpeedDesc')}
                    </p>
                  </div>
                </div>
              </div>
              <div className="col-12 col-md-6 col-lg-4 mt-3">
                <div className="card">
                  <Image
                    className="image mx-auto mt-3"
                    src="/icons/features/support.svg"
                    alt={t('featuresSupportTitle')}
                    width={150}
                    height={100}
                  />
                  <div className="card-body text-center">
                    <h3 className="card-title lngtxt">{t('featuresSupportTitle')}</h3>
                    <p className="card-text lngtxt">
                      {t('featuresSupportDesc')}
                    </p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div className={styles.services} id="services">
          <div className="container">
            <h3 className={styles.servicesTitle}>{t('servicesTitle')}</h3>
            <div className="row mt-3 animate__animated animate__fadeInUp">
              <div className="col-12 col-md-6 col-lg-4 col-xl-3 mt-3">
                <div className="card">
                  <Image
                    className="image mx-auto mt-3"
                    src="/icons/services/website.svg"
                    alt={t('servicesWebsitesAndSoftwaresTitle')}
                    width={150}
                    height={100}
                  />
                  <div className="card-body text-center">
                    <h3 className="card-title lngtxt">{t('servicesWebsitesAndSoftwaresTitle')}</h3>
                    <p className="card-text lngtxt">
                      {t('servicesWebsitesAndSoftwaresDesc')}
                    </p>
                  </div>
                </div>
              </div>
              <div className="col-12 col-md-6 col-lg-4 col-xl-3 mt-3">
                <div className="card">
                  <Image
                    className="image mx-auto mt-3"
                    src="/icons/services/blog.svg"
                    alt={t('servicesBlogTitle')}
                    width={150}
                    height={100}
                  />
                  <div className="card-body text-center">
                    <h3 className="card-title lngtxt">{t('servicesBlogTitle')}</h3>
                    <p className="card-text lngtxt">
                      {t('servicesBlogDesc')}
                    </p>
                  </div>
                </div>
              </div>
              <div className="col-12 col-md-6 col-lg-4 col-xl-3 mt-3">
                <div className="card">
                  <Image
                    className="image mx-auto mt-3"
                    src="/icons/services/mobileApp.svg"
                    alt={t('servicesMobileAppTitle')}
                    width={150}
                    height={100}
                  />
                  <div className="card-body text-center">
                    <h3 className="card-title lngtxt">{t('servicesMobileAppTitle')}</h3>
                    <p className="card-text lngtxt">
                      {t('servicesMobileAppDesc')}
                    </p>
                  </div>
                </div>
              </div>
              <div className="col-12 col-md-6 col-lg-4 col-xl-3 mt-3">
                <div className="card">
                  <Image
                    className="image mx-auto mt-3"
                    src="/icons/services/socialNetwork.svg"
                    alt={t('servicesSocialNetworkTitle')}
                    width={150}
                    height={100}
                  />
                  <div className="card-body text-center">
                    <h3 className="card-title lngtxt">{t('servicesSocialNetworkTitle')}</h3>
                    <p className="card-text lngtxt">
                      {t('servicesSocialNetworkDesc')}
                    </p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div className={styles.getourapp} id="getourapp">
          <div className={"container " + styles.contentfront}>
            <h2 className={styles.getourappTitle}>
              {t('getourappTitle')}
            </h2>
            <div className="row">
              <div className="col-12 col-md-6">
                <p className={styles.getourappDesc}>
                  {t('getourappDesc')}
                </p>
                <ul className={styles.getourappLinks + " p-0  animate__animated animate__fadeInUp"}>
                  <li>
                    <a href="#lcpwindows">
                      <Image className="image" src="/icons/crossplatform/icoWindows.svg" alt={t('getourappWin')} width={50} height={50} />
                    </a>
                  </li>
                  <li className="ms-2">
                    <a href="#lcplinux">
                      <Image className="image" src="/icons/crossplatform/icoLinux.svg" alt={t('getourappLinux')} width={50} height={50} />
                    </a>
                  </li>
                  <li className="ms-2">
                    <a href="#lcpmacos">
                      <Image className="image" src="/icons/crossplatform/icoMacOS.svg" alt={t('getourappMacOS')} width={50} height={50} />
                    </a>
                  </li>
                  <li className="ms-2">
                    <a href="#lcpandroid">
                      <Image className="image" src="/icons/crossplatform/icoAndroid.svg" alt={t('getourappAndroid')} width={50} height={50} />
                    </a>
                  </li>
                  <li className="ms-2">
                    <a href="#lcpiphone">
                      <Image className="image" src="/icons/crossplatform/icoiPhone.svg" alt={t('getourappiPhone')} width={50} height={50} />
                    </a>
                  </li>
                </ul>
              </div>
              <div className="col-12 col-md-6">
                <Image className="image w-100" src="/icons/crossplatform/gadgets.svg" alt={t('getourappGadgets')} width={350} height={350} />
              </div>
            </div>
          </div>
          <Image className={styles.image + " " + styles.waveabs + " w-100"} src="/images/wave2.svg" alt="Wave" width={350} height={350} />
        </div>

        <div className={styles.about} id="about">
          <div className="container">
            <h3 className={styles.aboutTitle}>{t('aboutTitle')}</h3>
            <p className={styles.aboutDesc + " text-center mt-3"}>
              {t('aboutDesc') ?? "LCP (Luis Carvalho Projects) is a project of websites, apps and softwares, which my main goal is showcase to all my projects for everyone and also, using my skills and services to make everyone dreams comes true."}
            </p>
          </div>
        </div>

        <div className={styles.team} id="team">
          <div className="container">
            <h3 className={styles.teamTitle}>{t('teamTitle')}</h3>
            <div className="col-12 col-md-6 col-lg-4 mx-auto mt-3">
              <div className="card p-3">
                <Image
                  className="image mx-auto"
                  src="/images/avatar.png"
                  alt="Luis Carvalho (Creator from LCP)"
                  width={150}
                  height={150}
                />
                <div className="card-body text-center">
                  <h2 className="card-title">Luis Carvalho</h2>
                  <p className={"card-text " + styles.careerdesc}>
                    {t('teamMemberCareerDesc') ?? "Web programmer, programmer, engineer, specialist and technician of IT since 2015."}
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>

        <ContactComponent />
        <Footer />
      </main>
    </>
  )
}

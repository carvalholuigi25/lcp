import styles from '../styles/page/page.module.scss';
import Image from 'next/image';
import { useLocale, useTranslations } from 'next-intl';
import { ThemeComponent } from '../features/theme';
import { LanguageWithFlagsComponent } from '../features/langWithFlags';
import SubscribeComponent from '../components/subscribe';

export default function Footer() {
    const t = useTranslations('Footer');

    return (
        <>
            <div className={styles.footer + " " + styles.wave3}>
                <div className="container mt-3">
                    <div className="row">
                        <div className="footerLinks col-12 col-md-6 col-lg-4 colleft mt-3">
                            <h3 className={styles.footerLinksTitle} dir="auto">{t('linksTitle')}</h3>
                            <ul className={styles.footerListLinks}>
                                <li><a href="#features" dir="auto">{t('listLinksOpt1')}</a></li>
                                <li><a href="#services" dir="auto">{t('listLinksOpt2')}</a></li>
                                <li><a href="#about" dir="auto">{t('listLinksOpt3')}</a></li>
                                <li><a href="#team" dir="auto">{t('listLinksOpt4')}</a></li>
                                <li><a href="#contacts" dir="auto">{t('listLinksOpt5')}</a></li>
                            </ul>
                        </div>
                        <div className="footerMisc col-12 col-md-6 col-lg-4 colcenter mt-3">
                            <div className="container">
                                <div className="row">
                                    <div className="col-12 col-md-6 col-lg-6 mb-3">
                                        <h4 className={styles.footerMiscTitle} dir="auto">{t('miscTitleTheme')}</h4>
                                        <ThemeComponent mylocale={t('miscOptDynamicTheme', { themeval: useLocale() })} seldeftheme={t('miscDefSelTheme')} />
                                    </div>
                                    <div className="col-12 col-md-6 col-lg-6 mb-3">
                                        <h4 className={styles.footerMiscTitle} dir="auto">{t('miscTitleLang')}</h4>
                                        <LanguageWithFlagsComponent />
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-12 mt-3">
                                        <SubscribeComponent />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="footerSocialNetworks col-12 col-md-6 col-lg-4 colright mt-3">
                            <h3 className={styles.footerSocialNetworksTitle} dir="auto">{t('socialNetworksTitle')}</h3>
                            <a href="https://github.com/carvalholuigi25" className="ms-2" target='_blank'>
                                <Image className="image" src="/icons/socialnetworks/github.svg" alt="LCP Github" width={40} height={40} />
                            </a>
                            <a href="https://www.instagram.com/luiscardev27/" className="ms-2" target='_blank'>
                                <Image className="image" src="/icons/socialnetworks/instagram.svg" alt="LCP Instagram" width={40} height={40} />
                            </a>
                        </div>
                    </div>
                    <div className="row mt-3">
                        <div className="footerCopyright col-12 mt-3 ms-auto me-auto text-center">
                            <p dir="auto">{t('copyrightTitle') ?? "Created by Luis Carvalho - &copy; 2023 LCP"}</p>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
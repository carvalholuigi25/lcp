import styles from '../styles/page/page.module.scss';
import Image from 'next/image';
import { useLocale, useTranslations } from 'next-intl';
import { ThemeComponent } from '@applocale/components/theme';
import { FlagsLang } from '@applocale/components/flagslang';
import { getDefLocale } from '@applocale/helpers/defLocale';

export default function Footer() {
    const t = useTranslations('Footer');

    const snetworks = [
        { id: 1, name: 'Facebook', url: 'https://www.facebook.com/lcp2267', icon: '/icons/socialnetworks/facebook.svg', alt: 'LCP Facebook' },
        { id: 2, name: 'Github', url: 'https://github.com/carvalholuigi25', icon: '/icons/socialnetworks/github.svg', alt: 'LCP Github' },
        { id: 3, name: 'Instagram', url: 'https://www.instagram.com/lcp2267/', icon: '/icons/socialnetworks/instagram.svg', alt: 'LCP Instagram' }
    ];

    const featureslinks = [
        { id: 1, name: t('listLinksOpt1'), url: '#features' },
        { id: 2, name: t('listLinksOpt2'), url: '#services' },
        { id: 3, name: t('listLinksOpt3'), url: '#about' },
        { id: 4, name: t('listLinksOpt4'), url: '#team' },
        { id: 5, name: t('listLinksOpt5'), url: '#contacts' }
    ];

    return (
        <>
            <div className={styles.footer + " " + styles.wave3}>
                <div className="container mt-3">
                    <div className="row">
                        <div className="footerLinks col-12 col-md-6 col-lg-4 colleft mt-3">
                            <h3 className={styles.footerLinksTitle} dir="auto">{t('linksTitle')}</h3>

                            {featureslinks && featureslinks.length > 0 && (
                                <ul className={styles.footerListLinks}>
                                    {featureslinks.map((fl) => (
                                        <li key={fl.id}><a href={fl.url} dir="auto">{fl.name}</a></li>
                                    ))}
                                </ul>
                            )}
                        </div>
                        <div className="footerMisc col-12 col-md-6 col-lg-4 colcenter mt-3">
                            <div className="container">
                                <div className="row">
                                    <div className="col-12 col-md-6 col-lg-6 mb-3">
                                        <h4 className={styles.footerMiscTitle} dir="auto">{t('miscTitleTheme')}</h4>
                                        <ThemeComponent mylocale={t('miscOptDynamicTheme', { themeval: useLocale() ?? getDefLocale() })} seldeftheme={t('miscDefSelTheme')} />
                                    </div>
                                    <div className="col-12 col-md-6 col-lg-6 mb-3">
                                        <h4 className={styles.footerMiscTitle} dir="auto">{t('miscTitleLang')}</h4>
                                        <FlagsLang seldeflang={t('miscDefSelLang')} />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="footerSocialNetworks col-12 col-md-6 col-lg-4 colright mt-3">
                            <h3 className={styles.footerSocialNetworksTitle} dir="auto">{t('socialNetworksTitle')}</h3>
                            {snetworks && snetworks.length > 0 && snetworks.map((sn) => (
                                <a href={sn.url} className="me-auto ms-2" target='_blank' key={sn.id}>
                                    <Image className="image" src={sn.icon} alt={sn.alt} width={40} height={40} />
                                </a>
                            ))}
                        </div>
                    </div>
                    <div className="row justify-content-center mt-3">
                        <div className="footerCopyright col-12 mt-3 ms-auto me-auto text-center">
                            <p dir="auto">{t.markup('copyrightTitle', {symcopy: "\u00A9", year: new Date().getFullYear()}) ?? `Created by Luis Carvalho - \u00A9 ${new Date().getFullYear()} LCP`}</p>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
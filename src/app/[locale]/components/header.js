import styles from '../styles/page/page.module.scss';
import Image from 'next/image';
import { useTranslations } from 'next-intl';

export default function Header() {
    const t = useTranslations('Header');

    return (
        <>
            <div className={styles.header + " " + styles.wave1 + " p-5"}>
                <div className="container">
                    <div className="row">
                        <div className="col-12 col-md-6 order-1 order-md-0 headersideleft mt-3 animate__animated animate__fadeInUp">
                            <p className={styles.desc + " mt-3"} id="mdesc" dir="auto">
                                {t('desc')}
                            </p>
                            <a href="#features" className="btn btn-primary btnSeeMore" id="btnSeeMore" dir="auto">
                                {t('btnSeeMore')}
                                <i className="bi bi-arrow-down ms-2"></i>
                            </a>
                        </div>
                        <div className="col-12 col-md-6 order-0 order-md-1 headersideright animate__animated animate__fadeInUp">
                            <Image
                                className="image mx-auto logofull"
                                src="/images/logos/logo.svg"
                                alt="LCP"
                                width={200}
                                height={200}
                                priority
                            />
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
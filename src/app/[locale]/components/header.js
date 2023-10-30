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
                        <div className="col-12 col-md-6 headersideleft mt-3 animate__animated animate__fadeInUp">
                            <h1 className={styles.mtitle} id="mtitle" dir="auto">LCP</h1>
                            <p className={styles.desc} dir="auto">
                                {t('desc')}
                            </p>
                            <a href="#features" className="btn btn-primary btnSeeMore" dir="auto">
                                {t('btnSeeMore')}
                            </a>
                        </div>
                        <div className="col-12 col-md-6 headersideright animate__animated animate__fadeInUp">
                            <Image
                                className="image mx-auto"
                                src="/images/setup.svg"
                                alt="LCP"
                                width={530}
                                height={530}
                                priority
                            />
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
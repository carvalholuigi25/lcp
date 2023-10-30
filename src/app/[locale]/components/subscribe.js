import { useTranslations } from 'next-intl';

export default function SubscribeComponent() {
    const t = useTranslations('Footer');

    return (
        <>
            <form action="/scripts/subscribe.php" method="post">
                <label htmlFor="email" dir="auto">{t('newsletterTitle')}</label>
                <div className="input-group">
                    <input type="email" name="email" id="email" className="form-control email" dir="auto" placeholder={t('newsletterPlaceholder')} required />
                    <button type="submit" name="btnsubSubscribe" className="btn btn-primary btnsubNewsletter" id="btnsubNewsletter">
                        <i className="bi bi-send"></i>
                    </button>
                </div>
            </form>
        </>
    )
}
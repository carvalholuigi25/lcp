"use client";

import React, { useState } from 'react';
import styles from '../styles/page/page.module.scss';
import { useLocale, useTranslations } from 'next-intl';

export default function ContactComponent() {
    const t = useTranslations('Home');
    const temailtrans = useTranslations('Templates.Email');
    const locale = useLocale();

    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [subject, setSubject] = useState("");
    const [message, setMessage] = useState("");

    const handleNameChange = (e) => {
        setName(e.target.value);
    }

    const handleEmailChange = (e) => {
        setEmail(e.target.value);
    }

    const handleSubjectChange = (e) => {
        setSubject(e.target.value);
    }

    const handleMessageChange = (e) => {
        setMessage(e.target.value);
    }

    const sendMail = async (e) => {
        e.preventDefault();
        const formData = JSON.stringify({
            name: name,
            email: email,
            subject: subject,
            message: message,
            translationmsgs: {
                lang: temailtrans('lang'),
                thankyoumsg: temailtrans('thankyoumsg'),
                emaildate: temailtrans('emaildate'),
                emailto: temailtrans('emailto'),
                emailfrom: temailtrans('emailfrom'),
                emailname: temailtrans('emailname'),
                emailsubject: temailtrans('emailsubject'),
                emailbody: temailtrans('emailbody'),
                copyright: temailtrans('copyright')
            }
        });

        fetch('/api/'+ locale +'/sendemail', {
            method: "post",
            body: formData,
            headers: new Headers({
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json; charset=utf-8',
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Methods': 'GET, POST, PUT, PATCH, DELETE, OPTIONS',
                'Access-Control-Allow-Headers': 'Content-Type, Authorization'
            })
        })
        .then((res) => {
            console.log(res);
            console.log('Response received');
            console.log('Response succeeded!');
            setSubmitted(true);
            setName('');
            setEmail('');
            setSubject('');
            setMessage('');
        });
    }

    return (
        <>
            <div className={styles.contacts} id="contacts">
                <form action="" method="post" className="container frmcontactus" id="frmcontactus" onSubmit={sendMail}>
                    <h1 className={styles.contactsTitle} dir="auto">{t('contactsTitle')}</h1>
                    <div className="row mt-3">
                        <div className="col-12 col-md-6 mt-3">
                            <label htmlFor="name" dir="auto">{t('contactsName')}</label>
                            <input type="text" name="name" id="name" dir="auto" value={name} placeholder={t('contactsNameInp')} className="form-control name mt-1" required onChange={handleNameChange} />
                        </div>
                        <div className="col-12 col-md-6 mt-3">
                            <label htmlFor="email" dir="auto">{t('contactsEmail')}</label>
                            <input type="email" name="email" id="email" dir="auto" value={email} placeholder={t('contactsEmailInp')} className="form-control email mt-1" required onChange={handleEmailChange} />
                        </div>
                    </div>
                    <div className="row mt-3">
                        <div className="col-12">
                            <label htmlFor="subject" dir="auto">{t('contactsSubject')}</label>
                            <input type="text" name="subject" id="subject" dir="auto" value={subject} placeholder={t('contactsSubjectInp')} className="form-control subject mt-1" required onChange={handleSubjectChange} />
                        </div>
                    </div>
                    <div className="row mt-3">
                        <div className="col-12">
                            <label htmlFor="message" dir="auto">{t('contactsMessage')}</label>
                            <textarea name="message" id="message" dir="auto" placeholder={t('contactsMessageInp')} className="form-control message mt-1" required cols={1} rows={10} onChange={handleMessageChange} value={message}></textarea>
                        </div>
                        <div className="col-12 mt-3 mx-auto text-center">
                            <input type="reset" className="btn btn-secondary btnreset" id="btnreset" dir="auto" value={t('contactsReset')} />
                            <input type="submit" name="btnsubContact" className="btn btn-primary btnsubmit ms-3" id="btnsubmit" dir="auto" value={t('contactsSubmit')} />
                        </div>
                    </div>
                </form>
                <div className={"mt-3 mx-auto " + styles.contactmsgblk}>
                    <p>{t('contactsSendEmail')} <a href="mailto:luiscarvalho239@gmail.com" className="cblack">{t('contactsSendEmail2')}</a></p>
                </div>
            </div>
        </>
    );
}
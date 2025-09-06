import { NextRequest, NextResponse } from "next/server";
import { sendMailUtil } from '../../../[locale]/utils/sendmailUtils';
import { EmailTemplate } from '../../../[locale]/templates';

export async function POST(req: NextRequest) {  
  const body = await req.json();
  const curpath = `${process.env.TYPEENV === 'production' ? 'https://lcp-pi.vercel.app' : './public'}`;
  const attachmentsobj = [{
    filename: 'logo_compact.png',
    path: `${curpath}/images/logos/logo_compact.png`,
    cid: 'uniquelogo'
  }];
  
  const dataobj = {
    to: process.env.EMAIL_USER,
    from: `"${body.name}" <${body.email}>`,
    subject: body.subject,
    text: `${body.message}\r\n Sent by ${body.email} (${body.name})`,
    html: EmailTemplate(body, body.translationmsgs),
    attachments: attachmentsobj
  };

  await sendMailUtil(dataobj);
  return NextResponse.json({ message: 'Email sent successfully' });
}
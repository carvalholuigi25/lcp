import { NextResponse } from "next/server";
import { sendMailUtil } from '../../[locale]/utils/sendmailUtils';
import { EmailTemplate } from '../../[locale]/templates';

export async function POST(req: any) {  
  const body = await req.json();
  const dataobj = {
    to: process.env.EMAIL_USER,
    from: `"${body.name}" <${body.email}>`,
    subject: body.subject,
    text: `${body.message}\r\n Sent by ${body.email} (${body.name})`,
    html: EmailTemplate(body),
    attachments: [{
      filename: 'logo_compact.png',
      path: process.env.TYPEENV === 'production' ? "https://lcp-pi.vercel.app/images/logos/logo_compact.png" : "./public/images/logos/logo_compact.png",
      cid: 'uniquelogo'
    }]
  };

  console.log(dataobj);

  await sendMailUtil(dataobj);

  return NextResponse.json({ dataobj });
}
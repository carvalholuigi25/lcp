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
    html: EmailTemplate(body)
  };

  console.log(dataobj);

  await sendMailUtil(dataobj);

  return NextResponse.json({ dataobj });
}
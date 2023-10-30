import { NextResponse } from "next/server";
import { sendMailUtil } from '../../[locale]/utils/sendmailUtils';

export async function POST(req: any) {  
  const body = await req.json();
  const dataobj = {
    to: process.env.EMAIL_USER,
    from: body.from,
    subject: body.subject,
    text: `${body.message}\r\n Sent by ${body.email} (${body.name})`,
    html: `<!doctype html><html><head><title>Hello</title></head><body><b>${body.message}</b><p>Sent by: ${body.email} (${body.name})</p></body></html>`
  };

  sendMailUtil(dataobj);

  return NextResponse.json({ dataobj });
}
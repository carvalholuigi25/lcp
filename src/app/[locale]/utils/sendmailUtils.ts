export async function sendMailUtil(mailData: any) {
  require('dotenv').config();
  let nodemailer = require('nodemailer');
  
  const transporter = nodemailer.createTransport({
    host: process.env.EMAIL_HOST,
    port: parseInt(process.env.EMAIL_PORT!.toString()),
    secure: process.env.EMAIL_IS_SSL === "true" ? true : false,
    auth: {
      user: process.env.EMAIL_USER,
      pass: process.env.EMAIL_PASSWORD,
    }
  });

  await transporter.sendMail(mailData, (err: any, info: any) => {
    if(err)
      console.log(err)
    else
      console.log(info)
  });

  return mailData;
}
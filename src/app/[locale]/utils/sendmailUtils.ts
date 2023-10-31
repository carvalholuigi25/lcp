export async function sendMailUtil(mailData: any) {
  require('dotenv').config();
  let nodemailer = require('nodemailer');
  const debugOpt = true;
  const confopt = {
    host: process.env.EMAIL_HOST,
    port: parseInt(process.env.EMAIL_PORT!.toString()),
    secure: process.env.EMAIL_IS_SSL === "true" ? true : false,
    auth: {
      user: process.env.EMAIL_USER,
      pass: process.env.EMAIL_PASSWORD,
    }
  };

  if(debugOpt == true) {
    console.log(confopt)
  }
  
  const transporter = nodemailer.createTransport(confopt);

  // await transporter.sendMail(mailData, (err: any, info: any) => {
  //   if(err)
  //     console.log(err)
  //   else
  //     console.log(info)
  // });

  await new Promise((resolve, reject) => {
    transporter.sendMail(mailData, (err: any, info: any) => {
      if (err) {
        console.error(err);
        reject(err);
      } else {
        resolve(info);
      }
    });
  });

  return mailData;
}
import { NextResponse } from "next/server";

export async function POST(req: any) {  
  const body = await req.json();
  const authobj = {
    username: body.username,
    userpass: body.userpass
  };

  let nauthobj = {};

  if(authobj.username == "admin" && authobj.userpass == process.env.ADMIN_PASS) {
    nauthobj = { username: authobj.username, isLoggedIn: true, msg: "Logged" };
  } else {
    nauthobj = { username: null, isLoggedIn: false, msg: "Invalid user auth credientals!" };
  }

  return NextResponse.json({ nauthobj });
}
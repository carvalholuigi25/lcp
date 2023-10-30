import { NextResponse } from "next/server";

export async function POST(req: any, res: any) {  
  const body = await req.json();
  const authobj = {
    username: body.username
  };

  let nauthobj = {};

  if(authobj.username == "admin") {
    nauthobj = { isLoggedIn: false, msg: "Logged out!" };
  } else {
    nauthobj = { isLoggedIn: true, msg: "Error when trying to logout!" };
  }

  return NextResponse.json({ nauthobj });
}
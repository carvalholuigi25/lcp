"use client";

const controller = new AbortController();
const signal = controller.signal;

export function getHeaders() {
    return {
        'Accept': 'application/json, text/plain, */*',
        'Content-Type': 'application/json; charset=utf-8',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'GET, POST, PUT, PATCH, DELETE, OPTIONS',
        'Access-Control-Allow-Headers': 'Content-Type, Accept, Authorization'
    };
}

export async function doLogin(e: any, username: string, userpass: string) {
    e.preventDefault();

    const formData = JSON.stringify({
        username: username,
        userpass: userpass
    });

    return await fetch('/api/login', {
        method: "post",
        body: formData,
        headers: getHeaders(),
        signal: signal
    }).then((res: any) => res.json());
}

export async function doLogout(e: any, username: string) {
    e.preventDefault();

    const formData = JSON.stringify({
        username: username
    });

    return await fetch('/api/logout', {
        method: "post",
        body: formData,
        headers: getHeaders(),
        signal: signal
    })
    .then((res: any) => res.json());
}

export function abortReq() {
    controller.abort();
}
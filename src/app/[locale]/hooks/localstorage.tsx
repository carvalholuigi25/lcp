/* eslint-disable @typescript-eslint/no-explicit-any */
// save to storage
export const saveToStorage = (key: any, value: any) => {
    if(typeof window !== 'undefined') {
        return window.localStorage.setItem(key, value);
    }
}

// get from storage
export const getFromStorage = (key: any) => {
    if (typeof window !== 'undefined') {
        return window.localStorage.getItem(key);
    }
}


export const delFromStorage = (key: any) => {
    if (typeof window !== 'undefined') {
        return window.localStorage.getItem(key) ? window.localStorage.removeItem(key) : null;
    }
}
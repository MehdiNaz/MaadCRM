'use client'
import { useEffect } from 'react';
export default function Page() {
    useEffect(() => {
        localStorage.removeItem('token')
        window.location.href = '/login'
    })
    return null
}
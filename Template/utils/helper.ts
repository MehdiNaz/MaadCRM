import { deleteCookie } from "cookies-next";
const moment = require('jalali-moment');
import jwt_decode from "jwt-decode";
import { usePathname } from "next/navigation"
import { useCallback } from "react"

export function convertPerisnaNumbersToEnglishNumbers(text: string): string {
    const persianNumbers = ['۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹'];
    const englishNumbers = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
    return text.replace(/[۰-۹]/g, (w) => englishNumbers[persianNumbers.indexOf(w)]);
}

export function convertEnglishNumbersToPerisanNumbers(text: string): string {
    const persianNumbers = ['۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹'];
    const englishNumbers = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
    return text.replace(/[0-9]/g, (w) => persianNumbers[englishNumbers.indexOf(w)]);
}


export function setLocalStorage(key: string, value: any) {
    if (typeof window === 'undefined') return null
    localStorage.setItem(key, JSON.stringify(value))
}

export function getLocalStorage(ket: string) {
    if (typeof window === 'undefined') return null
    return JSON.parse(localStorage.getItem(ket)) ?? null
}

export function disableInputsandButtons() {
    const inputs = document.querySelectorAll('input, button');
    inputs.forEach(input => input.setAttribute('disabled', 'true'))
}

export function enableInputsandButtons() {
    const inputs = document.querySelectorAll('input, button');
    inputs.forEach(input => input.removeAttribute('disabled'))
}

export function numberToString(number: number) {
    return number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

export function isValidIranianNationalCode(input: string) {
    if (!/^\d{10}$/.test(input))
        return false;

    const check = +input[9];
    let sum = Array(9).fill(0)
        .map((_, i) => +input[i] * (10 - i))
        .reduce((x, y) => x + y) % 11;

    return (sum < 2 && check == sum) || (sum >= 2 && check + sum == 11);
}


export function handleComma(value) {
    value = value?.toString()
    value = value?.replace(/,/g, '')
    value = value?.replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    return value
}

export function removeComma(value) {
    value = value?.toString()
    value = value?.replace(/,/g, '')
    return value
}

export async function logout() {
    try {
        const cookie = deleteCookie('token')
        localStorage.removeItem('token')
        return true
    } catch (err) {
        return err
    }
}

export function validatePhoneNumber(phone: string) {
    const regex = /^(\+98|0)?9\d{9}$/;
    return regex.test(phone)
}

export function validateNationalCode(nationalCode: string) {
    const regex = /^\d{10}$/;
    return regex.test(nationalCode)
}

export function convertPersianDate(date) {
    if (!validDate(date)) return Error('invalid date')
    return moment.from(date, 'fa', 'YYYY-MM-DD').locale('en').format('YYYY-MM-DD');
}

export function convertDateToPerisan(date) {
    try {
        if (date === null) return 'Invalid Date'
        if (date.includes('T')) date = date.split('T')[0]
        if (!validDate(date)) return 'Invalid Date'
        return moment(date, 'YYYY-MM-DD').locale('fa').format('YYYY-MM-DD');
    } catch {
        return 'Invalid Date'
    }
}

export function convertToUTC(time) {
    const date = new Date(time)
    return date.toISOString()
}

export function userLoggedIn() {
    return !!localStorage.getItem('token')
}

export function convertCalenderTimeToEn(time): string {
    const birthDateYear = time.getFullYear()
    let birthDateMonth = time.getMonth()
    if (birthDateMonth < 10) birthDateMonth = '0' + (birthDateMonth + 1)
    let birthDateDay = time.getDate()
    if (birthDateDay < 10) birthDateDay = '0' + (birthDateDay)
    return birthDateYear + '-' + birthDateMonth + '-' + birthDateDay
}

export function convertDate(date) {
    date = convertPerisnaNumbersToEnglishNumbers(date)
    date = date.split('-')
    if (date[1] < 10 && date[1][0] !== '0') date[1] = '0' + date[1]
    if (date[2] < 10 && date[2][0] !== '0') date[2] = '0' + date[2]
    date = date.join('-')
    return date
}

export function validDate(date) {
    try {
        date = convertDate(date)
        const regex = /^\d{4}-\d{2}-\d{2}$/
        if (date.split('-')[1] > 12 || date.split('-')[2] > 31) {
            return false
        }
        return regex.test(date)
    } catch {
        return false
    }
}

export function decode_token(token?: string) {
    if (token) return jwt_decode(token)
    token = localStorage.getItem('token')
    if (!token) return null
    return jwt_decode(token)
}

export function hasAccess({ role, token }: {
    role: 'ADMIN' | 'TEAMMATE' | 'SUPERADMIN',
    token?: any
}) {
    if (token) {
        token = jwt_decode(token)
        if (!token) return false
        return token.role === role
    }
    if (typeof window === 'undefined') return false
    const userToken = decode_token() as any
    if (!userToken) return false
    return userToken.role === role
}
export function createQueryString({ searchParams, name, value }) {
    useCallback(
        (name: string, value: string) => {
            const params = new URLSearchParams(searchParams.toString())
            params.set(name, value)
            return params.toString()
        },
        [searchParams]
    )
}

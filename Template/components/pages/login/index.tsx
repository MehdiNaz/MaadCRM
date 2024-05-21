'use client'

import TextInput from "@/components/textInput"
import { LoadingOverlay, PinInput } from "@mantine/core"
import { useForm } from "@mantine/form"
import { showNotification } from "@mantine/notifications"
import Image from "next/image"
import { useRef, useState } from "react"
import { LoginWithPhone, Verify } from "@/services/login"
import { convertPerisnaNumbersToEnglishNumbers, setLocalStorage } from "@/utils/helper"
import { setCookie } from 'cookies-next'
import jwtDecode from "jwt-decode"
import { setUserFullName } from "@/slices/userSlice"
import { useDispatch } from "react-redux"
import { AppDispatch } from "store/store"

export default function Login() {

    const [counter, setCounter] = useState<number>(60)
    const [buttonText, setButtonText] = useState<string>('ادامه')
    const otpRef = useRef<HTMLDivElement>(null)
    const [active, setActive] = useState<number>(0);
    const [visible, setVisible] = useState<boolean>(false)
    const [mobileDisabled, setMobileDisabled] = useState<boolean>(false)

    const dispatch = useDispatch<AppDispatch>()

    const form = useForm({
        initialValues: { mobile: '', otp: '' },

        validate: (values) => {
            if (active === 0) {
                return {
                    mobile: values.mobile.length < 11 ? 'شماره موبایل را به صورت صحیح وارد کنید' : null
                }
            }
            if (active === 1) {
                return {
                    otp: values.otp.length < 4 ? 'کد تایید را به صورت صحیح وارد کنید' : null,
                }
            }
            return {}
        },
    })


    async function sendOTP(mobile: string) {
        try {
            const response = await LoginWithPhone({ phone: mobile })
            if (response.success) {
                setActive(1)
                setVisible(false)
                setMobileDisabled(true)
                showNotification({
                    title: 'عملیات موفق',
                    message: 'کد تایید با موفقیت ارسال شد',
                    color: 'green'
                })
                setButtonText('ورود')
                otpRef.current?.classList.remove('hidden')
                console.log('response', response);

                const interval = setInterval(() => {
                    setCounter((prev) => prev - 1)
                }, 1000)
                setTimeout(() => {
                    clearInterval(interval)
                    setCounter(0)
                }, counter * 1000)
            }
        } catch (err) {
            setVisible(false)
            showNotification({ title: 'خطا', message: 'خطا در ارتباط با سرور', color: 'red' })
        }
    }

    async function verifyOTP(phone: string, otp: string) {
        try {
            const response = await Verify({ phone: phone, otp: otp })
            if (response.success) {
                const decode = jwtDecode(response.token) as any
                const exp = decode?.exp
                setCookie('token', response.token ?? 'token', { path: '/', expires: new Date(exp * 1000) })
                setLocalStorage('token', response.token ?? 'token')
                // setLocalStorage('user_id', decode.id ?? 'user_id')
                showNotification({
                    title: 'عملیات موفق',
                    message: 'ورود با موفقیت انجام شد',
                    color: 'green'
                })
                // const fullName = response.data.name + ' ' + response.data.family
                // dispatch(setUserFullName(fullName))
                // setLocalStorage('permission', response.data.permission ?? 1)
                if (response.profile_completed == true) {
                    window.location.href = '/customers'
                } else {
                    window.location.href = '/confirm'
                }
            }
        } catch (err) {
            setVisible(false)
            showNotification({ title: 'خطا', message: 'کدتایید نامعتبر', color: 'red' })
        }
    }

    async function handleSubmit(values: typeof form.values) {
        const mobile = convertPerisnaNumbersToEnglishNumbers(values.mobile)
        const otp = convertPerisnaNumbersToEnglishNumbers(values.otp)
        try {
            if (active === 0) {
                setVisible(true)
                sendOTP(mobile)
            }
            if (active === 1) {
                setVisible(true)
                verifyOTP(mobile, otp)
            }
        } catch (err) {
            setVisible(false)
            showNotification({ title: 'خطا', message: err.message, color: 'red' })
        }
    }

    function handleErrors(errors: typeof form.errors) {
        if (errors.mobile) {
            showNotification({ title: 'خطا', message: 'شماره موبایل خود را به صورت صحیح وارد کنید', color: 'red' })
        }
        if (errors.otp) {
            showNotification({ title: 'خطا', message: 'کد تایید را به صورت صحیح وارد کنید', color: 'red' })
        }
    }
    const formRef = useRef<HTMLFormElement>(null)

    return (
        <>
            <div className="fixed w-full h-full bg-primary flex justify-center items-center">
                <LoadingOverlay visible={visible} overlayBlur={2} />
                <div className="w-1/2 bg-white h-full">
                    <div className="w-full flex flex-col items-center justify-center h-full bg-priamry">
                        <h1 className="text-2xl mb-8">ورود | ثبت نام</h1>
                        <form
                            ref={formRef}
                            onSubmit={form.onSubmit(handleSubmit, handleErrors)}
                            className="flex items-center flex-col justify-center min-w-[300px] max-w-full">
                            <TextInput
                                disabled={mobileDisabled}
                                placeholder="شماره موبایل خود را وارد کنید"
                                maxLength={11}
                                {...form.getInputProps('mobile')}
                                onChange={(e) => {
                                    const value = convertPerisnaNumbersToEnglishNumbers(e.target.value)
                                    if (isNaN(Number(value))) {
                                        form.setFieldError('mobile', 'شماره موبایل را به صورت صحیح وارد کنید')
                                    } else {
                                        form.setFieldError('mobile', null)
                                        form.setFieldValue('mobile', value)
                                    }
                                }}
                            />
                            <div
                                ref={otpRef}
                                id="otp"
                                className="mt-5 hidden">
                                <PinInput
                                    value={form.values.otp}
                                    autoFocus={mobileDisabled ? true : false}
                                    style={{ direction: 'ltr' }}
                                    length={4}
                                    type={/^[۰-۹0-9]*$/}
                                    onChange={(value) => form.setFieldValue('otp', value)}
                                />
                            </div>
                            {counter > 0 ? (
                                <div className={`text-center mt-5 ${mobileDisabled ? 'block' : 'hidden'}`}>
                                    {counter} <span>تا ارسال مجدد</span>
                                </div>
                            ) : (
                                <span
                                    className="cursor-pointer mt-5"
                                    onClick={() => {
                                        setButtonText('ادامه')
                                        otpRef.current?.classList.add('hidden')
                                        setMobileDisabled(false)
                                        setActive(0)
                                        sendOTP(form.values.mobile)
                                        setCounter(2)
                                    }}
                                >ارسال مجدد</span>
                            )}
                            <button type="submit" className="mt-8 bg-primary text-white px-8 py-2 rounded-lg hover:bg-slate-900 duration-100 w-max">
                                {buttonText}
                            </button>
                        </form>
                    </div>
                </div>
                <div className="w-1/2 flex justify-center items-center relative h-full login-logo flex-col">
                    <Image src="/images/login.png" width={380} height={380} alt='Maad crm login' />
                    <span className="text-white font-bold text-2xl text-center leading-10">به سادگی مشتریان
                        <br />خود را مدیریت کنید</span>
                </div>
            </div>
        </>
    )
}

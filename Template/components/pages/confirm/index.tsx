'use client'

import { useState } from 'react'
import TextInput from '@/components/textInput'
import { IoMan, IoWomanSharp } from 'react-icons/io5'
import { Center, SegmentedControl, Box, Stepper, Checkbox } from '@mantine/core'
import './style.css'
import Link from 'next/link'
import { BsCheck2Circle } from 'react-icons/bs'
import { RiUserSettingsLine } from 'react-icons/ri'
import { FiSettings } from 'react-icons/fi'
import { BiLogOutCircle } from 'react-icons/bi'
import { AiFillCheckCircle } from 'react-icons/ai'
import "dayjs/locale/fa"
import { useForm } from '@mantine/form'
import { setProfile } from 'services/profile'
import { convertDate, convertPerisnaNumbersToEnglishNumbers, convertPersianDate, disableInputsandButtons, enableInputsandButtons, validateNationalCode, validDate } from 'utils/helper'
import { showNotification } from '@mantine/notifications'
import Provinces from '@/components/select/province'
import Cities from '@/components/select/cities'
import moment from 'moment-jalaali'
import DateInput from '@/components/DateInput'

export default function Confirm() {

    const [active, setActive] = useState(1)

    const [accept, setAccept] = useState(false)

    async function handleSubmit(values: typeof form.values) {
        try {
            disableInputsandButtons()
            let birthDate = values.birthDate
            birthDate = convertDate(birthDate)
            var m = moment(birthDate, 'jYYYY-jM-jD')
            var format = m.format('YYYY-M-D')
            format = moment.utc(format).format()
            birthDate = format
            const response = await setProfile({
                first_name: values.name,
                last_name: values.family,
                email: values.email,
                national_code: values.nationalCode,
                address: values.address,
                activity: values.activity,
                birthdate: birthDate,
                gender: parseInt(values.gender),
                city_id: parseInt(values.city),
            })
            if (response) {
                showNotification({ title: 'عملیات موفق', message: 'اطلاعات شما با موفقیت ثبت شد', color: 'green', })
                window.location.href = '/plan'
            }
        } catch (err) {
            showNotification({ title: 'عملیات ناموفق', message: 'اطلاعات شما ثبت نشد', color: 'red', })
            enableInputsandButtons()
        } finally {
            enableInputsandButtons()
        }
    }

    const form = useForm({
        initialValues: {
            name: '',
            family: '',
            nationalCode: '',
            gender: '1',
            activity: '',
            email: '',
            city: '',
            state: '',
            address: '',
            birthDate: '',
            accept: false,
        },

        validate: {
            name: (value) => {
                if (!value) return 'نام را وارد کنید'
            },
            family: (value) => {
                if (!value) return 'نام خانوادگی را وارد کنید'
            },
            nationalCode: (value) => {
                if (!validateNationalCode(value)) {
                    return 'کد ملی را به صورت صحیح وارد کنید'
                }
            },
            gender: (value) => {
                if (!value) return 'جنیست را وارد کنید'
            },
            activity: (value) => {
                if (!value) return 'زمینه فعالیت را وارد کنید'
            },
            email: (value) => {
                if (!value) return 'ایمیل را وارد کنید'
            },
            city: (value) => {
                if (!value) return 'شهر را وارد کنید'
            },
            state: (value) => {
                if (!value) return 'استان را وارد کنید'
            },
            address: (value) => {
                if (!value) return 'آدرس را وارد کنید'
            },
            birthDate: (value) => {
                if (!validDate(value)) return 'تاریخ رو به صورت درست وارد کنید'
            },
            // accept: (value) => {
            //     if (!value) return 'قوانین را مطالعه کنید'
            // }
        },
    })


    const [provinceID, setProvinceID] = useState('')
    return (
        <div className="w-full flex-col bg-primary flex justify-center items-center min-h-screen">
            <div className="w-[80%] mt-6 border-b bg-white rounded-t-lg py-8 px-8">
                <Stepper active={active} completedIcon={<AiFillCheckCircle fontSize={25} />}>
                    <Stepper.Step icon={<BsCheck2Circle size={18} />} label="احراز هویت" />
                    <Stepper.Step icon={<RiUserSettingsLine size={18} />} label="اطلاعات کاربری" />
                    <Stepper.Step icon={<FiSettings size={18} />} label="انتخاب پلن" />
                    <Stepper.Step icon={<BiLogOutCircle size={20} />} label="پایان" />
                </Stepper>
            </div>
            <div className="w-[80%] bg-white rounded-b-lg p-8">
                <form
                    onSubmit={form.onSubmit(handleSubmit)}
                    className="w-full border py-7 px-5 mx-auto rounded-lg">
                    <div className="-mx-4 grid grid-cols-12 gap-5 px-4">
                        <div className="col-span-6">
                            <TextInput
                                placeholder='نام'
                                label='نام :'
                                {...form.getInputProps('name')}
                            />
                        </div>
                        <div className="col-span-6">
                            <TextInput
                                placeholder='نام خانوادگی'
                                label='نام خانوادگی :'
                                {...form.getInputProps('family')}
                            />
                        </div>
                        <div className="col-span-6">
                            <TextInput
                                placeholder='کد ملی'
                                label='کد ملی :'
                                maxLength={10}
                                {...form.getInputProps('nationalCode')}
                                onChange={(e) => {
                                    const value = convertPerisnaNumbersToEnglishNumbers(e.target.value)
                                    if (isNaN(Number(value))) {
                                        form.setFieldError('nationalCode', 'کد ملی باید عدد باشد')
                                    } else {
                                        form.setFieldError('nationalCode', null)
                                        form.setFieldValue('nationalCode', value)
                                    }
                                }}
                            />
                        </div>
                        <div className="col-span-6">
                            <DateInput
                                label='تاریخ تولد :'
                                {...form.getInputProps('birthDate')}
                                error={form.errors.birthDate}
                            />
                        </div>
                        <div className="col-span-6">
                            <div className="grid grid-cols-12">
                                <span className="col-span-3 text-sm flex items-center">جنیست :</span>
                                <div className="col-span-9 gender">
                                    <SegmentedControl
                                        onChange={(value) => form.setFieldValue('gender', value)}
                                        data={[
                                            {
                                                value: '1',
                                                label: (
                                                    <Center>
                                                        <IoMan fontSize={25} />
                                                        <Box ml={10}>مرد</Box>
                                                    </Center>
                                                )
                                            },
                                            {
                                                value: '2',
                                                label: (
                                                    <div style={{ width: '100%' }}>
                                                        <Center>
                                                            <IoWomanSharp fontSize={25} />
                                                            <Box ml={10}>زن</Box>
                                                        </Center>
                                                    </div>
                                                )
                                            }
                                        ]}
                                    />
                                </div>
                            </div>
                        </div>
                        <div className="col-span-6">
                            <TextInput
                                placeholder='زمینه فعالیت'
                                label='زمینه فعالیت :'
                                {...form.getInputProps('activity')}
                            />
                        </div>
                        <div className="col-span-6">
                            <TextInput
                                placeholder='آدرس ایمیل'
                                label='آدرس ایمیل :'
                                {...form.getInputProps('email')}
                            />
                        </div>
                        <div className="col-span-6">
                            <Provinces
                                {...form.getInputProps('state')}
                                onChange={(value: string) => {
                                    setProvinceID(value)
                                    form.setFieldValue('state', value)
                                }}
                            />
                        </div>
                        <div className="col-span-6">
                            <Cities
                                provinceID={provinceID}
                                {...form.getInputProps('city')}
                                onChange={(value: string) => {
                                    form.setFieldValue('city', value)
                                }}
                            />
                        </div>
                        <div className="col-span-6">
                            <TextInput
                                label='آدرس :'
                                placeholder="آدرس خود را وارد کنید"
                                {...form.getInputProps('address')}
                            />
                        </div>
                        <div className="col-span-12 flex justify-between items-center mt-8 px-4">
                            <div className="w-2/3">
                                <label>
                                    <Checkbox
                                        label={<Link href="/terms" target='_blank'>شرایط و قوانین را مطالعه کردم و تایید میکنم.</Link>}
                                        style={{ fontSize: '20px' }}
                                        {...form.getInputProps('accept')}
                                    />
                                </label>
                            </div>
                            <div className="w-1/3 flex justify-end">
                                <button type='submit' className='bg-primary text-white px-4 py-2 rounded-lg hover:bg-slate-900 duration-100 disabled:opacity-70' disabled={!form.values.accept}
                                >ثبت و ادامه</button>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div >
    )
}
'use client'

import { Accordion, Box, Center, LoadingOverlay, SegmentedControl } from "@mantine/core"
import { useState } from "react"
import DashboardContent from "@/components/dashboardContent"
import TextInput from "@/components/textInput";
import { IoMan, IoWomanSharp } from 'react-icons/io5'
import Button from '@/components/button'
import { useForm } from "@mantine/form";
import { convertPerisnaNumbersToEnglishNumbers, hasAccess, validatePhoneNumber } from "utils/helper";
import Cities from "@/components/select/cities";
import Provinces from "@/components/select/province";
import { showNotification } from "@mantine/notifications";
import { insertTeammate } from "services/teammates";
import { useRouter } from "next/navigation";
import '../confirm/style.css'
import GroupSelect from "@/components/teammates/groupSelect";

export default function NewTeammate() {

    const router = useRouter()
    const [loading, setLoading] = useState<boolean>(false)

    const form = useForm({
        initialValues: {
            name: '',
            family: '',
            phoneNo: '',
            email: '',
            address: '',
            codeMelli: '',
            gender: '',
            IdGroup: ''
        },
        validate: {
            name: (value) => {
                if (!value) return 'نام نمیتواند خالی باشد'
            },
            family: (value) => {
                if (!value) return 'نام خانوادگی نمیتواند خالی باشد'
            },
            phoneNo: (value) => {
                if (!value) {
                    return 'شماره موبایل نمیتواند خالی باشد'
                } else {
                    if (!validatePhoneNumber(value)) return 'شماره موبایل معتبر نیست'
                }
            },
            IdGroup: (value) => {
                if (!value) return 'گروه نمیتواند خالی باشد'
            }
        }
    })
    async function handleSubmit(values: typeof form.values) {
        try {
            setLoading(true)
            const response = await insertTeammate({
                first_name: values.name,
                last_name: values.family,
                phone: values.phoneNo,
                email: values.email ?? null,
                gender: parseInt(values.gender) ?? null,
                national_code: values.codeMelli,
                department_id: values.IdGroup
            })
            if (response.success) {
                showNotification({
                    title: 'عملیات موفق',
                    message: 'همکار با موفقیت ایجاد شد',
                    color: 'green'
                })
                form.reset()
                router.push('/teammates')
            }
        } catch (err) {
            const messasge = err.response.data.message
            if (messasge === 'User exists') {
                showNotification({
                    title: 'عملیات ناموفق',
                    message: 'این شماره موبایل قبلا ثبت شده است',
                    color: 'red'
                })
            } else {
                showNotification({
                    title: 'عملیات ناموفق',
                    message: 'خطا در ایجاد همکار',
                    color: 'red'
                })
            }
        } finally {
            setLoading(false)
        }
    }
    const [provinceID, setProvinceID] = useState<string>('')


    return (
        <>
            <form
                onSubmit={form.onSubmit(handleSubmit)}
                className="w-full" encType="multipart/form-data">
                <Accordion
                    className="relative"
                    classNames={{
                        label: 'pr-8',
                        chevron: '!ml-8'
                    }}
                    defaultValue='item-1' variant="separated">
                    <LoadingOverlay visible={loading} />
                    <Accordion.Item value="item-1">
                        <Accordion.Control>اطلاعات پایه</Accordion.Control>
                        <Accordion.Panel
                            className="px-8"
                        >
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
                                        label="شماره موبایل:"
                                        placeholder="شماره موبایل"
                                        maxLength={11}
                                        {...form.getInputProps('phoneNo')}
                                    />
                                </div>
                                <div className="col-span-6">
                                    <GroupSelect
                                        {...form.getInputProps('IdGroup')}
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
                                        placeholder='آدرس ایمیل'
                                        label='آدرس ایمیل :'
                                        {...form.getInputProps('email')}
                                    />
                                </div>
                            </div>
                        </Accordion.Panel>
                    </Accordion.Item>
                </Accordion>
                <Button type="submit" className="mt-4">
                    ثبت همکار
                </Button>
            </form>
        </>
    )
}
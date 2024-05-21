'use client'

import { Accordion, Box, Center, LoadingOverlay, SegmentedControl } from "@mantine/core"
import { useEffect, useState } from "react"
import DashboardContent from "@/components/dashboardContent"
import TextInput from "@/components/textInput";
import { IoMan, IoWomanSharp } from 'react-icons/io5'
import Button from '@/components/button'
import { useForm } from "@mantine/form";
import { convertPerisnaNumbersToEnglishNumbers, validatePhoneNumber } from "utils/helper";
import Cities from "@/components/select/cities";
import Provinces from "@/components/select/province";
import { showNotification } from "@mantine/notifications";
import { editTeammate, getTeammateById, insertTeammate } from "services/teammates";
import { useRouter } from "next/navigation";
import '../confirm/style.css'
import GroupSelect from "@/components/teammates/groupSelect";

export default function EditTeammate({ id }) {

    const router = useRouter()
    const [loading, setLoading] = useState<boolean>(true)

    const form = useForm({
        initialValues: {
            id: '',
            name: '',
            family: '',
            phoneNo: '',
            email: '',
            address: '',
            codeMelli: '',
            gender: '',
            IdGroup: '',
            idProvince: '',
            IdCity: ''
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
            }
        }
    })
    async function handleSubmit(values: typeof form.values) {
        try {
            setLoading(true)
            const response = await editTeammate({
                id: id,
                first_name: values.name,
                last_name: values.family,
                phone: values.phoneNo,
                email: values.email,
                address: values.address,
                national_code: values.codeMelli,
                gender: parseInt(values.gender),
                department_id: values.IdGroup,
                city_id: values.IdCity
            })
            if (response.success) {
                showNotification({
                    title: 'عملیات موفق',
                    message: 'همکار با موفقیت ویرایش شد',
                    color: 'green'
                })
            }
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در ویرایش همکار',
                color: 'red'
            })
        } finally {
            setLoading(false)
        }
    }
    const [provinceID, setProvinceID] = useState<string>('')


    async function getTeammate() {
        try {
            const response = await getTeammateById({ id: id })
            const data = response.teammate

            form.setValues({
                'name': data?.first_name,
                'family': data.last_name,
                'phoneNo': data.phone,
                'email': data?.email,
                'IdGroup': data?.department_id,
                'codeMelli': data.national_code,
                'idProvince': data.city?.province_id,
                'address': data?.address,
                'IdCity': data?.city?.id,
                'gender': data?.gender?.toString()
            })
            setProvinceID(data.city?.province_id)
        } catch (error) {
            console.log(error);
            showNotification({
                title: 'عملیات ناموفق',
                message: "خطا در دریافت اطلاعات کاربر",
                color: 'orange'
            })
        } finally {
            setLoading(false)
        }
    }

    useEffect(() => {
        getTeammate()
    }, [])


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
                                        {...form.getInputProps('codeMelli')}
                                        onChange={(e) => {
                                            const value = convertPerisnaNumbersToEnglishNumbers(e.target.value)
                                            if (isNaN(Number(value))) {
                                                form.setFieldError('codeMelli', 'کد ملی باید عدد باشد')
                                            } else {
                                                form.setFieldError('codeMelli', null)
                                                form.setFieldValue('codeMelli', value)
                                            }
                                        }}
                                    />
                                </div>
                                <div className="col-span-6">
                                    <div className="grid grid-cols-12">
                                        <span className="col-span-3 text-sm flex items-center">جنیست :</span>
                                        <div className="col-span-9 gender">
                                            <SegmentedControl
                                                {...form.getInputProps('gender')}
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
                                <div className="col-span-6">
                                    <Provinces
                                        {...form.getInputProps('idProvince')}
                                        label="استان :"
                                        onChange={(value: string) => {
                                            setProvinceID(value)
                                            form.setFieldValue('idProvince', value)
                                        }}
                                    />
                                </div>
                                <div className="col-span-6">
                                    <Cities
                                        {...form.getInputProps('IdCity')}
                                        provinceID={provinceID}
                                        label="شهر :"
                                        onChange={(value: string) => {
                                            form.setFieldValue('IdCity', value)
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
                            </div>
                        </Accordion.Panel>
                    </Accordion.Item>
                </Accordion>
                <Button type="button" className="mt-4 ml-2" color="red"
                    onClick={() => {
                        router.push('/teammates')
                    }}
                >
                    انصراف
                </Button>
                <Button type="submit" className="mt-4">
                    ویرایش همکار
                </Button>
            </form>
        </>
    )
}
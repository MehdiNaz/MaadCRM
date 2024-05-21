'use client'

import { Accordion, Box, Center, Loader, LoadingOverlay, SegmentedControl, Text } from "@mantine/core"
import DashboardContent from "@/components/dashboardContent"
import { IoMan, IoWomanSharp } from 'react-icons/io5'
import Button from '@/components/button'
import TextInput from '@/components/textInput'
import { useForm } from '@mantine/form';
import "dayjs/locale/fa"
import { newCustomer } from "services/customer"
import { showNotification } from "@mantine/notifications"
import { useEffect, useState } from "react"
import Link from "next/link"
import axios from "utils/axios"
import Provinces from "@/components/select/province"
import Cities from "@/components/select/cities"
import { convertDate, convertPersianDate, validDate } from "utils/helper"
import DateInput from "@/components/DateInput"
import Moarefs from "@/components/customers/moarefs"
import NewCustomerFields from "@/components/customfields/newCustomer/allFields"
import { AttributeValueType, FieldType } from "@/types/customfields"
import { useDispatch, useSelector } from "react-redux"
import { AppDispatch, RootState } from "store/store"
import { resetAllFields, setFieldErrorByID, setFieldValueByID } from "@/slices/customfieldsSlice"

export default function NewCustomer() {

    const [visible, setVisible] = useState<boolean>(false)
    const [provinceSelected, setProvinceSelected] = useState<string>('')

    const [searchPhone, setSearchPhone] = useState<boolean>(false)
    const [customerFound, setCustomerFound] = useState({
        found: false,
        name: '',
        phone: '',
        id: 0,
    })

    const [resetRefer, setResetRefer] = useState<boolean>(false)
    const [resetBirthDate, setResetBirthDate] = useState<boolean>(false)


    const { fields } = useSelector((state: RootState) => state.customfields)
    const dispatch = useDispatch<AppDispatch>()

    useEffect(() => {
        console.log('fields', fields);

    }, [fields])

    /**
     * handle custom fields validation and set newCustomerCustomFields state
     * 
     * @returns boolean | any[]
     */
    function handleCustomFields() {
        let newCustomerCustomFields = []

        if (!fields || fields.length == 0) {
            return newCustomerCustomFields
        }
        let error = false

        fields.map((field: FieldType) => {

            if (field.required == true && field.type == 3 && field.value !== '') {
                dispatch(setFieldErrorByID({ id: field.id, error: true }))
            }
            if (field.required == false && field.type == 3) {
                if (field.value == '') return
                let date = convertDate(field.value)
                if (validDate(date) == false) {
                    dispatch(setFieldErrorByID({ id: field.id, error: true }))
                    error = true
                    return
                } else {
                    dispatch(setFieldValueByID({ id: field.id, value: date }))
                }
            }
            if (field.required == true && !field.value || field.required == true && field.value == '') {

                dispatch(setFieldErrorByID({
                    id: field.id,
                    error: true
                }))
                error = true
            } else {
                dispatch(setFieldErrorByID({
                    id: field.id,
                    error: false
                }))

                if (field.type == 1 && typeof field.value !== 'undefined') {
                    newCustomerCustomFields.push({
                        text_value: field.value,
                        field_id: field.id
                    })
                }
                if (field.type == 2 && typeof field.value !== 'undefined') {
                    newCustomerCustomFields.push({
                        int_value: field.value,
                        field_id: field.id
                    })
                }
                if (field.type == 3 && typeof field.value !== 'undefined' && field.value != '') {
                    newCustomerCustomFields.push({
                        date_value: convertPersianDate(field.value),
                        field_id: field.id
                    })
                }
                if (field.type == 5 && typeof field.value !== 'undefined') {
                    field.options.map((option) => {
                        newCustomerCustomFields.push({
                            bool_value: option.id == field.value ? true : false,
                            field_id: field.id,
                            option_id: option.id
                        })
                    })
                }
                if (field.type == 6 && typeof field.value !== 'undefined') {
                    if (Array.isArray(field.value)) {
                        field.options.map((option) => {
                            newCustomerCustomFields.push({
                                bool_value: field.value.includes(option.id) ? true : false,
                                field_id: field.id,
                                option_id: option.id
                            })
                        })
                    }
                }
            }
        })

        if (error) {
            return false
        }

        return newCustomerCustomFields
    }

    /**
     * Handle new customer submit
     * 
     * @param values
     * 
     * @returns void
     */
    async function handleNewClient(values: typeof form.values) {
        try {
            const newCustomerCustomFields = handleCustomFields()
            if (!newCustomerCustomFields) return
            let birthDate = null
            if (values.birthDate) {
                birthDate = convertDate(values.birthDate)
                birthDate = convertPersianDate(birthDate)
            }
            setVisible(true)
            const response = await newCustomer({
                first_name: values.name ?? null,
                last_name: values.family,
                phone: values.phone,
                email: values.email ?? null,
                gender: values.gender ? parseInt(values.gender) : null,
                customer_referral_id: values.refererId,
                city_id: values.city ? parseInt(values.city) : null,
                address: values.address ?? null,
                birthdate: birthDate,
                customfields: newCustomerCustomFields
            })
            setVisible(false)
            showNotification({ title: 'عملیات موفق', message: 'مشتری جدید با موفقیت ایجاد شد', color: 'green', })
            setResetBirthDate((prev) => !prev)
            form.reset()
            setResetRefer((prev) => !prev)
            dispatch(resetAllFields())
        } catch (err) {
            console.log(err);

            showNotification({ title: 'عملیات ناموفق', message: err.message, color: 'red' })
        } finally {
            setVisible(false)
        }
    }

    const form = useForm({
        initialValues: {
            name: '',
            family: '',
            gender: '',
            email: '',
            phone: '',
            birthDate: '',
            referer: '',
            refererId: '',
            state: 1,
            city: '',
            address: '',

        },

        validate: {
            family: (value) => {
                if (!value) return 'نام خانوادگی را وارد کنید'
            },
            phone: (value) => {
                const phoneRegex = /^(\+98|0)?9\d{9}$/
                if (!value) return 'شماره موبایل را وارد کنید'
                if (!phoneRegex.test(value)) return 'شماره موبایل را به درستی وارد کنید'
            },
            birthDate: (value) => {
                if (value != '')
                    if (!validDate(value)) return 'تاریخ تولد را به درستی وارد کنید'
            },
            email: (value) => {
                const emailRegex = /^[\w-.]+@([\w-]+\.)+[\w-]{2,4}$/
                if (value != '')
                    if (!emailRegex.test(value)) return 'ایمیل را به درستی وارد کنید'
            }
        },
    })

    async function searchCustomerByPhone(phone: string): Promise<any> {
        return new Promise(async (resolve, reject) => {
            const response = await axios.post('/customers/search', {
                search: phone
            })
            if (response.data.success && response.data.customers.length > 0) {
                showNotification({ message: 'یک مشتری با این شماره موبایل پیدا شد', color: 'yellow', })
                resolve(response.data.customers[0])
            } else {
                reject('مشتری با این شماره موبایل یافت نشد')
            }
        })
    }


    return (
        <>
            <LoadingOverlay visible={visible} overlayBlur={2} />
            <form className="w-full" onSubmit={form.onSubmit(handleNewClient)}>
                <Accordion variant="separated" multiple defaultValue={['item-1', 'item-2']}>
                    <Accordion.Item value="item-1">
                        <Accordion.Control>اطلاعات پایه</Accordion.Control>
                        <Accordion.Panel>
                            <div
                                className="grid grid-cols-12 gap-8">
                                <div className="col-span-6">
                                    <TextInput
                                        label="نام :"
                                        placeholder="نام"
                                        {...form.getInputProps('name')}
                                    />
                                </div>
                                <div className="col-span-6">
                                    <TextInput
                                        label="نام خانوادگی :"
                                        placeholder="نام خانوادگی"
                                        {...form.getInputProps('family')}
                                    />
                                </div>
                                <div className="col-span-6">
                                    <TextInput
                                        label="شماره موبایل:"
                                        placeholder="شماره موبایل"
                                        maxLength={11}
                                        rightSection={searchPhone ? <Loader size='xs' /> : ''}
                                        {...form.getInputProps('phone')}
                                        onChange={async (e) => {
                                            form.setFieldValue('phone', e.target.value)
                                            if (e.target.value.length == 11) {
                                                try {
                                                    const response = await searchCustomerByPhone(e.target.value)
                                                    if (response) {
                                                        setSearchPhone(false)
                                                        setCustomerFound({
                                                            found: true,
                                                            name: response.first_name ?? '' + ' ' + response.last_name,
                                                            phone: response.phone,
                                                            id: response.id,
                                                        })
                                                    }
                                                } catch (err) {
                                                    setSearchPhone(false)
                                                    setCustomerFound({
                                                        found: false,
                                                        name: '',
                                                        phone: '',
                                                        id: 0,
                                                    })
                                                }
                                            }
                                        }}
                                    />
                                    {customerFound.found === true && (
                                        <Link href={`/customers/profile/${customerFound.id}`} className="grid grid-cols-12">
                                            <div className="col-start-4 col-span-9 bg-white rounded-md shadow-md text-center flex  justify-between p-3">
                                                <span className="text-12p">
                                                    {customerFound.name}
                                                </span>
                                                <span className="text-12p">
                                                    {customerFound.phone}
                                                </span>
                                            </div>
                                        </Link>
                                    )}
                                </div>
                                <div className="col-span-6 grid grid-cols-12">
                                    <span className="col-span-3 flex items-center text-sm">جنسیت :</span>
                                    <SegmentedControl
                                        className="col-span-9 h-max"
                                        onChange={(value) => form.setFieldValue('gender', value)}
                                        data={[
                                            {
                                                value: '1',
                                                label: (
                                                    <Center onClick={() => form.setFieldValue('gender', '1')}>
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
                                <div className="col-span-6">
                                    <TextInput
                                        label="ایمیل :"
                                        placeholder="ایمیل"
                                        {...form.getInputProps('email')}
                                    />
                                </div>
                                <div className="col-span-6 grid">
                                    <DateInput
                                        label="تاریخ تولد :"
                                        reset={resetBirthDate}
                                        onChange={(value) => {
                                            form.setValues({ 'birthDate': value })
                                        }}
                                        error={form.errors.birthDate}
                                    />
                                </div>
                                <div className="col-span-6 relative">
                                    <Moarefs
                                        onSubmit={(value: string) => {
                                            form.setValues({ 'refererId': value })
                                        }}
                                        reset={resetRefer}
                                    />
                                </div>
                                <div className="col-span-6">
                                    <Provinces
                                        {...form.getInputProps('state')}
                                        error={form.errors.state && (
                                            <Text fz="xs" color='red'>استان را انتخاب کنید</Text>
                                        )}
                                        onChange={(value) => {
                                            setProvinceSelected(value)
                                            form.setFieldValue('state', value)
                                        }}
                                    />
                                </div>
                                <div className="col-span-6">
                                    <Cities
                                        label="شهر :"
                                        disabled={provinceSelected === ''}
                                        provinceID={provinceSelected}
                                        onChange={(value: string) => {
                                            form.setFieldValue('city', value)
                                        }}
                                        {...form.getInputProps('city')}
                                    />
                                </div>
                                <div className="col-span-6">
                                    <TextInput
                                        label="آدرس :"
                                        placeholder="آدرس"
                                        {...form.getInputProps('address')}
                                    />
                                </div>
                            </div>
                        </Accordion.Panel>
                    </Accordion.Item>
                    <Accordion.Item value="item-2">
                        <Accordion.Control>اطلاعات تکمیلی</Accordion.Control>
                        <Accordion.Panel>
                            <NewCustomerFields />
                        </Accordion.Panel>
                    </Accordion.Item>
                </Accordion>
                <Button type="submit" className="mt-4">
                    ثبت مشتری
                </Button>
            </form>
        </>
    )
}
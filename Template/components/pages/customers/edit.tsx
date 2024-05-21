'use client'

import { Accordion, Box, Center, Loader, LoadingOverlay, SegmentedControl, Text } from "@mantine/core"
import DashboardContent from "@/components/dashboardContent"
import { IoMan, IoWomanSharp } from 'react-icons/io5'
import Button from '@/components/button'
import TextInput from '@/components/textInput'
import { useForm } from '@mantine/form';
import "dayjs/locale/fa"
import { getCustomerByID, updateCustomer } from "services/customer"
import { showNotification } from "@mantine/notifications"
import { useEffect, useState } from "react"
import Link from "next/link"
import axios from "utils/axios"
import Provinces from "@/components/select/province"
import Cities from "@/components/select/cities"
import { convertDate, convertDateToPerisan, convertPerisnaNumbersToEnglishNumbers, convertPersianDate, disableInputsandButtons, enableInputsandButtons, validDate } from "utils/helper"
import DateInput from "@/components/DateInput"
import Moarefs from "@/components/customers/moarefs"
import NewCustomerFields from "@/components/customfields/newCustomer/allFields"
import { useDispatch, useSelector } from "react-redux"
import { AppDispatch, RootState } from "store/store"
import { setFieldErrorByID, setFields, setFieldValueByID } from "@/slices/customfieldsSlice"
import { FieldType } from "@/types/customfields"

export default function EditCustomer({ id }) {

    const [visible, setVisible] = useState<boolean>(true)
    const [provinceSelected, setProvinceSelected] = useState<string>('')
    const [citySelected, setCitySelected] = useState<string>('')

    const [customer, setCustomer] = useState({
        city: ''
    })


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
            if (field.required == true && field.type == 3 || field.required == false && field.type == 3 && field.value !== '') {
                dispatch(setFieldErrorByID({ id: field.id, error: true }))
                let date = convertDate(field.value)
                if (validDate(date) == false) {
                    dispatch(setFieldErrorByID({ id: field.id, error: true }))
                    error = true
                    return
                } else {
                    // let gdate = convertPersianDate(date)
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
                        // ValueString: field.value,
                        // IdAttributeOption: field.attributeOptions && field.attributeOptions.length == 1 ? field.attributeOptions[0].id : null
                    })
                }
                if (field.type == 2 && typeof field.value !== 'undefined') {
                    newCustomerCustomFields.push({
                        int_value: field.value,
                        field_id: field.id
                        // ValueString: '',
                        // ValueNumber: field.value,
                        // IdAttributeOption: field.attributeOptions && field.attributeOptions.length == 1 ? field.attributeOptions[0].id : null
                    })
                }
                if (field.type == 3 && typeof field.value !== 'undefined' && field.value != '') {
                    newCustomerCustomFields.push({
                        date_value: convertPersianDate(field.value),
                        field_id: field.id
                        // ValueString: '',
                        // ValueDate: convertPersianDate(field.value),
                        // IdAttributeOption: field.attributeOptions && field.attributeOptions.length == 1 ? field.attributeOptions[0].id : null
                    })
                }
                if (field.type == 5 && typeof field.value !== 'undefined') {
                    field.options.map((option) => {
                        newCustomerCustomFields.push({
                            option_id: option.id,
                            field_id: field.id,
                            bool_value: option.id == field.value ? true : false,
                            // ValueString: '',
                            // ValueBool: option.id == field.value ? true : false,
                            // IdAttributeOption: option.id
                        })
                    })
                }
                if (field.type == 6 && typeof field.value !== 'undefined') {
                    field.options.map((option) => {
                        newCustomerCustomFields.push({
                            option_id: option.id,
                            field_id: field.id,
                            bool_value: field.value.includes(option.id) ? true : false,
                            // ValueString: '',
                            // ValueBool: option.id == field.value ? true : false,
                            // IdAttributeOption: option.id
                        })
                    })
                }
            }
        })

        if (error) {
            return false
        }
        console.log(newCustomerCustomFields);

        return newCustomerCustomFields
    }


    async function handleEdit(values: typeof form.values) {
        try {
            const newCustomerCustomFields = handleCustomFields()
            if (!newCustomerCustomFields) return
            disableInputsandButtons()
            let birthDate = null
            if (values.birthDate != null) {
                birthDate = convertDate(values.birthDate)
                birthDate = convertPersianDate(birthDate)
            }
            setVisible(true)

            const response = await updateCustomer({
                customer_id: id,
                first_name: values.name,
                last_name: values.family,
                phone: values.phone,
                email: values.email,
                gender: parseInt(values.gender),
                customer_referral_id: values.refererId,
                city_id: values.city,
                address: values.address,
                birthdate: birthDate,
                customfields: newCustomerCustomFields,
                // AttributesValue: newCustomerCustomFields,
            })
            if (response) {
                setVisible(false)
                showNotification({ title: 'عملیات موفق', message: 'مشتری با موفقیت ویرایش شد', color: 'green', })

            }
        } catch (err) {
            setVisible(false)
            showNotification({ title: 'عملیات ناموفق', message: err.message, color: 'red' })
        } finally {
            enableInputsandButtons()
        }
    }

    const form = useForm({
        initialValues: {
            name: '',
            family: '',
            gender: '1',
            email: '',
            phone: '',
            birthDate: null,
            referer: '',
            refererId: '',
            state: 1,
            province: '',
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
            }, birthDate: (value) => {
                if (value && value != '')
                    if (!validDate(value)) return 'تاریخ تولد را به درستی وارد کنید'
            }, email: (value) => {
                const emailRegex = /^[\w-.]+@([\w-]+\.)+[\w-]{2,4}$/
                if (value && value != '')
                    if (!emailRegex.test(value)) return 'ایمیل را به درستی وارد کنید'
            }
        },
    })

    const [searchPhone, setSearchPhone] = useState<boolean>(false)
    const [customerFound, setCustomerFound] = useState({
        found: false,
        name: '',
        phone: '',
        id: 0,
    })

    const [resetRefer, setResetRefer] = useState<boolean>(false)
    const [refer, setRefer] = useState<string>('')

    async function searchCustomerByPhone(phone: string): Promise<any> {
        return new Promise(async (resolve, reject) => {
            const response = await axios.get('/Customer/CustomerBySearchItem/' + phone)
            if (response.data.valid && response.data.data.allCustomersInfo.length > 0) {
                showNotification({ message: 'یک مشتری با این شماره موبایل پیدا شد', color: 'yellow', })
                resolve(response.data.data.allCustomersInfo[0])
            } else {
                reject('مشتری با این شماره موبایل یافت نشد')
            }
        })
    }

    const { fields } = useSelector((state: RootState) => state.customfields)
    const dispatch = useDispatch<AppDispatch>()

    const [customerAttributes, setCustomerAttributes] = useState<Array<any>>([])

    async function getCustomer() {
        const response = await getCustomerByID({ id: id })
        setProvinceSelected(response.customer.customer.city?.province_id)
        setCitySelected(response.idCity)
        setCustomer(customer => ({ ...customer, city: response.idCity }))
        setVisible(false)
        let birthDate = null
        if (response.customer.customer.birthdate != null) {
            birthDate = convertDateToPerisan(response.customer.customer.birthdate)
        }
        form.setValues({
            name: response.customer.customer.first_name,
            family: response.customer.customer.last_name,
            phone: response.customer.customer.phone,
            email: response.customer.customer.email,
            address: response.customer.customer.address,
            birthDate: birthDate,
            province: response.customer.customer.city?.province_id,
            city: response.customer.customer.city_id,
            gender: response.customer.customer.gender?.toString(),
            refererId: response.customer.customer?.customer_referral?.id,
        })
        if (response.customer.customer.customer_referral_id != null) {
            let refferal_name = ''
            if (response.customer.customer?.customer_referral?.first_name) {
                refferal_name = response.customer.customer?.customer_referral?.first_name + ' ' + response.customer.customer?.customer_referral?.last_name
            } else {
                refferal_name = response.customer.customer?.customer_referral?.last_name
            }
            setRefer(refferal_name)
        }

        const attributes = await response?.customer.customfields
        setCustomerAttributes(attributes)
    }

    useEffect(() => {
        getCustomer()
    }, [])

    return (
        <>
            <form className="w-full" encType="multipart/form-data" onSubmit={form.onSubmit(handleEdit)}>
                <Accordion multiple defaultValue={['item-1', 'item-2']} variant="separated" className="relative">
                    <LoadingOverlay visible={visible} overlayBlur={2} />
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
                                                            name: response.name,
                                                            phone: response.phoneNumber,
                                                            id: response.customerId,
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
                                    {
                                        customerFound.found === true && (
                                            <Link href={`/customers/edit/${customerFound.id}`} className="grid grid-cols-12">
                                                <div className="col-start-4 col-span-9 bg-white rounded-md shadow-md text-center flex  justify-between p-3">
                                                    <span className="text-12p">
                                                        {customerFound.name}
                                                    </span>
                                                    <span className="text-12p">
                                                        {customerFound.phone}
                                                    </span>
                                                </div>
                                            </Link>
                                        )
                                    }
                                </div>
                                <div className="col-span-6 grid grid-cols-12">
                                    <span className="col-span-3 flex items-center text-sm">جنسیت :</span>
                                    <SegmentedControl
                                        className="col-span-9"
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
                                <div className="col-span-6">
                                    <TextInput
                                        label="ایمیل :"
                                        placeholder="ایمیل"
                                        {...form.getInputProps('email')}
                                    />
                                </div>
                                <div className="col-span-6">
                                    <DateInput
                                        label="تاریخ تولد :"
                                        value={form.values.birthDate}
                                        onChange={(value) => {
                                            form.setValues({ 'birthDate': value })
                                        }}
                                        error={form.errors.birthDate}
                                    />
                                </div>
                                <div className="col-span-6 relative">
                                    <Moarefs
                                        onSubmit={(value: any) => {
                                            form.setValues({ 'refererId': value })
                                        }}
                                        defaultValue={refer}
                                        reset={resetRefer}
                                    />
                                </div>
                                <div className="col-span-6">
                                    <Provinces
                                        error={form.errors.province && (
                                            <Text fz="xs" color='red'>استان را انتخاب کنید</Text>
                                        )}
                                        {...form.getInputProps('province')}
                                        onChange={(value) => {
                                            setProvinceSelected(value)
                                            form.setFieldValue('province', value)
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
                            <NewCustomerFields attributes={customerAttributes} />
                        </Accordion.Panel>
                    </Accordion.Item>
                </Accordion>
                <Button type="submit" className="mt-4">
                    ویرایش مشتری
                </Button>
            </form>
        </>
    )
}
'use client'

import { useEffect, useState } from "react"
import DashboardContent from '@/components/dashboardContent'
import { FileInput, MultiSelect, Select, Switch, Text, TextInput } from "@mantine/core"
import Button from '@/components/button'
import { DateInput } from "mantine-datepicker-jalali";
import "dayjs/locale/fa"
import Link from "next/link"
import { BiFace } from "react-icons/bi"
import { FiActivity, FiAlertOctagon, FiAward } from "react-icons/fi"
import Card from "@/components/card"
import { useRouter, useSearchParams } from "next/navigation"
import Modal from "@/components/modal"
import Drawer from "@/components/drawer"
import { FaCamera } from "react-icons/fa"
import ClientsTable from "@/components/tables/clientsTable"
import { useForm } from "@mantine/form"
import { HiDownload } from "react-icons/hi"
import { useDispatch, useSelector } from "react-redux"
import { fetchCustomers, setAllCustomers, setLoading } from "slices/customerSlice"
import { AppDispatch, RootState } from "store/store"
import NotFound from "@/components/icons/notFound"
import { CustomersState } from "@/types/clients"
import Provinces from "@/components/select/province"
import ProductsSelect from "@/components/products/productsSelect"
import { CustomerStateNumber } from "@/types/customer"
import Cities from "@/components/select/cities"
import { fetchFields } from "@/slices/customfieldsSlice"
import { FieldType } from "@/types/customfields"

export default function Customters() {

    const [filters, setFilters] = useState({
        state: false,
        gender: false,
    })

    const dispatch = useDispatch<AppDispatch>()
    const { customers, loading, fetch, belghovehCount, darHalePeyGiryCount, belFelCount, razyCount, naRazyCount, vafadarCount, total } = useSelector((state: RootState) => state.customers)
    const [filtersOpen, setFiltersOpen] = useState({
        open: false,
        provinceFetch: false,
        cityFetch: false,
        provincees: [],
        cities: [],
        customfields: []
    })
    const [newNoteOpen, setNewNoteOpen] = useState<boolean>(false)
    const [filterProvinceID, setFilterProvinceID] = useState<string>('')
    const searchParams = useSearchParams()
    const search = searchParams.get('s') || ''
    const state = parseInt(searchParams.get('state')) || null
    const gender = parseInt(searchParams.get('gender')) || null
    const province = searchParams.get('province') || null
    const city = searchParams.get('city') || null

    useEffect(() => {
        setAllCustomers([])
        dispatch(setLoading(true))
        dispatch(fetchCustomers({
            search: search,
            state: state,
            gender: gender,
            province: province
        }))

        if (state != null) {
            form.setValues({
                'state': state.toString()
            })
            setFilters((filter) => ({ ...filter, state: true }))
        }
        if (gender != null) {
            form.setValues({
                'gender': gender.toString()
            })
        }
        if (province != null) {
            form.setValues({
                'provinceId': province
            })
        }
        if (city != null) {
            form.setValues({
                'cityId': city
            })
        }
    }, [searchParams])

    const router = useRouter()

    const form = useForm({
        initialValues: {
            state: state ? state : '',
            gender: gender ? gender : '',
            provinceId: province ? province : '',
            cityId: city ? city : ''
        }
    })


    function handleFilterSubmit(e) {
        e.preventDefault()
        dispatch(setLoading(true))
        let url = 's='
        const state = form.values.state
        const gender = form.values.gender
        const province = form.values.provinceId

        if (state) {
            url += `&state=${state}`
        }
        if (gender) {
            url += `&gender=${gender}`
        }
        if (province) {
            url += `&province=${province}`
        }
        console.log(filtersOpen.customfields);

        return
        if (filtersOpen.customfields.length > 0) {
            //url like this 
            //"customfields": [
            //     {
            //         "field_id": "8ae01bea-26af-4da4-9bd7-ce0c0c8b45e5",
            //         "option_id": null,
            //         "int_value": null,
            //         "text_value": "",
            //         "bool_value": null
            //     }
            // ]
            url += '&customfields=' + JSON.stringify(filtersOpen.customfields)
        }

        router.push(`/customers?${url}`)
        setFiltersOpen(prev => ({ ...prev, open: false }))
    }

    const [customfields, setCustomfields] = useState([])

    const { fields } = useSelector((state: RootState) => state.customfields)

    useEffect(() => {
        dispatch(fetchFields())
    }, [])

    useEffect(() => {
        fields.map((field: FieldType) => {
            setCustomfields([])
            if (field.type == 5 || field.type == 6) {
                setCustomfields(prev => [...prev, field])
            }
        })
    }, [fields])


    function handleChangeCustomField(value: string[], field_id: string) {
        setFiltersOpen(prev => ({ ...prev, customfields: [] }))
        if (Array.isArray(value)) {
            console.log(value);

            value.map((val: string) => {
                setFiltersOpen(prev => ({ ...prev, customfields: [...prev.customfields, { field_id: field_id, option_id: val, bool_value: true }] }))
            })
        } else {
            console.log(value);

            // setFiltersOpen(prev => ({ ...prev, customfields: [...prev.customfields, { field_id: field_id, option_id: value }] }))
        }

    }


    return (
        <>
            <Modal opened={newNoteOpen} onClose={() => setNewNoteOpen(false)} title="افزودن یادداشت" size='70%'>
                <form>
                    <div className="grid grid-cols-2 w-full gap-4 mt-8">
                        <div className="grid grid-cols-12">
                            <span className="leading-8 col-span-4 flex items-start">توضیحات :</span>
                            <textarea className="min-h-[80px] col-span-8 rounded-md bg-white shadow-md"></textarea>
                        </div>
                        <div className="grid grid-cols-12">
                            <span className="leading-8 col-span-4 flex items-start">انتخاب محصول :</span>
                            <Select
                                clearable
                                className="w-full col-span-8"
                                placeholder="انتخاب محصول"
                                searchable
                                data={[
                                    { value: '1', label: 'محصول شماره یک' },
                                    { value: '2', label: 'محصول شماره دو' },
                                ]}
                            />
                        </div>
                        <div className="grid grid-cols-12">
                            <span className="leading-8 col-span-4 flex items-start">هشتگ :</span>
                            <TextInput classNames={{ input: 'rounded-md bg-white shadow-md', }} className="col-span-8" />
                        </div>
                        <div className="grid grid-cols-12">
                            <span className="leading-8 col-span-4 flex items-start">پیوست :</span>
                            <FileInput
                                className="col-span-8"
                                placeholder="انتخاب فایل"
                                variant="filled"
                            />
                        </div>
                        <div className="grid grid-cols-12">
                            <span className="leading-8 col-span-4 flex items-start">تاریخ یادداشت :</span>
                            {/* <DateRangePicker
                            placeholder="Pick dates range"
                        /> */}
                        </div>
                    </div>
                </form>
            </Modal>
            <div className="flex items-center justify-between w-full">
                <div className="flex items-center">
                    <span>تعداد کل مشتریان :</span>
                    <span className="text-2xl font-bold mr-3">
                        {total}
                    </span>
                </div>
                <div>
                    <Button
                        className="text-sm"
                        onClick={() => setFiltersOpen(prev => ({ ...prev, open: true }))}
                    >
                        فیلتر ها
                    </Button>
                </div>
            </div>
            <Drawer
                opened={filtersOpen.open}
                position="right"
                onClose={() => setFiltersOpen(prev => ({ ...prev, open: false }))}
                title="فیلتر مشتریان"
                padding="xl"
                size="md"
                classNames={{
                    header: "border-b-2 border-primary pb-2 mb-8 z-50",
                }}
            >
                <form
                    onSubmit={(e) => handleFilterSubmit(e)}
                    className="grid gap-4 grid-cols-1 relative pb-16">
                    <div className="col-span-4">
                        <Select
                            clearable
                            className="w-full"
                            placeholder="وضعیت مشتری"
                            searchable
                            data={[
                                { value: '1', label: CustomersState.BELGHOVEH },
                                { value: '2', label: CustomersState.BELFEL },
                                { value: '3', label: CustomersState.RAZI },
                                { value: '4', label: CustomersState.NARAZI },
                                { value: '5', label: CustomersState.DARHALPEYGIRI },
                                { value: '6', label: CustomersState.VAFADAR },
                            ]}
                            {...form.getInputProps('state')}
                        />
                    </div>
                    <div className="col-span-4">
                        <Select
                            clearable
                            className="w-full"
                            placeholder="جنسیت"
                            data={[
                                { value: '1', label: 'مرد' },
                                { value: '2', label: 'زن' },
                            ]}
                            {...form.getInputProps('gender')}
                        />
                    </div>
                    <div className="col-span-4">
                        {filtersOpen.open && (
                            <Provinces
                                label={null}
                                onChange={(value: string) => {
                                    form.setValues({ 'provinceId': value })
                                    setFilterProvinceID(value)
                                    setFiltersOpen(prev => ({ ...prev, provinceFetch: true }))
                                }}
                            />
                        )}
                    </div>
                    <div className="col-span-4">
                        {filtersOpen.open && (
                            <Cities
                                label={null}
                                provinceID={filterProvinceID}
                                onChange={(value: string) => {
                                    form.setValues({ 'cityId': value })
                                    setFiltersOpen(prev => ({ ...prev, cityFetch: true }))
                                }}
                            />
                        )}
                    </div>
                    <div className="col-span-4 border-t-2 pt-4">
                        {customfields.map((field: FieldType) =>
                            field.type == 5 ?
                                <Select
                                    clearable
                                    className="w-full"
                                    placeholder={field.title}
                                    label={field.title}
                                    data={field.options.map((option: any) => {
                                        return {
                                            value: option.id,
                                            label: option.title
                                        }
                                    })}
                                    onChange={(value: string) => {
                                    }}
                                /> : (
                                    <MultiSelect
                                        clearable
                                        className="w-full"
                                        placeholder={field.title}
                                        label={field.title}
                                        data={field.options.map((option: any) => {
                                            return {
                                                value: option.id,
                                                label: option.title
                                            }
                                        })}
                                        onChange={(value: string[]) => handleChangeCustomField(value, field.id)}
                                    />)
                        )}
                    </div>
                    <div className="absolute bottom-0 left-0 right-0 mx-auto flex justify-center">
                        <Button type="submit" className="w-full text-center block">اعمال فیلتر</Button>
                    </div>
                </form>
            </Drawer>
            <div className="w-full pt-4 pb-7 my-4 border-white border-t-2 border-b-2">
                <div className="grid grid-cols-6 gap-4">
                    <Link href={'customers?s=&state=' + CustomerStateNumber.Belghoveh}>
                        <Card active={state == CustomerStateNumber.Belghoveh} icon={<FiActivity />} title={belghovehCount} description="مشتریان بالقوه" />
                    </Link>
                    <Link href={'customers?s=&state=' + CustomerStateNumber.DarHalePeyGiry}>
                        <Card active={state == CustomerStateNumber.DarHalePeyGiry} icon={<FiAlertOctagon />} title={darHalePeyGiryCount} description="در حال پیگیری" />
                    </Link>
                    <Link href={'customers?s=&state=' + CustomerStateNumber.Belfel}>
                        <Card active={state == CustomerStateNumber.Belfel} icon={<FiAward />} title={belFelCount} description="مشتری بالفعل" />
                    </Link>
                    <Link href={'customers?s=&state=' + CustomerStateNumber.Razy}>
                        <Card active={state == CustomerStateNumber.Razy} icon={<BiFace />} title={razyCount} description="مشتری راضی" />
                    </Link>
                    <Link href={'customers?s=&state=' + CustomerStateNumber.NaRazy}>
                        <Card active={state == CustomerStateNumber.NaRazy} icon={<FiAward />} title={naRazyCount} description="مشتری ناراضی" />
                    </Link>
                    <Link href={'customers?s=&state=' + CustomerStateNumber.Vafadar}>
                        <Card active={state == CustomerStateNumber.Vafadar} icon={<FiAward />} title={vafadarCount} description="مشتری وفادار" />
                    </Link>
                </div>
            </div>

            <div className="flex flex-col mt-8">
                {loading == false && customers.length == 0 && fetch ? (
                    <div className="w-full flex justify-center flex-col items-center">
                        <NotFound />
                        <span className="block text-center leading-10">مشتری یافت نشد</span>
                        {total == 0 && (
                            <Link href='/customers/new'>
                                <Button className="mt-8">
                                    افزودن مشتری
                                </Button>
                            </Link>
                        )}
                    </div>
                ) : (
                    <>
                        <div className="w-full flex justify-end mb-8 hidden">
                            <button type="button" className="!bg-transparent border border-black flex px-3 py-2 rounded-md">
                                <i>
                                    <HiDownload />
                                </i>
                                <span className="text-sm mr-3">دریافت خروجی</span>
                            </button>
                        </div>
                        <ClientsTable
                            data={customers.length > 0 ? customers : []}
                        />
                    </>
                )}
            </div>
        </>
    )
}
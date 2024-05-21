'use client'

import DateInput from "@/components/DateInput"
import DashboardContent from "@/components/dashboardContent";
import PageBox from "@/components/pageBox";
import TextInput from "@/components/textInput";
import { convertDateToPerisan, convertPerisnaNumbersToEnglishNumbers } from "@/utils/helper";
import { Box, Center, Progress, RingProgress, SegmentedControl, Skeleton } from "@mantine/core";
import { useForm } from "@mantine/form";
import { useEffect, useState } from "react";
import { IoMan, IoWomanSharp } from "react-icons/io5";
import './style.css'
import Provinces from "@/components/select/province";
import Cities from "@/components/select/cities";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "store/store";
import { fetchUser } from "@/slices/userSlice";
import Button from "@/components/button";
export default function Account() {

    const { loading, first_name, last_name, phone, email, address, national_code, birthdate } = useSelector((state: RootState) => state.user)

    const form = useForm({
        initialValues: {
            first_name: '',
            last_name: '',
            national_code: '',
            email: '',
            phone: '',
            address: '',
            birthdate: '1384-01-21',
        },
    })

    const dispatch = useDispatch<AppDispatch>()
    useEffect(() => {
        dispatch(fetchUser())
    }, [])

    useEffect(() => {
        if (loading == true) return
        form.setValues({
            first_name,
            last_name,
            national_code,
            email,
            phone,
            address,
            birthdate: convertDateToPerisan(birthdate)
        })
    }, [loading])

    async function updateProfle(values: typeof form.values) {
        console.log(values);
    }

    return (
        <div className="w-full grid grid-cols-12 gap-4 mt-8">
            <div className="col-span-12 xl:col-span-12">
                <form className="w-full" onSubmit={form.onSubmit(updateProfle)}>
                    <PageBox title="اطلاعات کاربری">
                        {/* {loading == true ? (
                            <div className="w-full grid grid-cols-2 gap-5">
                                <Skeleton height={35} />
                                <Skeleton height={35} />
                                <Skeleton height={35} />
                                <Skeleton height={35} />
                                <Skeleton height={35} />
                                <Skeleton height={35} />
                                <Skeleton height={35} />
                                <Skeleton height={35} />
                                <Skeleton height={35} />
                            </div>
                        ) : ( */}
                        <div className="w-full grid grid-cols-2 gap-5">
                            <div className="col-span-1">
                                <TextInput
                                    label="نام"
                                    placeholder="نام"
                                    {...form.getInputProps('first_name')}
                                />
                            </div>
                            <div className="col-span-1">
                                <TextInput
                                    label="نام خانوادگی"
                                    placeholder="نام خانوادگی"
                                    {...form.getInputProps('last_name')}
                                />
                            </div>
                            <div className="col-span-1">
                                <TextInput
                                    placeholder='کد ملی'
                                    label='کد ملی :'
                                    maxLength={10}
                                    {...form.getInputProps('national_code')}
                                    onChange={(e) => {
                                        const value = convertPerisnaNumbersToEnglishNumbers(e.target.value)
                                        if (isNaN(Number(value))) {
                                            form.setFieldError('national_code', 'کد ملی باید عدد باشد')
                                        } else {
                                            form.setFieldError('national_code', null)
                                            form.setFieldValue('national_code', value)
                                        }
                                    }}
                                />
                            </div>
                            <div className="col-span-1">
                                <DateInput
                                    label="تاریخ تولد :"
                                    value={'2005-04-10'}
                                    onChange={(value) => {
                                        form.setValues({ 'birthdate': value })
                                    }}
                                    error={form.errors.birthdate}
                                />
                            </div>
                            <div className="col-span-1">
                                <div className="w-full grid grid-cols-12">
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
                            <div className="col-span-1">
                                <TextInput
                                    placeholder='آدرس ایمیل'
                                    label='آدرس ایمیل :'
                                    {...form.getInputProps('email')}
                                />
                            </div>
                            <div className="col-span-1">
                                <Provinces
                                    {...form.getInputProps('state')}
                                    onChange={(value: string) => {
                                        // setProvinceID(value)
                                        form.setFieldValue('state', value)
                                    }}
                                />
                            </div>
                            <div className="col-span-1">
                                <Cities
                                    // provinceID={provinceID}
                                    {...form.getInputProps('city')}
                                    onChange={(value: string) => {
                                        form.setFieldValue('city', value)
                                    }}
                                />
                            </div>
                            <div className="col-span-1">
                                <TextInput
                                    label='آدرس :'
                                    placeholder="آدرس خود را وارد کنید"
                                    {...form.getInputProps('address')}
                                />
                            </div>
                        </div>
                        {/* )} */}
                    </PageBox>
                    <div className="w-full flex mt-4">
                        <Button
                            className="ml-auto"
                            onClick={() => updateProfle(form.values)}
                        >
                            ذخیره تغییرات
                        </Button>
                    </div>
                </form>
            </div>
        </div>
    )
}
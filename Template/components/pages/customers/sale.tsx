'use client'
import DashboardContent from "@/components/dashboardContent"
import { Head } from "@/components/form"
import SelectBox from "@/components/selectBox"
import TextInput from "@/components/textInput"
import { Tabs } from "@mantine/core"
import { DateInput } from "mantine-datepicker-jalali"
import "dayjs/locale/fa"
import MaadButton from "@/components/button"
// import InputNumber from "@/components/InputNumber"

export default function Sale() {

    function handleAgsat() {
        alert('محاسبه اقساط')
    }

    return (
        <DashboardContent active_menu="clients" breadcrumbTitle="مشتریان">
            <div className="w-full bg-white rounded-b-md shadow-sm border-t-4 border-primary pb-5">
                <div className="w-full px-4 py-4 border-b">
                    <Head title="ثبت فروش" />
                </div>
                <div className="px-4 mt-5">
                    <Tabs defaultValue="naghdi">
                        <Tabs.List position="center" className="mb-8">
                            <Tabs.Tab value="naghdi">تسویه نقدی</Tabs.Tab>
                            <Tabs.Tab value="gheire_naghdi">تسویه غیرنقدی</Tabs.Tab>
                        </Tabs.List>
                        <Tabs.Panel value="naghdi" pt="xs">
                            <div className="w-full grid grid-cols-12 gap-8 border-b pb-8 border-black">
                                <div className="col-span-6">
                                    <SelectBox
                                        label="کالا / خدمات :"
                                        placeholder="کالا / خدمات"
                                        searchable
                                        defaultValue="1"
                                        data={[
                                            { label: 'آیلتس', value: '1' },
                                            { label: 'برنامه نویسی', value: '2' },
                                        ]}
                                    />
                                </div>
                                <div className="col-span-6">
                                    <TextInput
                                        label="قیمت :"
                                        placeholder="قیمت"
                                    />
                                </div>
                                <div className="col-span-6">
                                    <TextInput
                                        label="مبلغ پرداختی :"
                                        placeholder="مبلغ پرداختی"
                                    />
                                </div>
                                <div className="col-span-6">
                                    <TextInput
                                        label="تخفیف :"
                                        placeholder="تخفیف"
                                    />
                                </div>
                                <div className="col-span-6">
                                    <TextInput
                                        label="درصد سود :"
                                        placeholder="درصد سود"
                                    />
                                </div>
                                <div className="col-span-6">
                                    <TextInput
                                        label="تعداد اقساط :"
                                        placeholder="تعداد اقساط"
                                    />
                                </div>
                                <div className="col-span-6">
                                    <TextInput
                                        label="مبلغ کل سود :"
                                        placeholder="مبلغ کل سود"
                                    />
                                </div>
                                <div className="col-span-6">
                                    <TextInput
                                        label="مبلغ مانده :"
                                        placeholder="مبلغ مانده"
                                    />
                                </div>
                                <div className="col-span-6">
                                    <TextInput
                                        label="بازه زمانی پرداخت :"
                                        placeholder="بازه زمانی پرداخت"
                                    />
                                </div>
                                <div className="col-span-6 grid grid-cols-12">
                                    <div className="col-span-3 items-center flex">شروع پرداخت :</div>
                                    <DateInput
                                        className="col-span-9"
                                        placeholder="تاریخ شروع پرداخت"
                                        locale="fa"
                                        firstDayOfWeek={6}
                                        weekendDays={[5]}
                                    />
                                </div>
                                <div className="col-span-6">
                                    <TextInput
                                        label="تعداد :"
                                        placeholder="تعداد"
                                    />
                                </div>
                                <div className="col-span-6 flex justify-end">
                                    <MaadButton
                                        onClick={handleAgsat}
                                    >
                                        محاسبه اقساط
                                    </MaadButton>
                                </div>
                            </div>
                        </Tabs.Panel>
                        <Tabs.Panel value="gheire_naghdi" pt="xs">
                        </Tabs.Panel>
                    </Tabs>
                </div>
            </div>
        </DashboardContent>
    )
}
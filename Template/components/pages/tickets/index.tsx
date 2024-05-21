'use client'

import { useState } from 'react'
import DashboardContent from '@/components/dashboardContent'
import { Button, TextInput, Select, Textarea } from '@mantine/core'
import TicketItem from '@/components/tickets/item'
import { BiSend } from 'react-icons/bi'
import MaadModal from '@/components/modal'
import MaadButton from '@/components/button'

export default function Tickets() {
    const [newTicketOpen, setNewTicketOpen] = useState(false)
    return (
        <DashboardContent active_menu="tickets" breadcrumbTitle="درخواست های پشتیبانی">
            <div className="mt-4">
                <div className="w-full grid grid-cols-12 gap-4">
                    <div className="col-span-3">
                        <Button
                            fullWidth
                            onClick={() => setNewTicketOpen((value) => !value)}
                        >
                            ثبت درخواست جدید
                        </Button>
                        <MaadModal
                            title="ثبت درخواست جدید"
                            opened={newTicketOpen}
                            onClose={() => setNewTicketOpen(false)}
                            size="70%"
                            classNames={{
                                body: 'border-t-2 border-primary pt-4',
                            }}
                        >
                            <form className="grid grid-cols-1 gap-6">
                                <div className="grid grid-cols-12 items-center">
                                    <div className="col-span-2">
                                        <span>عنوان درخواست</span>
                                    </div>
                                    <div className="col-span-10">
                                        <TextInput
                                            placeholder="عنوان درخواست خود را وارد کنید"
                                        />
                                    </div>
                                </div>
                                <div className="grid grid-cols-12">
                                    <div className="col-span-6 grid grid-cols-12 items-center">
                                        <span className="col-span-4">اولویت</span>
                                        <Select
                                            className="col-span-8"
                                            placeholder="انتخاب کنید"
                                            data={[
                                                { label: 'عادی', value: '1' },
                                                { label: 'معمولی', value: '2' },
                                                { label: 'زیاد', value: '3' },
                                            ]}
                                        />
                                    </div>
                                    <div className="col-span-6 grid grid-cols-12 items-center">
                                        <span className="col-span-4 pr-4">بخش</span>
                                        <Select
                                            className="col-span-8"
                                            placeholder="انتخاب کنید"
                                            data={[
                                                { label: 'فروش', value: '1' },
                                                { label: 'پشتیبانی', value: '2' },
                                                { label: 'اپراتور', value: '3' },
                                            ]}
                                        />
                                    </div>
                                </div>
                                <div className="grid grid-cols-12">
                                    <span className="col-span-2">توضیحات</span>
                                    <Textarea
                                        className="col-span-10"
                                        placeholder="متن درخواست خود را وارد کنید"
                                    />
                                </div>
                                <div className="flex justify-end">
                                    <MaadButton
                                        classNames={{
                                            root: 'bg-[#2141A8] text-white',
                                        }}
                                    >
                                        ارسال درخواست
                                    </MaadButton>
                                </div>
                            </form>
                        </MaadModal>
                        <div className="w-full mt-4 bg-white shadow-lg p-3 rounded-md">
                            <form>
                                <TextInput
                                    placeholder="جستجو در درخواست ها"
                                />
                            </form>
                        </div>
                        <div className="w-full mt-4 grid grid-cols-1 gap-3 overflow-y-auto whitespace-nowrap max-h-96">
                            <TicketItem
                                id={1}
                                title="درخواست پشتیبانی"
                                when="1399/12/12"
                                status="paygiri"
                            />
                            <TicketItem
                                id={2}
                                title="درخواست پشتیبانی"
                                when="1399/12/12"
                                status="takmil"
                            />
                            <TicketItem
                                id={3}
                                title="درخواست پشتیبانی"
                                when="1399/12/12"
                                status="end"
                            />
                            <TicketItem
                                id={4}
                                title="درخواست پشتیبانی"
                                when="1399/12/12"
                                status="takmil"
                            />
                            <TicketItem
                                id={5}
                                title="درخواست پشتیبانی"
                                when="1399/12/12"
                                status="end"
                            />
                            <TicketItem
                                id={6}
                                title="درخواست پشتیبانی"
                                when="1399/12/12"
                                status="end"
                            />
                            <TicketItem
                                id={7}
                                title="درخواست پشتیبانی"
                                when="1399/12/12"
                                status="end"
                            />
                            <TicketItem
                                id={8}
                                title="درخواست پشتیبانی"
                                when="1399/12/12"
                                status="end"
                            />
                        </div>
                    </div>
                    <div className="col-span-9">
                        <div className="w-full bg-white p-3 rounded-md h-full relative">
                            <div className="flex justify-between items-center border-b-2 pb-3 border-primary">
                                <h1 className="text-lg font-bold">درخواست پشتیبانی</h1>
                                <Button
                                    color="red"
                                    classNames={{
                                        label: 'font-medium'
                                    }}
                                >
                                    بستن درخواست
                                </Button>
                            </div>
                            <div className="absolute bg-white bottom-0 left-0 w-full p-3 border-t-2 flex justify-between items-center">
                                <textarea
                                    placeholder="پاسخ خود را بنویسید"
                                    className="w-[90%] outline-none resize-none h-6"
                                ></textarea>
                                <button
                                    className="rotate-180 bg-primary p-2 flex justify-center items-center rounded-full"
                                >
                                    <BiSend className="text-white" />
                                </button>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </DashboardContent>
    )
}
'use client'

import DashboardContent from '@/components/dashboardContent'
import { Textarea, Switch } from '@mantine/core'
import { useState } from 'react'
import { Head } from '@/components/form'
import TableBox from '@/components/tables/tableBox'
import { FaEdit, FaTrash } from 'react-icons/fa'
import MaadButton from '@/components/button'
import TextInput from '@/components/textInput'
import MaadModal from '@/components/modal'

export default function Systemic() {

    const [newMessage, setNewMessage] = useState<boolean>(false)

    return (
        <>
            {/* <DashboardContent active_menu="message" breadcrumbTitle="پیام های سیستمی"> */}
            <MaadModal
                opened={newMessage}
                onClose={() => {
                    setNewMessage(false)
                }}
                title="پیام جدید"
            >
                <form className='grid grid-cols-1 gap-5'>
                    <TextInput
                        label='عنوان :'
                        placeholder='عنوان'
                        variant='default'
                    />
                    <div className="grid grid-cols-12 col-span-1">
                        <span className='col-span-3'>متن پیام</span>
                        <Textarea
                            className='col-span-9'
                            placeholder='متن پیام'
                        />
                    </div>
                    <div className="flex justify-end">
                        <MaadButton>
                            ذخیره
                        </MaadButton>
                    </div>
                </form>
            </MaadModal>
            <div className="w-full">
                <div className="w-full flex justify-end">
                    <MaadButton
                        onClick={() => {
                            setNewMessage(true)
                        }}
                    >
                        پیام جدید
                    </MaadButton>
                </div>
                <div className="w-full mt-8 bg-white shadow-sm rounded-md py-4">
                    <div className="border-b-4 border-primary pb-3">
                        <div className="px-3">
                            <Head title='لیست پیام ها' />
                        </div>
                    </div>
                    <div className="px-3 mt-9">
                        <TableBox
                            columns={[
                                { id: 'title', label: 'عنوان' },
                                { id: 'text', label: 'متن پیام' },
                                { id: 'recievers', label: 'گیرندگان' },
                                { id: 'status', label: 'وضیعت' },
                            ]}
                            data={[
                                {
                                    title: 'تبریک تولد',
                                    text: 'گیرنده {user} عزیز زادروزتان مبارک ',
                                    recievers: 'مشتری',
                                    status:
                                        <div className='flex'>
                                            <Switch />
                                            <FaEdit className='mx-4' />
                                            <FaTrash />
                                        </div>
                                },
                                {
                                    title: 'تبت نام',
                                    text: 'عزیز، ورود تان را به خانواده ... تبریک میگوییم',
                                    recievers: 'مشتری - مدیرسایت',
                                    status:
                                        <div className='flex'>
                                            <Switch />
                                            <FaEdit className='mx-4' />
                                            <FaTrash />
                                        </div>
                                },
                                {
                                    title: 'تشکر خرید',
                                    text: 'از خریدتان سپاسگزاریم، از اینکه مجموعه ما رو انتخاب کردید بسیار به خود می بالیم',
                                    recievers: 'مشتری',
                                    status:
                                        <div className='flex'>
                                            <Switch />
                                            <FaEdit className='mx-4' />
                                            <FaTrash />
                                        </div>
                                },
                            ]}
                        />
                    </div>
                </div>
            </div>
            {/* </DashboardContent> */}
        </>
    )
}
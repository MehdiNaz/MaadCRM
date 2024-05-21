'use client'
import { use, useEffect, useRef, useState } from 'react'
import { GrNotification } from 'react-icons/gr'
import { MdClear } from 'react-icons/md'
import Notif from './notif'
import Reminder from './reminder'
import { PeygiriNotificationType } from '@/types/notifications'
import { CancelPeygiri, CompleteNotification, NotificationLater, NotificationsCount, NotificationsList } from '@/services/notifications'
import { LoadingOverlay, Popover, Text } from '@mantine/core'
import Button from '../button'
import Modal from '../modal'
import { FiRefreshCcw } from 'react-icons/fi'
import { showNotification } from '@mantine/notifications'
import { modals } from '@mantine/modals'
import DateInput from '../DateInput'
import NotifDateItem from './notifDateItem'
import moment from 'moment-jalaali'
import { convertDateToPerisan, convertPersianDate, validDate } from '@/utils/helper'
import { useForm } from '@mantine/form'
import UsersSelect from '../select/users'
import { useClickOutside } from '@mantine/hooks'
import { motion } from "framer-motion";

export default function Notifications() {

    const [notifications, setNotifications] = useState<PeygiriNotificationType[]>([])
    const [count, setCount] = useState(0)
    const [open, setOpened] = useState<boolean>(false)

    const box = useRef(null)

    function handleClick() {
        setOpened((prev) => !prev)
    }

    async function getNotificationsCount() {
        const response = await NotificationsCount();
        setCount(response.data)
    }


    async function getNotificationsList() {
        const response = await NotificationsList();
        const data = response.data
        if (data.length > 0) {
            setNotifications([])
            data.map((item: any) => {
                setNotifications((prev: any) => [...prev, {
                    title: item.message,
                    isRead: item.isRead,
                    description: 'item.description',
                    customerId: 'item.customerId',
                    user: ' item.user',
                    id: item.id,
                    dateDue: item.dateDue
                }])
            })
        }
    }

    useEffect(() => {
        // getNotificationsCount()
        // getNotificationsList()
    }, [])

    const [modelOpen, setModelOpen] = useState(false)

    const [modal, setModal] = useState({
        id: '',
        title: '',
        date: ''
    })


    const [loading, setLoading] = useState<boolean>(false)
    async function cancelPaygiri(id: string) {
        try {
            setLoading(true)
            const response = await CancelPeygiri({
                IdNotification: id
            })
            if (response.valid) {
                setModelOpen(false)
                showNotification({
                    title: 'عملیات موفق',
                    message: 'پیگیری با موفقیت کنسل شد',
                    color: 'green'
                })
                const newNotifications = notifications.filter((notif) => notif.id != id)
                setNotifications(newNotifications)
            }
        } catch {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در کنسل کردن پیگری',
                color: 'red'
            })
        } finally {
            setLoading(false)
        }
    }


    async function completeNotification(id: string) {
        try {
            setLoading(true)
            const response = await CompleteNotification({
                IdNotification: id
            })
            if (response.valid) {
                setModelOpen(false)
                showNotification({
                    title: 'عملیات موفق',
                    message: 'پیگیری با موفقیت اتمام یافت',
                    color: 'green'
                })
            }
            const newNotifications = notifications.filter((notif) => notif.id != id)
            setNotifications(newNotifications)
        } catch {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در اتمام پیگیری',
                color: 'red'
            })
        } finally {
            setLoading(false)
        }
    }

    const [notificationLater, setNotificationLater] = useState<boolean>(false)

    const [date, setDate] = useState<string>('')

    const form = useForm({
        initialValues: {
            date: '',
            user: ''
        },
    })

    async function notificationlater(id: string) {
        try {
            if (!validDate(form.values.date) || form.values.date == '') {
                form.setErrors({ date: 'تاریخ وارد شده معتبر نیست' })
                return
            }
            setLoading(true)
            let date = moment(form.values.date, 'jYYYY-jMM-jDD').format('YYYY-MM-DD')
            date += 'T09:07:48.585542Z'
            const later = {
                IdNotification: id,
                DateDue: date,
                IdUser: form.values.user
            }
            if (form.values.user == '') {
                delete later.IdUser
            }
            const response = await NotificationLater(later)
            showNotification({
                title: 'عملیات موفق',
                message: 'پیگیری با موفقیت انجام شد',
                color: 'green'
            })
            setModelOpen(false)
            setNotificationLater(false)
        } catch {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در انجام عملیات',
                color: 'red'
            })
        } finally {
            setLoading(false)
        }
    }

    const variants = {
        initial: { opacity: 0 },
        animate: {
            opacity: 1
        }
    }

    useEffect(() => {
        if (!box.current) return
        if (!open) return
        console.log('open');
        box.current.addEventListener('click', () => {
            console.log('click');

        })
    }, [box])
    return (
        <>
            <Modal size='md' opened={modelOpen} title={modal.title} onClose={() => {
                setModelOpen(false)
                setNotificationLater(false)
            }} centered>
                <LoadingOverlay visible={loading} />
                <motion.div
                    variants={variants}
                    animate={notificationLater == true ? "animate" : "initial"}
                    hidden={!notificationLater}
                >
                    <div className={`flex flex-col`}>
                        <div className="grid grid-cols-3 gap-8">
                            <div className="col-span-1">
                                <NotifDateItem
                                    onClick={() => { form.setValues({ 'date': moment(modal.date).add(1, 'day').format('jYYYY-jMM-jDD') }) }}
                                    text='فردا'
                                    select={form.values.date === moment(modal.date).add(1, 'day').format('jYYYY-jMM-jDD')}
                                />
                            </div>
                            <div className="col-span-1">
                                <NotifDateItem
                                    onClick={() => { form.setValues({ 'date': moment(modal.date).add(7, 'day').format('jYYYY-jMM-jDD') }) }}
                                    text='هفته بعد'
                                    select={form.values.date === moment(modal.date).add(7, 'day').format('jYYYY-jMM-jDD')}
                                />
                            </div>
                            <div className="col-span-1">
                                <NotifDateItem
                                    onClick={() => { form.setValues({ 'date': moment(modal.date).add(1, 'month').format('jYYYY-jMM-jDD') }) }}
                                    text='ماه بعد'
                                    select={form.values.date === moment(modal.date).add(1, 'month').format('jYYYY-jMM-jDD')}
                                />
                            </div>
                        </div>
                        <div className="w-full mt-10 flex flex-col">
                            <span className='text-sm leading-8'>تاریخ دلخواه :</span>
                            <DateInput
                                onChange={(value) => {
                                    if (value)
                                        value = convertPersianDate(value)
                                    form.setValues({ 'date': value })
                                }}
                                error={form.errors.date}
                            />
                        </div>
                        <div className="w-full mt-10 flex flex-col">
                            <span className='text-sm leading-8'>کاربر :</span>
                            {notificationLater && (
                                <UsersSelect
                                    searchable
                                    onChange={(value) => {
                                        form.setValues({ 'user': value })
                                    }}
                                />
                            )}
                        </div>
                        <div className="grid grid-cols-2">
                            <div className="col-span-1 flex justify-center">
                                <Button
                                    className="mt-8 w-full"
                                    onClick={() => notificationlater(modal.id)}
                                >
                                    تایید
                                </Button>
                            </div>
                            <div className="col-span-1 flex justify-center">
                                <Button
                                    className="mt-8"
                                    color="red"
                                    onClick={() => setNotificationLater(false)}
                                >
                                    انصراف
                                </Button>
                            </div>
                        </div>
                    </div>
                </motion.div>
                <motion.div
                    animate={notificationLater == true ? "animate" : "initial"}
                    hidden={notificationLater}
                >
                    <div className={`${notificationLater ? 'none' : 'flex'} items-center`}>
                        <span>
                            <FiRefreshCcw />
                        </span>
                        <span className='mr-3'>علی عباسی</span>
                    </div>
                    <div className="grid grid-cols-3 mt-10">
                        <div className="col-span-1 items-center flex justify-center">
                            <Button color="green" onClick={() => completeNotification(modal.id)}>
                                اتمام پیگیری
                            </Button>
                        </div>
                        <div className="col-span-1 items-center flex justify-center">
                            <Button color="red" onClick={() => cancelPaygiri(modal.id)}>
                                کنسل شد
                            </Button>
                        </div>
                        <div className="col-span-1 items-center flex justify-center">
                            <Button onClick={() => setNotificationLater(true)}>
                                پیگیری مجدد
                            </Button>
                        </div>
                    </div>
                </motion.div>
            </Modal >
            <div className='relative cursor-pointer' data-count={count}>
                {/* <div ref={box} className="w-full top-0 lef-0 right-0 fixed h-full"></div> */}
                {count > 0 && (
                    <span className='absolute -top-2 -right-2 bg-red-600 text-white rounded-full text-center w-4 h-4 text-xs flex justify-center items-center'>
                        {count}
                    </span>
                )}
                <div className="flex" onClick={handleClick}>
                    <GrNotification className='cursor-pointer pointer-events-none' fontSize='20' />
                </div>
                <div id="notifications-box" className={`absolute top-7 left-0 bg-white shadow-md rounded-lg w-96 p-4 ${open ? 'visible opacity-100' : 'invisible opacity-0'} duration-100 max-h-[300px] h-[300px] z-50 overflow-scroll`}>
                    <div className="w-full flex justify-end">
                        {/* {count > 0 && (
                        <p
                            onClick={() => {
                                setNotifications([])
                                setCount(0)
                            }}
                            className='text-red-500 text-11p flex items-center cursor-pointer'>
                            <span className='ml-1'>پاک کردن همه</span>
                            <MdClear />
                        </p>
                    )} */}
                    </div>
                    <div className="felx flex-col">
                        {notifications && notifications.length == 0 && (
                            <div className='flex justify-center items-center mt-10'>
                                <span className='text-gray-700'>هیچ اعلانی  در اینجا نیست</span>
                            </div>
                        )}
                        {
                            notifications && notifications.length > 0 && notifications.map((item, index) => {
                                let className = 'my-3 pb-2'
                                className += index !== notifications.length - 1 ? ' border-b' : ''
                                return <Notif
                                    key={index}
                                    className={className}
                                    title={item.title}
                                    description={item.description}
                                    customerId={item.customerId}
                                    onClick={() => {
                                        setModelOpen(true)
                                        setModal({
                                            id: item.id,
                                            title: item.title,
                                            date: item.dateDue
                                        })
                                    }}
                                    date={moment(item.dateDue).format('jYYYY-jMM-jDD')}
                                />
                            })
                        }
                    </div>
                </div>
            </div>
        </>
    )
}
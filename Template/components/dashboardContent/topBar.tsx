'use client'
import Search from '../search'
import { CgProfile } from 'react-icons/cg'
import { MdOutlineArrowBackIos } from 'react-icons/md'
import Notifications from '../notifications'
import Link from 'next/link'
import { Tooltip } from '@mantine/core'
import { BiLogOutCircle } from 'react-icons/bi'
import { logout } from 'utils/helper'
import { useRouter } from 'next/navigation'
import { showNotification } from '@mantine/notifications'

export default function DashboardTopBar(props) {

    const router = useRouter()


    return (
        <div className="flex w-full justify-between py-3 border-b">
            <div className="breadcrumb flex items-center">
                <Link href='/customers'>
                    داشبورد
                </Link>
                <span className='mx-1'>
                    <MdOutlineArrowBackIos fontSize={12} />
                </span>
                <span>{props.breadcrumbTitle}</span>
            </div>
            <div className="flex items-center">
                <div className="flex">
                    <Search />
                </div>
                <div className="flex items-center mx-5">
                    <Notifications />
                </div>
                <div className="felx items-center mx-5">
                    <Link href='/account'>
                        <CgProfile fontSize='25' />
                    </Link>
                </div>
                <div className="flex items-ceneter justify-center">
                    <Tooltip
                        position='right'
                        label='خروج از حساب کاربری'>
                        <button
                            onClick={() => {
                                if (logout()) {
                                    showNotification({
                                        title: 'با موفقیت خارج شدید',
                                        message: 'با موفقیت از حساب کاربری خود خارج شدید',
                                        color: 'teal',
                                    })
                                    window.location.href = '/login'
                                }
                            }}
                        >
                            <BiLogOutCircle fontSize={25} />
                        </button>
                    </Tooltip>
                </div>
            </div>
        </div>
    )
}
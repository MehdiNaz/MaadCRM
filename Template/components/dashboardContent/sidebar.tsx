'use client'
import { AiOutlineArrowUp, AiOutlineDashboard, AiOutlineEye } from "react-icons/ai"
import { FiUsers, FiSettings } from "react-icons/fi"
import { SlCalender } from "react-icons/sl"
import { TiContacts } from "react-icons/ti"
import { TbFileReport } from "react-icons/tb"
import { HiOutlineTicket } from "react-icons/hi"
import Link from "next/link"
import './style.css'
import { useState } from "react"
import MenuItem from './menuItem'
import { BsBoxSeam } from "react-icons/bs"
import { BiLogOutCircle } from "react-icons/bi"
import { getLocalStorage, logout } from "utils/helper"
import { showNotification } from "@mantine/notifications"
import { SidebarType } from "@/types/dashboard"
import jwt_decode from "jwt-decode";
import { getCookie } from "cookies-next"

export default function DashboardSidebar({ active, token }) {

    let decode: any = jwt_decode(token)

    const hasAccess = (permission: string) => {
        return decode.role === permission
    }

    const menus = [
        // {
        //     link: "/dashboard",
        //     title: "میز کار من",
        //     icon: <AiOutlineDashboard />,
        //     id: "dashboard"
        // },
        {
            link: "/admin",
            title: "مدیریت",
            icon: <AiOutlineArrowUp />,
            id: "admin",
            hasAccess: hasAccess('SUPERADMIN')
        },
        {
            link: "/customers",
            title: "مشتریان",
            icon: <FiUsers />,
            id: "customers",
        },
        {
            link: "/teammates",
            title: "همکاران",
            icon: <AiOutlineEye />,
            id: "teammates",
        },
        // {
        //     link: "/calender",
        //     title: "تقویم",
        //     icon: <SlCalender />,
        //     id: "calender"
        // },
        // {
        //     link: "/survey",
        //     title: "نظرسنجی",
        //     icon: <GoSettings />,
        //     id: "survey"
        // },
        {
            link: "/contacts",
            title: "مخاطبین",
            icon: <TiContacts />,
            id: "contacts",
            children: [
                {
                    link: "/contacts/groups",
                    title: "گروه ها",
                    icon: <TiContacts />,
                    id: "contacts_groups",
                },
            ]
        },
        // {
        //     link: "/messages",
        //     title: "پیام",
        //     icon: <GoSettings />,
        //     id: "message",
        //     disabled: true
        // },
        // {
        //     link: "/tickets",
        //     title: "تیکت ها",
        //     icon: <HiOutlineTicket />,
        //     id: "tickets",
        //     disabled: true
        // },
        {
            link: "/products",
            title: "کالا/خدمات",
            icon: <BsBoxSeam />,
            id: "products",
        },
        {
            link: "/settings",
            title: "تنظیمات",
            icon: <FiSettings />,
            id: "settings",
            // hasAccess: hasAccess('Company')
        }
    ] as SidebarType[]

    return (
        <>
            <div id="sidebar" className={`relative hidden lg:flex bg-primary h-full w-full flex-col overflow-y-auto`}>
                <div className="my-4 text-white text-2xl fond-bold text-center border-b border-gray-200 pb-4 mx-2">
                    <Link href="/dashboard">
                        Maad CRM
                    </Link>
                </div>
                <div className="flex mt-2 flex-col w-full">
                    {menus.map((menu, index) => (
                        menu.hasAccess !== false && (
                            <MenuItem
                                key={index}
                                link={menu.link}
                                title={menu.title}
                                icon={menu.icon}
                                active={active === menu.id}
                                id={menu.id}
                                disabled={menu.disabled ?? false}
                                children={menu.children}
                            />
                        )
                    ))}
                </div>

                <div className="mt-auto mb-3 border-t border-white">
                    <MenuItem
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
                        title="خروج"
                        icon={<BiLogOutCircle />}
                        active={false}
                        id="logout"
                        disabled={false}
                    />
                </div>
            </div >
        </>
    )
}
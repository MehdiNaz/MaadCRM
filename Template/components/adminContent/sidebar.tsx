'use client'
import { AiOutlineDashboard, AiOutlineEye } from "react-icons/ai"
import { FiUsers, FiSettings } from "react-icons/fi"
import { SlCalender } from "react-icons/sl"
import { TiContacts } from "react-icons/ti"
import { TbFileInvoice, TbFileReport } from "react-icons/tb"
import { HiOutlineTicket } from "react-icons/hi"
import Link from "next/link"
import '../dashboardContent/style.css'
import { useState } from "react"
import MenuItem from "../dashboardContent/menuItem"
import { BsBoxSeam } from "react-icons/bs"
import { BiLogOutCircle } from "react-icons/bi"
import { getLocalStorage, logout } from "utils/helper"
import { showNotification } from "@mantine/notifications"
import { SidebarType } from "@/types/dashboard"
import jwt_decode from "jwt-decode";
import { getCookie } from "cookies-next"

export default function DashboardSidebar({ active, token }) {

    let decode = []
    decode = jwt_decode(token)
    decode = decode['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']

    const hasAccess = (permission: string) => {
        if (typeof decode !== 'object' || decode.length == 0) return false
        return decode.includes(permission)
    }

    const [menuOpen, setmenuOpen] = useState(true)
    const menus = [
        {
            link: "/admin",
            title: "کسب و کارها",
            icon: <FiUsers />,
            id: "bussiness",
        },
        {
            link: "/admin/payments",
            title: "پرداختی ها",
            icon: <TbFileInvoice />,
            id: "payments",
        },
    ] as SidebarType[]

    return (
        <>
            <div id="sidebar" className={`relative hidden lg:flex bg-primary h-full w-full flex-col overflow-y-auto`}>
                <div className="my-4 text-white text-2xl fond-bold text-center border-b border-gray-200 pb-4 mx-2">
                    <Link href="/admin">
                        مدیریت ماد
                    </Link>
                </div>
                <div className="flex mt-2 flex-col">
                    {menus.map((menu, index) => (
                        <div key={index}>
                            {menu.hasAccess !== false && (
                                <MenuItem
                                    key={index}
                                    link={menu.link}
                                    title={menu.title}
                                    icon={menu.icon}
                                    active={active === menu.id}
                                    id={menu.id}
                                    disabled={menu.disabled ?? false}
                                />
                            )}
                        </div>
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
            </div>
        </>
    )
}
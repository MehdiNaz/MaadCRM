'use client'
import { Tooltip } from "@mantine/core"
import Link from "next/link"

export default function MenuItem({ link = '/', icon, id, title, active, disabled, onClick, children }: {
    link?: string,
    icon: any,
    id: string,
    title: string,
    active: boolean,
    disabled?: boolean,
    onClick?: () => void
    children?: any[]
}) {
    return (
        <div className={`w-full flex flex-col mt-3 mr-4 pr-2 text-white rounded-r-full ${active ? 'active_menu' : ''}`}>
            <Link href={link} className="w-full flex">
                <div className="flex ml-4 items-center text-2xl mr-2 menu-icon py-2">
                    {icon}
                </div>
                <div className="flex items-center menu-title w-full menu-title">
                    <p className="font-medium">{title}</p>
                </div>
            </Link>
            {/* {children && children.map((child, index) => (
                <div className={`w-full flex pr-2 text-white rounded-r-full ${active ? 'active_menu' : ''}`}>
                    <Link href={link} className="w-full flex">
                        <div key={index} className={`flex mt-3 mr-4 text-white w-full rounded-r-full`}>
                            <div className="flex ml-4 items-center text-2xl mr-2 menu-icon py-2">
                                {child.icon}
                            </div>
                            <div className="flex items-center menu-title w-full menu-title">
                                <p className="font-medium">{child.title}</p>
                            </div>
                        </div>
                    </Link>
                </div>
            ))} */}
        </div>
    )
}
import { Tooltip } from "@mantine/core";
import Link from "next/link";
import { FiUsers } from "react-icons/fi";
import { CardProps } from '../../types/settings'

export default function SettingCard({ link, title, icon, disabled }: CardProps) {
    return (
        <>
            {disabled ? (
                <Tooltip label="به زودی" position="left-end">
                    <div className="w-full bg-white shadow-md rounded-md px-3 py-10 opacity-50 cursor-pointer">
                        <div className="text-3xl flex justify-center mb-4">{icon ? icon : <FiUsers />}</div>
                        <span className="text-md flex justify-center">{title ? title : ''}</span>
                    </div>
                </Tooltip>
            ) :
                <Link href={link ? link : '/settings'}>
                    <div className="w-full bg-white shadow-md rounded-md px-3 py-10">
                        <div className="text-3xl flex justify-center mb-4">{icon ? icon : <FiUsers />}</div>
                        <span className="text-md flex justify-center">{title ? title : ''}</span>
                    </div>
                </Link>
            }
        </>
    )
}
'use client'
import { NotificationNotifType } from "@/types/notifications"
import { useState } from "react"
import Reminder from "./reminder"

export default function Notif({ title, description, customerId, className, onClick, date }: NotificationNotifType) {

    const [click, setClick] = useState<boolean>(false)

    function handleAction() {
        setClick(true)
        onClick && onClick()
    }

    return (
        <>
            <div className={`w-full cursor-pointer ${className}`} onClick={handleAction}>
                <p className="flex justify-between items-center">
                    <span className="text-md">{title}</span>
                    <span className="text-xs">{date}</span>
                </p>
            </div>
        </>
    )
}
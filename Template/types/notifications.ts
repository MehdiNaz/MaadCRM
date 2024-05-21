import React from "react"

export type PeygiriNotificationType = {
    title: string
    description: string
    customerId: string
    user?: string
    id?: string
    dateDue?: string
}

export type NotificationNotifType = {
    title: string
    description?: string
    className?: string
    customerId: string
    onClick?: Function
    date?: string
}

export type NotificationReminderType = {
    open?: boolean
    onClose?: Function
    customerId: string
    title: string
    description: string
    user?: string
}
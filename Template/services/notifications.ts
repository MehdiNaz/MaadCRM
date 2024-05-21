import axios from "@/utils/axios";

export async function NotificationsCount() {
    const { data } = await axios.get('Notification/NotificationCount')
    return data
}

export async function NotificationsList() {
    const { data } = await axios.get('Notification/AllNotifications')
    return data
}

export async function CancelPeygiri({ IdNotification }) {
    const { data } = await axios.post('Notification/NotificationCancel', {
        IdNotification
    })
    return data
}

export async function CompleteNotification({ IdNotification }) {
    const { data } = await axios.post('/Notification/NotificationCompleted', {
        IdNotification
    })
    return data
}

export async function NotificationLater({ IdNotification, DateDue, IdUser }: { IdNotification: string, DateDue: string, IdUser?: string }) {
    const { data } = await axios.post('/Notification/NotificationLater', {
        IdNotification,
        DateDue,
        IdUser
    })
    return data
}
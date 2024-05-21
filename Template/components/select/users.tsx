'use client'

import { Loader } from "@mantine/core"
import { showNotification } from "@mantine/notifications"
import { useEffect, useState } from "react"
import { getAllUsers } from "services/bussiness"
import SelectBox from "../selectBox"

export default function UsersSelect({ ...props }) {
    const [users, setUsers] = useState([])
    const [loading, setLoading] = useState<boolean>(true)

    async function getUsers() {
        try {
            const response = await getAllUsers()
            setUsers(response.users)
        } catch {
            showNotification({
                title: 'خطا',
                message: 'خطایی در دریافت اطلاعات رخ داد',
                color: 'red'
            })
        } finally {
            setLoading(false)
        }
    }

    useEffect(() => {
        getUsers()
    }, [])

    return (
        <SelectBox
            icon={loading && <Loader size={13} />}
            disabled={loading}
            placeholder="انتخاب همکار"
            data={users.map((user: any) => ({ label: user?.first_name + ' ' + user?.last_name, value: user.id }))}
            {...props}
        />
    )
}
'use client'
import { NotificationReminderType } from "@/types/notifications";
import { Button, Group, Text } from "@mantine/core";
import { modals } from "@mantine/modals";
import { useEffect, useId, useState } from "react";
import Modal from "../modal";

export default function Reminder({ open, onClose, customerId, title, description, user }: NotificationReminderType) {

    const [opened, setOpend] = useState<boolean>(open)

    useEffect(() => {
        setOpend(open)
    }, [open])

    const id = useId()
    function handleClose(e) {
        console.log(e.id, id);

        if (e.id === id) {
            setOpend(false)
            if (onClose) onClose()
        }
    }


    return (
        <>
            {opened && (
                <div
                    id={id}
                    onClick={handleClose}
                    className="w-full h-full top-0 left-0 bg-black bg-opacity-50 fixed z-50 flex justify-center items-center">
                    <div className="w-1/3 bg-white rounded-md p-3 border z-50">
                        <div className="flex mx-4 border-b p-2">
                            {title}
                        </div>
                        <div className="mt-4 mx-4">
                            <p>
                                <span>{user}</span>
                            </p>
                            <Text size="sm">
                                {description}
                            </Text>
                        </div>
                    </div>
                </div>
            )}
        </>
    )
}
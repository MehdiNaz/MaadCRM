import Image from "next/image"
import { FaEdit, FaTrash } from "react-icons/fa"
import EditNote from "./editNote"
import { useState } from "react"
import { modals } from '@mantine/modals'
import { Text } from "@mantine/core"
import { deleteCustomerNote } from "services/customer"
import { showNotification } from "@mantine/notifications"
import { FiEdit, FiTrash2 } from "react-icons/fi"

export default function Note({
    content,
    id,
    creationDate,
    name
}:
    {
        content: any
        id: string
        creationDate: string
        name: string
    }
) {

    const [editNote, setEditNote] = useState<boolean>(false)
    const [contentText, setContent] = useState<string>(content)

    async function deleteNote(id) {
        const response = await deleteCustomerNote({
            CustomerNoteId: id
        })
        if (response.success) {
            showNotification({ message: 'یادداشت با موفقیت حذف شد', title: 'عملیات موفق', color: 'green' })
            document.getElementById(id).remove()
        }
    }

    const openModal = (id) => modals.openConfirmModal({
        title: 'حذف یادداشت',
        children: (
            <Text size="sm">
                آیا از حذف این یادداشت مطمئن هستید؟
            </Text>
        ),
        labels: { confirm: 'حذف', cancel: 'لغو' },
        onConfirm: () => deleteNote(id),
        confirmProps: { color: 'red' },
    })

    return (
        <div className="w-full bg-[#F8F6F6] rounded-md border border-[#DADEE3] p-3 flex flex-col" id={id}>
            <EditNote opened={editNote} onClose={() => setEditNote(false)} id={id} description={contentText} callBack={(newContent) => { setContent(newContent) }} />
            <div className="w-full flex justify-between border-b pb-3">
                <div className="w-1/2 flex items-center">
                    <Image src='/images/user-male.png' width={41} height={41} alt='User' />
                    <span className="text-sm mr-3">
                        {name}
                    </span>
                </div>
                <div className="w-1/2 flex items-center justify-end">
                    <span className="text-sm">
                        {new Date(creationDate).toLocaleDateString('fa-IR')}
                    </span>
                </div>
            </div>
            <div className="w-full mt-4 flex flex-col">
                <p className="text-sm leading-7 text-justify whitespace-break-spaces">
                    {contentText}
                </p>
                <div className="flex mr-auto mb-2">
                    <button
                        onClick={() => setEditNote(true)}
                        className="mx-2 text-md">
                        {/* <FaEdit /> */}
                        <FiEdit />
                    </button>
                    <button
                        onClick={() => openModal(id)}
                        className="text-md text-red-600">
                        <FiTrash2 />
                    </button>
                </div>
            </div>
        </div>
    )
}
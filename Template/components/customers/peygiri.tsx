'use client'
import { useState } from "react";
import { BiRefresh } from "react-icons/bi";
import { FaEdit, FaPhone, FaTrash } from "react-icons/fa";
import { modals } from '@mantine/modals'
import { Text } from '@mantine/core'
import EditPeygiri from "../pages/customers/editPeygiri";
import { deleteCustomerPeygiri } from "services/customer";
import { showNotification } from "@mantine/notifications";
import { convertDateToPerisan } from "@/utils/helper";

export default function Peygiri({
    description,
    id,
    namePeyGiryCategory,
    dateCreated,
    nameUser
}: {
    description?: string
    id?: string
    namePeyGiryCategory?: string
    dateCreated?: string
    nameUser?: string
}) {

    const [editPeygiri, setEditPeygiri] = useState<boolean>(false)
    const [contentText, setContent] = useState<string>(description)

    async function deletePeygiri(id) {
        const response = await deleteCustomerPeygiri({
            Id: id,
        })

        if (response) {
            showNotification({ message: 'پیگیری با موفقیت حذف شد', title: 'عملیات موفق', color: 'green' })
            document.getElementById(id).remove()
        }
    }

    const openModal = (id) => modals.openConfirmModal({
        title: 'حذف پیگیری',
        children: (
            <Text size="sm">
                آیا از حذف این پیگیری مطمئن هستید؟
            </Text>
        ),
        labels: { confirm: 'حذف', cancel: 'لغو' },
        onConfirm: () => deletePeygiri(id),
        confirmProps: { color: 'red' },
    })

    const date = convertDateToPerisan(dateCreated)

    return (
        <div className="w-full bg-white shadow-md flex flex-col px-3 py-2 rounded-lg" id={id}>
            <EditPeygiri opened={editPeygiri} onClose={() => setEditPeygiri(false)} id={id} description={contentText} callBack={(newContent) => { setContent(newContent) }} />
            <div className="w-full flex justify-between border-b border-[#000] pb-2">
                <div className="flex items-center text-sm">
                    <FaPhone />
                    <span className="mr-3">{namePeyGiryCategory}</span>
                </div>
                <div className="flex items-center text-12p">
                    <span>
                        {date}
                    </span>
                </div>
            </div>
            <div className="flex mt-4 flex-col">
                <div className="flex justify-center items-center">
                    <BiRefresh className="text-4xl" />
                    <span className="mr-3">
                        {nameUser}
                    </span>
                </div>
                <div className="mt-4 border-b border-[#000] pb-4">
                    <p className="text-12p text-center leading-6">
                        {contentText}
                    </p>
                </div>
            </div>
            <div className="flex mt-4 justify-center hidden">
                {/* <Select
                    multiple
                    className="w-auto"
                    placeholder="یادآوری شود به"
                    searchable
                    data={[
                        // { value: 'hadi', label: 'استاد بزرگوار شریف هادی' },
                        // { value: 'agha-ramtin', label: 'آقا رامتین' },
                        { value: 'arash', label: 'آرش' },
                        { value: 'mahdi', label: 'مهدی' },
                    ]}
                />
                <button className="mr-2">
                    <FiSave />
                </button> */}
                <button
                    onClick={() => setEditPeygiri(true)}
                    className="mx-2 text-12p">
                    <FaEdit />
                </button>
                <button
                    onClick={() => openModal(id)}
                    className="text-12p text-red-600">
                    <FaTrash />
                </button>
            </div>
        </div>
    )
}
'use client'
import { ClientsTableType } from '@/types/customComponents';
import { BsCartXFill } from 'react-icons/bs';
import TableTitle from '../tableTitle';
import { GiNotebook, GiSellCard } from 'react-icons/gi'
import { HiRefresh } from 'react-icons/hi';
import { FiEdit } from 'react-icons/fi';
import { RiDeleteBin6Line } from 'react-icons/ri';
import '../clientsTable.css'
import { Drawer, Select, Text, Tooltip } from '@mantine/core';
import { useEffect, useState } from 'react';
import { useRouter } from 'next/navigation';
import Link from 'next/link';
import NoItem from '@/components/noItem';
import TextInput from '@/components/textInput';
import { useForm } from '@mantine/form';
import { showNotification } from '@mantine/notifications';
import { deleteContact, deleteGroup, updateContact, updateContactGroup } from 'services/contact';
import GroupsSelect from '@/components/contacts/groupsSelect';
import Button from '@/components/button';
import { modals } from '@mantine/modals';
import Modal from '@/components/modal';
import Table from '../table';
import Image from 'next/image';

export default function GroupsTable({ data }: ClientsTableType) {

    const [loading, setLoading] = useState<boolean>(true)
    const [groups, setGroups] = useState(data)
    const [editing, setEditing] = useState(false)

    useEffect(() => {
        if (!data) return
        setGroups(data)
        setLoading(false)
    }, [data])


    const form = useForm({
        initialValues: {
            id: '',
            GroupName: ''
        },

        validate: {
            GroupName: (value) => {
                if (value.length < 3) {
                    return 'عنوان گروه باید حداقل 3 کاراکتر باشد'
                }
            }
        }
    })


    async function deletegroup(id) {
        try {
            const response = await deleteGroup({ id: id })
            showNotification({
                title: 'عملیات موفق',
                message: 'گروه با موفقیت حذف شد',
                color: 'green'
            })
            setGroups(groups.filter((item) => item.id !== id))
        } catch {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در حذف گروه',
                color: 'red'
            })
        }
    }

    const openModal = (id: string) => modals.openConfirmModal({
        title: 'حذف گروه',
        children: (
            <Text size="sm">
                آیا از حذف این گروه مطمئن هستید؟
            </Text>
        ),
        labels: { confirm: 'حذف', cancel: 'لغو' },
        onConfirm: () => deletegroup(id),
        confirmProps: { color: 'red' },
    })

    async function handleEditGroup(values: typeof form.values) {
        try {
            const response = await updateContactGroup({
                id: values.id,
                title: values.GroupName
            })
            showNotification({
                title: 'عملیاات موفق',
                message: 'گروه مخطاب با موفقیت ویرایش شد',
                color: 'green'
            })

            const newGroups = [...groups]
            const index = newGroups.findIndex((item) => item.id === values.id)
            newGroups[index] = response.group
            setGroups(newGroups)
            setEditing(false)

        } catch {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در ویرایش مخاطب',
                color: 'red'
            })
        }
    }

    return (
        <>
            <Modal
                opened={editing}
                onClose={() => setEditing(false)}
                title="ویرایش گروه"
                size='lg'
            >
                <div className="w-full flex flex-col">
                    <form onSubmit={form.onSubmit(handleEditGroup)}>
                        <TextInput
                            placeholder="نام گروه"
                            label="نام گروه :"
                            {...form.getInputProps('GroupName')}
                        />
                        <Button type="submit" className="mt-8 text-sm">
                            ویرایش گروه
                        </Button>
                    </form>
                </div>
            </Modal>
            {groups && (
                <Table
                    columns={[
                        { id: 'title', label: 'عنوان' },
                        { id: 'actions', label: 'عملیات' }
                    ]}
                    data={
                        groups.map((group, index) => {
                            return {
                                title: group.title,
                                actions: (
                                    <div className="flex justify-center text-md">
                                        <Tooltip
                                            label="حذف"
                                            position="left"
                                        >
                                            <button
                                                className='mx-3'
                                                onClick={() => openModal(group.id)}
                                            >
                                                <RiDeleteBin6Line />
                                            </button>
                                        </Tooltip>
                                        <Tooltip
                                            label="ویرایش"
                                            position="left"
                                        >
                                            <button
                                                onClick={() => {
                                                    setEditing(true)
                                                    form.setValues({
                                                        id: group.id,
                                                        GroupName: group.title
                                                    })
                                                }}
                                            >
                                                <FiEdit />
                                            </button>
                                        </Tooltip>
                                    </div>
                                )
                            }
                        })
                    }
                />
            )}
        </>
    )
}
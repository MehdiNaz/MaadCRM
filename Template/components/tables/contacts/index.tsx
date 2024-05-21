'use client'
import { ClientsTableType } from '@/types/customComponents';
import { BsCartXFill } from 'react-icons/bs';
import TableTitle from '../tableTitle';
import { GiNotebook, GiSellCard } from 'react-icons/gi'
import { HiRefresh } from 'react-icons/hi';
import { RiDeleteBin6Line } from 'react-icons/ri';
import '../clientsTable.css'
import { Drawer, Select, Skeleton, Text, Tooltip } from '@mantine/core';
import { useEffect, useState } from 'react';
import { useRouter } from 'next/navigation';
import Link from 'next/link';
import NoItem from '@/components/noItem';
import TextInput from '@/components/textInput';
import { useForm } from '@mantine/form';
import { showNotification } from '@mantine/notifications';
import { deleteContact, updateContact } from 'services/contact';
import GroupsSelect from '@/components/contacts/groupsSelect';
import Button from '@/components/button';
import { modals } from '@mantine/modals';
import Table from '../table';
import { FiEdit } from 'react-icons/fi';
import { AiOutlineDelete } from 'react-icons/ai';

export default function ContactsTable({ data, onDelete }: ClientsTableType) {

    const [editContactOpened, setEditContactOpened] = useState<boolean>(false)
    const [groupSelected, setGroupSelected] = useState('')
    const [contacts, setContacts] = useState(data)

    const [fetched, setFetched] = useState<boolean>(false)


    useEffect(() => {
        setContacts(data)
        setFetched(true)
    }, [data])

    const form = useForm({
        initialValues: {
            IdContact: '',
            name: '',
            family: '',
            mobileNumber: '',
            email: '',
            group: '',
            job: ''
        }
    })

    async function handleEditContact(values: typeof form.values) {
        try {
            const response = await updateContact({
                id: values.IdContact,
                first_name: values.name,
                last_name: values.family,
                phone: values.mobileNumber,
                group_id: groupSelected,
                job_title: values.job,
                email: values.email,
            })
            setEditContactOpened(false)
            contacts.map((contact: any) => {
                if (contact.id === response.contact.id) {
                    contact.first_name = response.contact.first_name
                    contact.last_name = response.contact.last_name
                    contact.phone = response.contact.phone
                    contact.group = response.contact.group
                    contact.job = response.contact.job_title
                    contact.email = response.contact.email
                    setContacts(contacts)
                }
            })

            showNotification({
                title: 'عملیات موفق',
                message: 'مخاطب با موفقیت ویرایش شد',
                color: 'green'
            })
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در ویرایش مخاطب',
                color: 'red'
            })
            console.table({
                Id: values.IdContact,
                FirstName: values.name,
                LastName: values.family,
                ContactGroupId: values.group,
                Job: values.job,
            })
        }
    }

    async function deletecontact(idContact: string) {
        try {
            const response = await deleteContact({ idContact: idContact })
            showNotification({
                title: 'عملیات موفق',
                message: 'مخاطب با موفقیت حذف شد',
                color: 'green'
            })

            contacts.map((contact: any) => {
                if (contact.id === idContact) {
                    setContacts(contacts.filter((contact: any) => contact.id !== idContact))
                }
            })
            onDelete(idContact)
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در حذف مخاطب',
                color: 'red'
            })
        }
    }

    const openModal = (id: string) => modals.openConfirmModal({
        title: 'حذف مخاطب',
        children: (
            <Text size="sm">
                آیا از حذف این مخاطب مطمئن هستید؟
            </Text>
        ),
        labels: { confirm: 'حذف', cancel: 'لغو' },
        onConfirm: () => deletecontact(id),
        confirmProps: { color: 'red' },
    })

    return (
        <>
            <Drawer
                opened={editContactOpened}
                onClose={() => setEditContactOpened(false)}
                title="ویرایش مخاطب"
                padding="xl"
                size="md"
                position="left"
                dir="rtl"
                className="overflow-scroll"
            >
                <form className="flex mt-8 flex-col" onSubmit={form.onSubmit(handleEditContact)}>
                    <label className="flex flex-col w-full">
                        <span className="text-md leading-7 mb-1 w-max">نام</span>
                        <TextInput
                            placeholder="نام"
                            {...form.getInputProps('name')}
                        />
                    </label>
                    <label className="flex flex-col w-full mt-6">
                        <span className="text-md leading-7 mb-1">نام خانوادگی</span>
                        <TextInput
                            placeholder="نام خانوادگی"
                            {...form.getInputProps('family')}
                        />
                    </label>
                    <label className="flex flex-col w-full mt-6">
                        <span className="text-md leading-7 mb-1">شماره موبایل</span>
                        <TextInput
                            placeholder="شماره موبایل"
                            maxLength={11}
                            {...form.getInputProps('mobileNumber')}
                        />
                    </label>
                    <label className="flex flex-col w-full mt-6">
                        <span className="text-md leading-7 mb-1">ایمیل</span>
                        <TextInput
                            placeholder="ایمیل"
                            {...form.getInputProps('email')}
                        />
                    </label>
                    <label className="flex flex-col w-full mt-6">
                        <span className="text-md leading-7 mb-1">گروه</span>
                        <GroupsSelect
                            {...form.getInputProps('group')}
                            defaultValue={groupSelected}
                        />
                    </label>
                    <label className="flex flex-col w-full mt-6">
                        <span className="text-md leading-7 mb-1">زمینه شغلی</span>
                        <TextInput
                            placeholder="زمینه شغلی"
                            {...form.getInputProps('job')}
                        />
                    </label>
                    <div className="flex mt-8">
                        <Button type="submit" className="font-medium">
                            ثبت تغییرات
                        </Button>
                    </div>
                </form>
            </Drawer>
            <Table
                fetched={false}
                columns={[
                    { id: 'name', label: 'نام و نام خانوادگی' },
                    { id: 'mobile', label: 'شماره تماس' },
                    { id: 'email', label: 'ایمیل' },
                    { id: 'group', label: 'گروه' },
                    { id: 'actions', label: 'عملیات' }
                ]}
                data={
                    contacts.map((contact, index) => {
                        return {
                            name: contact?.first_name ? contact.first_name + ' ' + contact.last_name : contact.last_name,
                            mobile: contact.phone,
                            email: contact.email ? contact.email : 'ندارد',
                            group: contact.group.title ? contact.group.title : 'ندارد',
                            actions: (
                                <div className="flex justify-center text-md">
                                    <div className="cursor-pointer mx-3">
                                        <FiEdit size={16}
                                            onClick={() => {
                                                setEditContactOpened(true)
                                                form.setValues({
                                                    'IdContact': contact.id,
                                                    'name': contact.first_name,
                                                    'family': contact.last_name,
                                                    'mobileNumber': contact.phone,
                                                    'email': contact.email,
                                                    'group': contact.group_id,
                                                    'job': contact.job
                                                })
                                                setGroupSelected(contact.group_id)
                                            }}
                                            className="text-sm mr-3">
                                            ویرایش
                                        </FiEdit>
                                    </div>
                                    <div className="cursor-pointer">
                                        <AiOutlineDelete size={16}
                                            onClick={() => openModal(contact.id)}
                                            className="text-sm">
                                            حذف
                                        </AiOutlineDelete>
                                    </div>
                                </div>
                            )
                        }
                    })
                }
            />
        </>
    )
}
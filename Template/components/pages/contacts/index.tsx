'use client'
import { useEffect, useState } from "react"
import DashboardContent from "@/components/dashboardContent"
import TextInput from '@/components/textInput'
import Button from '@/components/button'
import { Drawer, LoadingOverlay, Select, Textarea } from "@mantine/core"
import SearchInput from "@/components/searchInput"
import AbsoluteButton from "@/components/absoluteButton"
import { AiOutlineUserAdd, AiOutlineUsergroupAdd } from "react-icons/ai"
import Modal from "@/components/modal"
import { useForm } from "@mantine/form"
import { getAllContacts, getAllGroups, newContact, newGroup } from "services/contact"
import { showNotification } from "@mantine/notifications"
import ContactsTable from "@/components/tables/contacts"
import { validatePhoneNumber } from "utils/helper"
import Link from "next/link"
import Table from "@/components/tables/table"
import Image from "next/image"
import Header from "@/components/dashboardContent/header"

export default function Contacts() {

    const [contacts, setContacts] = useState<Array<any>>([])
    const [opened, setOpened] = useState<boolean>(false)
    const [editContactOpened, setEditContactOpened] = useState<boolean>(false)
    const [groupOpened, setGroupOpened] = useState<boolean>(false)
    const [groups, setGroups] = useState<Array<any>>([])
    const [visibile, setVisibile] = useState<boolean>(false)

    const [fetched, setFetched] = useState(false)

    const actions = [
        {
            label: 'مخاطب جدید',
            icon: <AiOutlineUserAdd />,
            onClick: () => setOpened(true)
        },
        {
            label: 'ایجاد گروه',
            icon: <AiOutlineUsergroupAdd />,
            onClick: () => setGroupOpened(true)
        }
    ]

    const form = useForm({
        initialValues: {
            name: '',
            family: '',
            mobileNumber: '',
            emailAddress: '',
            group: '',
            job: ''
        },
        validate: {
            mobileNumber: (value) => {
                if (validatePhoneNumber(value) === false) {
                    return 'شماره تلفن وارد شده معتبر نیست'
                }
            },
            family: (value) => {
                if (value.length < 3) {
                    return 'نام خانوادگی باید حداقل 3 کاراکتر باشد'
                }
            },
            group: (value) => {
                if (value === '') {
                    return 'گروه را انتخاب کنید'
                }
            }
        }
    })

    async function handleNewContact(values: typeof form.values) {
        try {
            setVisibile(true)
            const response = await newContact({
                first_name: values.name,
                last_name: values.family,
                phone: values.mobileNumber,
                email: values.emailAddress,
                group_id: values.group,
                job_title: values.job
            })
            showNotification({
                title: 'مخاطب جدید',
                message: 'مخاطب جدید با موفقیت ایجاد شد',
                color: 'green',
            })
            const contactInserted = response.contact
            console.log(contactInserted);

            setContacts(contacts => [...contacts, contactInserted])
            form.reset()
        } catch (error) {
            console.log(error);

            showNotification({
                title: 'مخاطب جدید',
                message: error.response.data.exceptions.message,
                color: 'red',
            })
        } finally {
            setVisibile(false)
        }
    }

    async function getContacts() {
        try {
            const response = await getAllContacts()
            setContacts(response.contacts)
            setFetched(true)
        } catch (error) {
        }
    }
    async function getContactGroups() {
        const response = await getAllGroups()
        setGroups([])
        if (response.groups.length > 0) {
            const firstItem = {
                value: '',
                label: 'گروه را انتخاب کنید',
                disabled: true
            }
            response.groups.map((item) => {
                setGroups(groups => [...groups, { value: item.id, label: item.title }])
            })
            setGroups(groups => [firstItem, ...groups])
        } else {
            setGroups([{
                value: '',
                label: 'گروهی وجود ندارد',
                disabled: true
            }])
        }
    }
    useEffect(() => {
        getContacts()
    }, [])

    useEffect(() => {
        getContactGroups()
    }, [opened])


    const groupForm = useForm({
        initialValues: {
            title: '',
            description: ''
        },
        validate: {
            title: (value) => {
                if (value.length < 3) {
                    return 'عنوان گروه باید حداقل 3 کاراکتر باشد'
                }
            },
        }
    })

    async function handleCreateGroup(values: typeof groupForm.values) {
        try {
            const response = await newGroup({
                title: values.title,
            })
            showNotification({
                title: 'گروه جدید',
                message: 'گروه جدید با موفقیت ایجاد شد',
                color: 'green',
            })
            getContactGroups()
            groupForm.reset()
        } catch (error) {
            showNotification({
                title: 'گروه جدید',
                message: 'خطا در ایجاد گروه جدید',
                color: 'red',
            })
        }
    }


    const editContact = useForm({

    })

    return (
        <>
            <Header title="مخاطبین">
                <div className="flex">
                    <Link href="/contacts/groups">
                        <Button>
                            گروه ها
                        </Button>
                    </Link>
                    <Button
                        onClick={() => setOpened(true)}
                        className="mr-4"
                    >
                        مخاطب جدید
                    </Button>
                </div>
            </Header>
            <LoadingOverlay visible={visibile} />
            <AbsoluteButton actions={actions} />
            <div className="w-full flex items-center justify-between">
                {/* <SearchInput
                        onChange={(value) => {
                            const contactsList = [...contacts]
                            
                            const filtered = contacts.filter((item) => {
                                return item.first_name.includes(value) || item.last_name.includes(value)
                            })
                            setContacts(filtered)
                        }}
                    /> */}
                <Drawer
                    opened={opened}
                    onClose={() => setOpened(false)}
                    title="ایجاد مخاطب"
                    padding="xl"
                    size="md"
                    position="left"
                    dir="rtl"
                    className="overflow-scroll"
                >
                    <form className="flex mt-8 flex-col" onSubmit={form.onSubmit(handleNewContact)}>
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
                                {...form.getInputProps('emailAddress')}
                            />
                        </label>
                        <label className="flex flex-col w-full mt-6">
                            <span className="text-md leading-7 mb-1">گروه</span>
                            <Select
                                clearable
                                data={groups}
                                placeholder="انتخاب کنید"
                                searchable
                                defaultChecked={false}
                                {...form.getInputProps('group')}
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
                                افزودن
                            </Button>
                        </div>
                    </form>
                </Drawer>
                <Modal
                    opened={groupOpened}
                    onClose={() => setGroupOpened(false)}
                    title="ایجاد گروه"
                    size='lg'
                >
                    <div className="w-full flex flex-col">
                        <form onSubmit={groupForm.onSubmit(handleCreateGroup)}>
                            <TextInput
                                placeholder="نام گروه"
                                label="نام گروه :"
                                {...groupForm.getInputProps('title')}
                            />
                            <Button type="submit" className="mt-8 text-sm">
                                افزودن گروه
                            </Button>
                        </form>
                    </div>
                </Modal>
            </div>
            <div className="flex mt-10 mb-10">
                <div className="w-full">
                    <div>
                        {fetched && contacts && contacts.length == 0 ? (
                            <div className="w-full flex justify-center items-center flex-col">
                                <Image
                                    src='/icons/contact-not-found.svg'
                                    width={400}
                                    height={400}
                                    alt="contact not found"
                                />
                                <span className="text-md my-8">اولین مخاطب خود را ایجاد کنید</span>
                                <Button
                                    onClick={() => setOpened(true)}
                                >
                                    ایجاد مخاطب
                                </Button>
                            </div>
                        ) : (
                            <ContactsTable
                                data={contacts}
                                onDelete={(id) => setContacts(contacts.filter(item => item.id !== id))}
                            />
                        )}
                    </div>
                </div>
            </div>
        </>
    )
}